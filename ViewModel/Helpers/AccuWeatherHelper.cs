﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApplication.Model;
using WeatherApplication.ViewModel.Commands;
using WeatherApplication.ViewModel.Helpers;

namespace WeatherApplication.ViewModel.Helpers
{
    class AccuWeatherHelper
    {
        static string apiKey = "AHCvs6uGxYcR7dviOuIQbc9hpiwDjG6E";
            //"AHCvs6uGxYcR7dviOuIQbc9hpiwDjG6E";
        static string baseURL = "http://dataservice.accuweather.com/";
        static string locAutoComplete = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        static string currentConditions = "currentconditions/v1/{0}?apikey={1}";

        public async static Task<List<City>> GetCities(string query)
        {
            List<City> cities = new();

            string url = baseURL + string.Format(locAutoComplete, apiKey, query);
            using(HttpClient client = new())
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();
                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }

            return cities;
        }
        
        public async static Task<CurrentWeather> GetCurrentWeatherA(string cityKey)
        {
            CurrentWeather currentWeather = new();

            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()) == false)
            {

                string url = baseURL + string.Format(currentConditions, cityKey, apiKey);
                using (HttpClient client = new())
                {
                    var response = await client.GetAsync(url);
                    string json = await response.Content.ReadAsStringAsync();
                    currentWeather = (JsonConvert.DeserializeObject<List<CurrentWeather>>(json)).First();
                }
            }
                return currentWeather;
            
        }
        
      
    }
}
