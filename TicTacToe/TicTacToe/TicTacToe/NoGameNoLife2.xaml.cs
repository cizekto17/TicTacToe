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
        public System.Timers.Timer CountDown_P1;
        public System.Timers.Timer CountDown_P2;
        public int CountSeconds_P1;
        public int CountSeconds_P2;

        public bool Player1 = true;
        public bool Player2 = false;

        public bool GameTime = true;
        public NoGameNoLife2()
        {
            CountDown_P1 = new System.Timers.Timer();
            CountDown_P1.Interval = 1000;
            CountDown_P1.Elapsed += OnTimedEvent;

            CountDown_P2 = new System.Timers.Timer();
            CountDown_P2.Interval = 1000;
            CountDown_P2.Elapsed += OnTimedEvent;

            CountSeconds_P1 = 120;
            CountSeconds_P2 = 120;

            CountDown_P1.Start();
            InitializeComponent();
        }
        
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
        public void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Player1)
            {
                CountDown_P2.Stop();
                CountDown_P1.Start();
                CountSeconds_P1--;
                Console.WriteLine(CountSeconds_P1);
                Console.WriteLine(CountSeconds_P2);
                Label_Timer1.Text = CountSeconds_P1.ToString();
            }
            if (Player2)
            {
                CountDown_P1.Stop();
                CountDown_P2.Start();
                CountSeconds_P2--;
                Console.WriteLine(CountSeconds_P1);
                Console.WriteLine(CountSeconds_P2);
                Label_Timer2.Text = CountSeconds_P2.ToString();
            }
            if (CountSeconds_P1 == 0 || CountSeconds_P2 == 0)
            {
                CountDown_P2.Stop();
                CountDown_P2.Stop();
                GameTime = false;
            }
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