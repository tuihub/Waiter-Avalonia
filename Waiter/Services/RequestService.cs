using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Waiter.Contracts;
using Waiter.Core.Contracts.Services;

namespace Waiter.Services
{
    public class RequestService : IRequestService
    {
        private ILogger _logger;
        private IStateService _stateService;
        private ILibrarianClientService _librarianClientService;
        public RequestService(ILogger<RequestService> logger, IStateService stateService, ILibrarianClientService librarianClientService)
        {
            _logger = logger;
            _stateService = stateService;
            _librarianClientService = librarianClientService;
        }

        public async Task DoRequestAsync(Func<Task> work, Func<Task> workCleanUp, CancellationToken cts = default)
        {
            try
            {
                while (true)
                {
                    try
                    {
                        await work();
                        break;
                    }
                    catch (RpcException ex) when (ex.StatusCode == StatusCode.Unauthenticated)
                    {
                        await InnerRefreshTokenAsync(cts);
                    }
                }
            }
            catch
            {
                await workCleanUp();
                throw;
            }
        }

        public void DoRequest(Action work, Action workCleanUp)
        {
            try
            {
                while (true)
                {
                    try
                    {
                        work();
                        break;
                    }
                    catch (RpcException ex) when (ex.StatusCode == StatusCode.Unauthenticated)
                    {
                        InnerRefreshTokenAsync().Wait();
                    }
                }
            }
            catch
            {
                workCleanUp();
                throw;
            }
        }

        private async Task InnerRefreshTokenAsync(CancellationToken cts = default)
        {
            _stateService.CurrentState = IStateService.State.RefreshingToken;
            // try to use refresh token when unauthenticated error occurs
            (var accessToken, var refreshToken) = await _librarianClientService.RefreshTokenAsync(cts);
            cts.ThrowIfCancellationRequested();
            if (accessToken == string.Empty || refreshToken == string.Empty)
            {
                _stateService.CurrentState = IStateService.State.LoggedOut;
                throw new Exception("RefreshToken刷新失败，请重新登录");
            }
            else
            {
                _stateService.CurrentState = IStateService.State.LoggedIn;
                _stateService.AccessToken = accessToken;
                _stateService.RefreshToken = refreshToken;
                _logger.LogInformation("Relogged in using RefreshToken");
            }
        }
    }
}
