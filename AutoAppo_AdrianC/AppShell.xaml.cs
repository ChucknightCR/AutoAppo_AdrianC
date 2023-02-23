using AutoAppo_AdrianC.ViewModels;
using AutoAppo_AdrianC.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AutoAppo_AdrianC
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
