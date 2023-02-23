using AutoAppo_AdrianC.Services;
using AutoAppo_AdrianC.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoAppo_AdrianC
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            //Definimos la paquina de inicio
            MainPage = new NavigationPage(new AppoLoginPage());
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
