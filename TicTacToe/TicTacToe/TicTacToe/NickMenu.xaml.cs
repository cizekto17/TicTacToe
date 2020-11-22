using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TicTacToe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NickMenu : ContentPage
    {
        public NickMenu()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = "Pepa";
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
                await Navigation.PushAsync(new EndOfSuffering());
        }
    }
}