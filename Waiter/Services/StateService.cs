using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waiter.Contracts;
using static Waiter.Contracts.IStateService;

namespace Waiter.Services
{
    public class StateService : IStateService
    {
        private State _currentState = State.LoggedOut;
        private string _accessToken = string.Empty;
        private string _refreshToken = string.Empty;

        public State CurrentState
        {
            get => _currentState;
            set
            {
                _currentState = value;
                if (value == State.LoggedOut)
                {
                    _accessToken = string.Empty;
                    _refreshToken = string.Empty;
                }
            }
        }

        public string AccessToken
        {
            get => _accessToken;
            set => _accessToken = value;
        }

        public string RefreshToken
        {
            get => _refreshToken;
            set => _refreshToken = value;
        }
    }
}
