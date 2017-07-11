using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Laboratorio_01
{
    [Activity(Label = "Laboratorio_01", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button boton;
        TextView txt;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            //Identificamos a la variables que ID tomar
            boton = FindViewById<Button>(Resource.Id.MyButton);
            txt = FindViewById<TextView>(Resource.Id.textViewDev);
            //Metodo que crea un evento onclick que se auto genera
            boton.Click += Boton_Click;
        }

        private async void Boton_Click(object sender, EventArgs e)
        {
            txt.Text = "Insertar tu noombre";
            //Obtenemos el ID del activity
            string myDevice = Android.Provider.Settings.Secure.GetString(ContentResolver, Android.Provider.Settings.Secure.AndroidId);
            //Llamamos la clase 
            XamarinDiplomado.ServiceHelper helper = new XamarinDiplomado.ServiceHelper();
            //Pasamos parametros a la clase
            await helper.InsertarEntidad("thekronyck@gmail.com", "lab1", myDevice);
            boton.Text = "Gracias por completar el Laboratorio 1";
        }
    }
}

