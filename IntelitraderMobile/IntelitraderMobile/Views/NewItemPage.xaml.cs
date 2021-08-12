using IntelitraderMobile.Models;
using IntelitraderMobile.Models.Enum;
using IntelitraderMobile.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;

namespace IntelitraderMobile.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Usuario Item { get; set; }


        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();

        }
    }
}