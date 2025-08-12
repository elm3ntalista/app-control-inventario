using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Control_Inventario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(entryUsuario.Text) &&
                !string.IsNullOrWhiteSpace(entryPassword.Text))
            {
                if (entryUsuario.Text.ToLower() == "admin" &&
                    entryPassword.Text == "123")
                {
                    entryUsuario.Text = "";
                    entryPassword.Text = "";
                    await Navigation.PushAsync(new Inventario());
                }
                else
                {
                    await DisplayAlert("Alerta", "Usuario o contraseña incorrecto", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Por favor, ingrese usuario y contraseña", "OK");
            }
        }
    }
}