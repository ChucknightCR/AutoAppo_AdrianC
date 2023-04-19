using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoAppo_AdrianC.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace AutoAppo_AdrianC.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PasswordRecoveryPage : ContentPage
	{
		UserViewModel viewModel;

		public PasswordRecoveryPage ()
		{
			InitializeComponent ();
			BindingContext = viewModel = new UserViewModel ();	
		}

        private async void BtnSendRecoveryCode_Clicked(object sender, EventArgs e)
        {
			if (!string.IsNullOrEmpty(TxtEmail.Text.Trim()))
			{
				bool R = await viewModel.AddRecoveryCode(TxtEmail.Text.Trim());
				if(R)
				{
					TxtEmail.IsEnabled = false;
					await DisplayAlert(":)", "Code sent succesfuly", "OK");
				}
			}
        }
    }
}