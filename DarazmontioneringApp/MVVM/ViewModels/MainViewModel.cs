using DarazmontioneringApp.MVVM.Models;
using DarazmontioneringApp.MVVM.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarazmontioneringApp.MVVM.ViewModels
{

    public class MainViewModel : BaseViewModel
    {
        private readonly DarazApiService _apiService;

        public ObservableCollection<Order> Orders { get; set; }

        private string _accessToken;
        public string AccessToken
        {
            get => _accessToken;
            set
            {
                _accessToken = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand GetOrdersCommand { get; }

        public MainViewModel()
        {
            _apiService = new DarazApiService();
            Orders = new ObservableCollection<Order>();
            GetOrdersCommand = new RelayCommand(async () => await LoadOrders());
        }

        private async Task LoadOrders()
        {
            var json = await _apiService.GetOrdersAsync(AccessToken);

            // Deserialize properly based on Daraz response structure
            dynamic result = JsonConvert.DeserializeObject(json);

            Orders.Clear();

            foreach (var item in result.orders)
            {
                Orders.Add(new Order
                {
                    OrderId = item.order_id,
                    Status = item.status,
                    TotalPrice = item.total_price
                });
            }
        }
    }

}
