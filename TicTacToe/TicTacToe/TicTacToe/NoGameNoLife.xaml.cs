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
    public partial class NoGameNoLife : ContentPage
    {
        public NoGameNoLife()
        {
            InitializeComponent();
        }
        public bool Player1 = true;
        public bool Player2 = false;
        public void Button_Clicked(object sender, EventArgs args)
        {
            ImageButton btn = (ImageButton)sender;

            
            //btn.Source = ImageSource.FromFile("Images/x_player2.png");
            //btn.Source = ImageSource.FromFile("{local:ImageResource TicTacToe.Images.o_player.png}");
    
            if (Player1)
            {   
                btn.Source = ImageSource.FromResource("TicTacToe.Images.x_player2.png");
                Console.WriteLine(btn.Source);
                btn.IsEnabled = false;
                Player1 = false;
                Player2 = true;
            }
            else if (Player2)
            {
                btn.Source = ImageSource.FromResource("TicTacToe.Images.o_player.png");
                Console.WriteLine(btn.Source);
                btn.IsEnabled = false;
                Player1 = true;
                Player2 = false;
            }
            

        }
        async public void Surrender(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new EndOfSuffering { });
        }
        async public void Pause(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new NoGameNoLife2 { });
        }


    }
   
}