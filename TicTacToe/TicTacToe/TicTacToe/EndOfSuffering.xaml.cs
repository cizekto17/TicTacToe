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
    public partial class EndOfSuffering : ContentPage
    {
        public EndOfSuffering()
        {
            InitializeComponent();
        }
        async public void OnPush(object sender, EventArgs args)
        {
                await Navigation.PushAsync(new MainPage());
        }
        async public void OnReset(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new GameSettings(new Player("Dobby")));
        }
    }
}