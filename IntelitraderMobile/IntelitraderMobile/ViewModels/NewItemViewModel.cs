using IntelitraderMobile.Models;
using IntelitraderMobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace IntelitraderMobile.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string nome;
        private string sexo;
        private string dataNascimento;

        ApiUsuarioService _ApiUsuarioService;

        public NewItemViewModel()
        {
            _ApiUsuarioService = new ApiUsuarioService();

            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(nome)
                && !String.IsNullOrWhiteSpace(sexo)
                && !String.IsNullOrWhiteSpace(dataNascimento);
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

        public string DataNascimento
        {
            get => dataNascimento;
            set
            {
                dataNascimento = value;
                OnPropertyChanged(nameof(DataNascimento));
            }
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Usuario newItem = new Usuario()
            {
                Nome = nome,
                Sexo = sexo,
                DataNascimento = Convert.ToDateTime(DataNascimento),
            };

            Console.WriteLine(newItem);

            await _ApiUsuarioService.AddUser(newItem);

            await Shell.Current.GoToAsync("..");
        }
    }
}
