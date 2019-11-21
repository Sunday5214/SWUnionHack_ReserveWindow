using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json.Linq;
using Prism.Commands;
using Prism.Windows.Mvvm;
using RestSharp;
using Union_ReserveWindow.Core.Models;
using Union_ReserveWindow.Helpers;

namespace Union_ReserveWindow.ViewModels
{
    public class MarketManagerViewModel : ViewModelBase
    {
        private ObservableCollection<Market> _markets = new ObservableCollection<Market>();
        public ObservableCollection<Market> Markets
        {
            get => _markets;
            set => SetProperty(ref _markets, value);
        }

        private int _selectedId = 0;
        public int SelectedId
        {
            get => _selectedId;
            set => SetProperty(ref _selectedId, value);
        }

        private Market _selectedItem = new Market();
        public Market SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        private string _selectImage = "";
        public string SelectImage
        {
            get => _selectImage;
            set => SetProperty(ref _selectImage, value);
        }

        private string _selectName = "";
        public string SelectName
        {
            get => _selectName;
            set => SetProperty(ref _selectName, value);
        }

        private string _selectTell = "";
        public string SelectTell
        {
            get => _selectTell;
            set => SetProperty(ref _selectTell, value);
        }

        private string _selectLocation = "";
        public string SelectLocation
        {
            get => _selectLocation;
            set => SetProperty(ref _selectLocation, value);
        }

        public ICommand MarketDelete
        {
            get;
            set;
        }

        public ICommand MarketAdd
        {
            get;
            set;
        }

        public ICommand SelectionChangeCommand
        {
            get;
            set;
        }

        public async void GetDataAsync()
        {
            RestHelper restHelper = new RestHelper();
            Header[] headers = new Header[1];
            Header header = new Header("Authorization", "Bearer" + " " + NetworkOptions.token);
            headers[0] = header;
            var data = await restHelper.GetResponse<Markets>("/service/my-market", Method.GET, null, null, null, headers);


            if (data.MarketList == null || data.MarketList.Count == 0)
            {
                Markets.Add(new Market() { Id = 1, Location = "의창구", Name = "ehlloWorld", Tell = "010-0000-0000", Image = "https://t1.daumcdn.net/cfile/tistory/99D3B8395BA653D216" });
            }
            else
            {
                foreach (var daten in data.MarketList)
                {
                    Markets.Add(daten);
                }
            }
        }

        public async void DeleteDataAsync()
        {
            RestHelper restHelper = new RestHelper();
            Header[] headers = new Header[1];
            Header header = new Header("Authorization", "Bearer" + " " + NetworkOptions.token);
            headers[0] = header;
            JObject jObject = new JObject();
            jObject["market_id"] = SelectedId;
            await restHelper.GetResponse<Markets>("/service/my-market", Method.DELETE, jObject.ToString(), null, null, headers);
        }

        public async void AddDataAsync()
        {
            RestHelper restHelper = new RestHelper();
            Header[] headers = new Header[1];
            Header header = new Header("Authorization", "Bearer" + " " + NetworkOptions.token);
            headers[0] = header;
            JObject jObject = new JObject();
            jObject["name"] = SelectName;
            jObject["location"] = SelectLocation;
            jObject["tel_num"] = SelectTell;
            await restHelper.GetResponse<Markets>("/service/my-market", Method.POST, jObject.ToString(), null, null, headers);
        }

        public void OnSelectionChanged()
        {
            SelectImage = SelectedItem.Image;
            SelectLocation = SelectedItem.Location;
            SelectName = SelectedItem.Name;
            SelectTell = SelectedItem.Tell;
            SelectedId = SelectedItem.Id;
        }

        public void OnDelete()
        {
            DeleteDataAsync();
        }

        public void OnAdd()
        {
            AddDataAsync();
        }

        public MarketManagerViewModel()
        {
            SelectionChangeCommand = new DelegateCommand(OnSelectionChanged);
            MarketDelete = new DelegateCommand(OnDelete);
            MarketAdd = new DelegateCommand(OnAdd);
        }
    }
}
