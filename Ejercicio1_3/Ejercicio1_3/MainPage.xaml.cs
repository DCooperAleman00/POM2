using Ejercicio1_3.Models;
using Ejercicio1_3.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ejercicio1_3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            var persona = new Personas
            {
                id = 0,//porque si es diferente a 0 actualiza
                nombres = txtNombre.Text,
                apellidos = txtApellido.Text,
                edad = txtEdad.Text,
                correo = txtEmail.Text,
                direccion = txtDireccion.Text,

            };

            /* App.DBase.EmpleSave(emple) esto me retorna un resultado task y no puede ser validado con un entero*/
            var result = await App.DBase.GuardarPersona(persona);//de esta manera convertimos el resultado de task a un entero

            if (result > 0)//se usa como una super clase
            {
                await DisplayAlert("Aviso", "Registro Adicionado", "OK");
            }
            else
            {
                await DisplayAlert("Aviso", "Error al Registrar", "OK");
            }

        }

        private async void toolLista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListPersona());

        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            var persona = new Personas
            {
                id = Convert.ToInt32(txtId.Text), 
                nombres = txtNombre.Text,
                apellidos = txtApellido.Text,
                edad = txtEdad.Text,
                correo = txtEmail.Text,
                direccion = txtDireccion.Text,

            };

            var result = await App.DBase.GuardarPersona(persona); 

            if (result > 0) 
            {
                await DisplayAlert("Aviso", "Registro Actualizado", "OK");
            }
            else
            {
                await DisplayAlert("Aviso", "Error al Actulizar", "OK");
            }
        }
    }
}
