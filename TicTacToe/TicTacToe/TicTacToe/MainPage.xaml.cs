using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

namespace TicTacToe
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        // Enter game
        async public void EnterQue(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new GameSettings());
        }

        async public void ExitGame(object sender, EventArgs args)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}