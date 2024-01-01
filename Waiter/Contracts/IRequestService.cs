using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Waiter.Contracts
{
    public interface IRequestService
    {
        Task DoRequestAsync(Func<Task> work, Func<Task>? workCleanUp = null, CancellationToken cts = default);
        void DoRequest(Action work, Action? workCleanUp = null);
    }
}
