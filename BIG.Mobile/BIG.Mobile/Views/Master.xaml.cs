using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BIG.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : ContentPage
	{
		public Master ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);

            buttonA.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new A());
            };
            buttonB.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new B());
            };
            buttonC.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new C());
            };
            buttonD.Clicked += async (sender, e) =>
            {
                await App.NavigateMasterDetail(new LocalStorage());
            };
        }

       
    }
}