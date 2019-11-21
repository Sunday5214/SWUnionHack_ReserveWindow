using Prism.Windows.Mvvm;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Union_ReserveWindow.Core.Models;
using Union_ReserveWindow.Helpers;
using Windows.UI.Xaml;

namespace Union_ReserveWindow.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public delegate void CompleteEvent(object sender, int data);
        public event CompleteEvent CompleteAction;

        private Visibility _thisVisible = Visibility.Visible;
        public Visibility ThisVisible
        {
            get => _thisVisible;
            set => SetProperty(ref _thisVisible, value);
        }

        private string _statusText = "바코드를 찍어주세요";
        public string StatusText
        {
            get => _statusText;
            set => SetProperty(ref _statusText, value);
        }
        public LoginViewModel()
        {
            StatusText = "바코드를 찍어주세요";
        }
        public async void GetCheckAsync(string token)
        {
            RestHelper restHelper = new RestHelper();
            Header[] headers = new Header[1];
            Header header = new Header("Authorization", "Bearer" + " " + token);
            headers[0] = header;
            var data = await restHelper.GetResponse<LoginModel>("/util/token", Method.GET, null, null, null, headers);
            if (data.Identity != null)
            {
                NetworkOptions.token = token;
                CompleteAction?.Invoke(this, 1);
                ThisVisible = Visibility.Collapsed;
                
            }
            else
            {
                StatusText = "잘못된 정보입니다. 다시 찍어주세요";
            }
        }
    }
}
