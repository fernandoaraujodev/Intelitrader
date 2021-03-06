using IntelitraderMobile.Models;
using IntelitraderMobile.Services;
using IntelitraderMobile.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IntelitraderMobile.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Usuario _selectedItem;

        public ObservableCollection<Usuario> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Usuario> ItemTapped { get; }

        ApiUsuarioService _ApiUsuarioService;

        public ItemsViewModel()
        {
            Title = "Intelitrader";

            Items = new ObservableCollection<Usuario>();

            _ApiUsuarioService = new ApiUsuarioService();

            ItemTapped = new Command<Usuario>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        public async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await _ApiUsuarioService.GetUsers();
                Console.WriteLine(items);

                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Usuario SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Usuario item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}