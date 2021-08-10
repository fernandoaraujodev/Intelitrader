using IntelitraderMobile.Models;
using IntelitraderMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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