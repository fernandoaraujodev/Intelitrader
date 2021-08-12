using IntelitraderMobile.Models;
using IntelitraderMobile.Models.Enum;
using IntelitraderMobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace IntelitraderMobile.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string nome;
        private EnSexo sexo;
        private DateTime dataNascimento;

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
                && !String.IsNullOrWhiteSpace(sexo.ToString())
                && !String.IsNullOrWhiteSpace(dataNascimento.ToString());
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

        public EnSexo Sexo
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
                DataAlteracao = DateTime.Now,
                DataCriacao = DateTime.Now,
                Id = Guid.NewGuid(),
                Nome = nome,
                Sexo = sexo,
                DataNascimento = dataNascimento
            };

            Console.WriteLine(newItem);

            await _ApiUsuarioService.AddUser(newItem);

            await Shell.Current.GoToAsync("..");
        }

    }
}
