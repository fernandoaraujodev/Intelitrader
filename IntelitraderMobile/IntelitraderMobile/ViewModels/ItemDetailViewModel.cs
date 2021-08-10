using IntelitraderMobile.Models;
using IntelitraderMobile.Services;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace IntelitraderMobile.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string nome;
        private string sexo;
        private DateTime dataNascimento;
        private bool _isPlaceHolderVisible;
        public Guid id { get; set; }

        ApiUsuarioService _ApiUsuarioService;

        public ItemDetailViewModel()
        {
            _ApiUsuarioService = new ApiUsuarioService();

            DeleteItemCommand = new Command(DeleteItemId);
            EditItemCommand = new Command(EditItemId);
        }

        public bool IsPlaceHolderVisible
        {
            get => _isPlaceHolderVisible;
            set
            {
                _isPlaceHolderVisible = value;
            }
        }

        public string Nome
        {
            get => nome;
            set
            {
                nome = value;
                OnPropertyChanged(nameof(Nome));
            }
        }

        public string Sexo
        {
            get => sexo;
            set
            {
                sexo = value;
                OnPropertyChanged(nameof(Sexo));
            }
        }
        public DateTime DataNascimento
        {
            get => dataNascimento;
            set
            {
                dataNascimento = value;
                OnPropertyChanged(nameof(DataNascimento));
            }
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await _ApiUsuarioService.GetUser(itemId);

                id = item.Id;
                Nome = item.Nome;
                Sexo = item.Sexo;
                DataNascimento = item.DataNascimento;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public async void DeleteItemId()
        {
            try
            {
                await _ApiUsuarioService.DeleteUser(itemId);

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public async void EditItemId()
        {
            Usuario newItem = new Usuario()
            {
                Nome = Nome,
                Sexo = Sexo,
                DataNascimento = DataNascimento,
                DataAlteracao = DateTime.Now
            };

            await _ApiUsuarioService.UpdateUser(itemId, newItem);

            await Shell.Current.GoToAsync("..");
        }

        public Command DeleteItemCommand { get; }
        public Command EditItemCommand { get; }

    }
}
