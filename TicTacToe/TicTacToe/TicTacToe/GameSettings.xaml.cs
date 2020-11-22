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
    public partial class GameSettings : ContentPage
    {
        Player PlayerId;
        public GameSettings(Player TmpPlayer)
        {
            InitializeComponent();
            PlayerId = TmpPlayer;

            PlayerNick.Text = PlayerId.Nick;
            System.Diagnostics.Debug.WriteLine(PlayerNick.WidthRequest);
        }
        async public void SetReady(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new NoGameNoLife());
        }
    }
}