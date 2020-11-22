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


        // CHECK USER NICKNAME
        // IF FALSE DISPLAY ALERT
        // IF CORRECT PUSH LIST PAGE
        async public void EnterQue(object sender, EventArgs args)
        {
            if (String.IsNullOrEmpty(EntryNick.Text))
            {
                await DisplayAlert("Nickname error", "Please set your nickname.", "exit");
            }
            else if (EntryNick.Text.Trim() != EntryNick.Text)
            {
                await DisplayAlert("Nickname error", "You can not use spaces in your nickname.", "exit");
            }
            else
            {
                await Navigation.PushAsync(new NickMenu());
            }
        }
    }
}