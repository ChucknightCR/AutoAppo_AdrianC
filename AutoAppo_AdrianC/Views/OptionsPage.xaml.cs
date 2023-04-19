using AutoAppo_AdrianC.Models;
using AutoAppo_AllanD.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoAppo_AdrianC.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OptionsPage : ContentPage
    {
        public OptionsPage()
        {
            InitializeComponent();
        }

        private async void BtnAppoManagment_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyAppointmentListPage());

        }
    }
}