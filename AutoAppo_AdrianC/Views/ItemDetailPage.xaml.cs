using AutoAppo_AdrianC.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AutoAppo_AdrianC.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}