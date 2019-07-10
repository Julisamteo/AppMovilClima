using AppClimaa.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppClimaa.ViewModels
{
    public class MainPageViewModel: INotifyPropertyChanged

    {
        private WeatherData data;

        public WeatherData Data
        {
            get => data;
            set
            {
                data = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchCommand { get; set; }


        public MainPageViewModel()
        {
            SearchCommand = new Command(async (searchTerm) =>
            {
                await GetData($"https://api.darksky.net/forecast/6a3b5b444561edf19d3a388fe907aad3/{searchTerm}?lang=es");
            }); 
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public async Task GetData(string url)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            var response = await client.GetAsync(client.BaseAddress);
            response.EnsureSuccessStatusCode();// manda error 
            var jsonR = await response.Content.ReadAsStringAsync(); // recibe la petición
            var result = JsonConvert.DeserializeObject<WeatherData>(jsonR);
            Data = result;
        }
        
        protected virtual void OnPropertyChanged ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
