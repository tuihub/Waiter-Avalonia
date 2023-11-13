using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waiter.Core.Contracts.Services;

namespace Waiter.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private ILibrarianClientService _librarianClientService;

        public HomePageViewModel(ILibrarianClientService librarianClientService)
        {
            _librarianClientService = librarianClientService;

            ClickCommand();
        }
        private string _greeting = "HomePage Hello World!";
        public string Greeting
        {
            get => _greeting;
            set => this.RaiseAndSetIfChanged(ref _greeting, value);
        }
        public async void ClickCommand()
        {
            Greeting = "Loading...";
            var serverInfo = await _librarianClientService.GetServerInformationAsync();
            Greeting =  serverInfo.ToString();
        }
    }
}
