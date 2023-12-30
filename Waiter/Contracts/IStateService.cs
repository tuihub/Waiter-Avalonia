using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waiter.Contracts
{
    public interface IStateService
    {
        enum State
        {
            LoggedOut,
            LoggedIn,
            RefreshingToken
        }
        State CurrentState { get; set; }
        string AccessToken { get; set; }
        string RefreshToken { get; set; }
    }
}
