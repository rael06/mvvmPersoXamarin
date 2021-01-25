using System;
using System.Collections.Generic;
using System.ComponentModel;
using mvvmperso.Models;
using mvvmperso.Services;
using Xamarin.Forms;

namespace mvvmperso.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected readonly IApiService apiService = new ApiService();

        protected ViewModelLocator Locator => App.Current.Resources["Locator"] as ViewModelLocator;
        protected INavigation Navigation => App.Current.MainPage.Navigation;

        public ViewModelBase()
        {
        }

        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}
