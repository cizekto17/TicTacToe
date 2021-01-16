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
        public EndOfSuffering(string Winner)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            DetermineWinner(Winner);
            
        }

        public void DetermineWinner(string Winner)
        {
            switch (Winner)
            {
                case "X":
                    XPlayer.Text = "Winner!";
                    OPlayer.Text = "LOSER!";
                    break;
                case "O":
                    XPlayer.Text = "LOSER!";
                    OPlayer.Text = "Winner!";
                    break;
                case "D":
                    XPlayer.Text = "LOSER!";
                    OPlayer.Text = "LOSER!";
                    break;
                default:
                    XPlayer.Text = "ERROR!";
                    OPlayer.Text = "ERROR!";
                    break;
            }
        }

        async public void OnPush(object sender, EventArgs args)
        {
                await Navigation.PushAsync(new MainPage());
        }
        async public void OnReset(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new GameSettings());
        }
    }
}