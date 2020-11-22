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
    public partial class NoGameNoLife2 : ContentPage
    {
        public NoGameNoLife2()
        {
            InitializeComponent();
        }
        async public void Surrender(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new EndOfSuffering { });
        }
        async public void Pause(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new NoGameNoLife { });
        }
    }
}