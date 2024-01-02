using FluentAvalonia.UI.Controls;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiHub.Protos.Librarian.Sephirah.V1;
using Waiter.Contracts;
using Waiter.Core.Contracts.Services;

namespace Waiter.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private ILibrarianClientService _librarianClientService;
        private IRequestService _requestService;
        private IDialogService _dialogService;

        public HomePageViewModel(ILibrarianClientService librarianClientService, IRequestService requestService, IDialogService dialogService)
        {
            _librarianClientService = librarianClientService;
            _requestService = requestService;
            _dialogService = dialogService;

            //ClickCommand();
        }

        private GetServerInformationResponse _serverInfo = new();
        public GetServerInformationResponse ServerInfo
        {
            get => _serverInfo;
            set => this.RaiseAndSetIfChanged(ref _serverInfo, value);
        }

        public async void OnNavigatedTo()
        {
            try
            {
                ServerInfo = await _librarianClientService.GetServerInformationAsync();
            }
            catch (Exception ex)
            {
                await _dialogService.ShowContentDialogAsync(ex);
            }
        }

        private string _greeting = "HomePage Hello World!";
        public string Greeting
        {
            get => _greeting;
            set => this.RaiseAndSetIfChanged(ref _greeting, value);
        }
        public async void ClickCommand()
        {
            try
            {
                Greeting = "Loading...";
                var serverInfo = await _librarianClientService.GetServerInformationAsync();
                Greeting = serverInfo.ToString();
            }
            catch (Exception ex)
            {
                Greeting = "Error";
                await _dialogService.ShowContentDialogAsync(ex);
            }
        }

        public async void ShowContentDialogCommand()
        {
            await _dialogService.ShowLoginDialogAsync();
        }
    }
}
