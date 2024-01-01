using FluentAvalonia.UI.Controls;
using Google.Protobuf.WellKnownTypes;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuiHub.Protos.Librarian.Sephirah.V1;
using Waiter.Core.Contracts.Services;

namespace Waiter.ViewModels.Design
{
    public class HomePageViewModel : ViewModels.HomePageViewModel
    {
        public HomePageViewModel() : base(null, null, null)
        {
            base.Greeting = _greeting;
            base.ServerInfo = _serverInfo;
        }
        private string _greeting = "HomePage.Design Hello World!";
        private GetServerInformationResponse _serverInfo = new()
        {
            ServerBinarySummary = new ServerBinarySummary
            {
                SourceCodeAddress = "https://example.com/Librarian-CSharp",
                BuildVersion = "v0.1.0+1234567-design",
                BuildDate = "2021-01-01T00:00:00Z",
            },
            ProtocolSummary = new ServerProtocolSummary
            {
                Version = "v0.1.99-design"
            },
            CurrentTime = Timestamp.FromDateTime(DateTime.UtcNow)
        };
    }
}
