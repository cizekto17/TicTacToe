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
        public GameSettings()
        {
            InitializeComponent();
        }
        async public void SetReady(object sender, EventArgs args)
        {
            if (GameTypeBool.IsToggled)
            {
                await Navigation.PushAsync(new NoGameNoLife());
            }
            else
            {
                await Navigation.PushAsync(new NoGameNoLife2());
            }  
        }

        void OnToggledGameType(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                GameTypeText.Text = "On 3";
            }
            else
            {
                GameTypeText.Text = "On 5";
            }
        }
    }
}