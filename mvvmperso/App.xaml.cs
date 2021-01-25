using System;
using mvvmperso.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mvvmperso
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ArticleListPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
