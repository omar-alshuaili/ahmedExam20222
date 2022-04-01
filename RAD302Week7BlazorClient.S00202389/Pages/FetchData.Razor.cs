using DataServices;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RAD302Week7BlazorClient.S00202389.Pages
{
    public partial class FetchData
    {
        [Inject]
        public IHttpClientService httpService { get; set; }
        private List<WeatherForecast> forecasts;



        protected override async Task OnInitializedAsync()
        {
            forecasts = await httpService.getCollection<WeatherForecast>("WeatherForecast");
        }
        public class WeatherForecast
        {
            public DateTime Date { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }
            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        }
    }
}
