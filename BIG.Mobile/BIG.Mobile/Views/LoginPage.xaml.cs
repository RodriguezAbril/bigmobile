using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Xamarin.Forms;
using System.Text.RegularExpressions;
using Xamarin.Forms.Xaml;

namespace BIG.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            btncomplent.Clicked += Btncomplent_Clicked;
            NavigationPage.SetHasNavigationBar(this, false);
            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
		}

        private void Btncomplent_Clicked(object sender, EventArgs e)
        {
            ((NavigationPage)this.Parent).PushAsync(new Denuncia());
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            var nombre = EntryEmail.Text;
            if (string.IsNullOrEmpty(nombre))
            {
                //DisplayAlert("Error", "Debe proporcionar un usuario", "OK");
                btnSave.IsEnabled = true;
            }
            else
            {
                var email = EntryEmail.Text;
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                if (match.Success)
                {
                    Errorlabel.Text = "";
                }
                else
                {

                    Errorlabel.Text = "Invalid Format";
                }
            }
        }

        private async void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            await DisplayAlert("Error", "Check for your connection", "OK");
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("error", "check for your connection", "ok");
            }
        }

        private void btncomplent_Clicked(object sender, EventArgs e)
        {

        }
    }
}