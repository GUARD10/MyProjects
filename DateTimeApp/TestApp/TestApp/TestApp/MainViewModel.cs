using System;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TestApp
{
    class MainViewModel : INotifyPropertyChanged
    {       
        public event PropertyChangedEventHandler PropertyChanged;
                
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        private ICommand _getDateTime;
        private string _setDateTime;

        public string SetDateTime
        {
            get => _setDateTime;
            set
            {
                _setDateTime = value;
                NotifyPropertyChanged("SetDateTime");
            }
        }

        public ICommand GetDateTime => (_getDateTime) ?? (_getDateTime = new Command(MyCommand));

        
        private void MyCommand()
        {
            SetDateTime = DateTime.UtcNow.ToString();            
            Send(url: "http://192.168.1.4:45456/api/Home");               
        }

        private void Send(string url)
        {
            using(var client = new HttpClient())
            {
                try
                {
                    var content = new StringContent("{ \"DateTimePressed\": \" " + SetDateTime + "\"}", Encoding.UTF8, "application/json");
                    client.PostAsync(url, content);
                }
                catch (Exception)
                {                    
                }
            }
        }        
    }
}
