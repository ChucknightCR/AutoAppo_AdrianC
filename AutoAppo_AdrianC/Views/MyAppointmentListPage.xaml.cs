using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AutoAppo_AdrianC.ViewModels;
using AutoAppo_AdrianC.Models;
using AutoAppo_AdrianC;

namespace AutoAppo_AllanD.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyAppointmentListPage : ContentPage
    {
        UserViewModel vm;

        public MyAppointmentListPage()
        {
            InitializeComponent();

            BindingContext = vm = new UserViewModel();

            //como tenemos un usuario global con el ID que necesitamos, 
            //pasamos ese ID como parametro a la funcion de carga de citas. 

            LoadAppos(GlobalObjects.LocalUser.IDUsuario);
        }

        private async void LoadAppos(int pUserID)
        {
            LstAppoList.ItemsSource = await vm.GetAppoList(pUserID);
        }

    }
}