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
        public System.Timers.Timer CountDown_P1;
        public System.Timers.Timer CountDown_P2;
        public string CountSeconds_P1_String { get; set; }
        public string CountSeconds_P2_String { get; set; }
        private int _P1;
        private int _P2;
        private int seconds1;
        private int minutes1;
        private int seconds2;
        private int minutes2;
        public int tahy = 9;
        public int CountSeconds_P1
        {
            get { return this._P1; }
            set
            {
                this._P1 = value;
                this.seconds1 = _P1 % 60;
                this.minutes1 = _P1 / 60 % 60;

                this.CountSeconds_P1_String = minutes1 + ":" + seconds1;                
                OnPropertyChanged("CountSeconds_P1_String");
            }
        }
        public int CountSeconds_P2
        {
            get { return this._P2; }
            set
            {
                this._P2 = value;
                this.seconds2 = _P2 % 60;
                this.minutes2 = _P2 / 60 % 60;

                this.CountSeconds_P2_String = minutes2 + ":" + seconds2;
                OnPropertyChanged("CountSeconds_P2_String");
            }

        }
        public bool Player1 = true;
        public bool Player2 = false;

        public bool GameTime1 = true;
        public bool GameTime2 = true;

        public static string[,] Pole;
        public int Rady = 3;
        public int Sloupce = 3;
        public int Rada;
        public int Sloupec;

        GameEnder GE = new GameEnder(Pole, 3, 3, 3);
        string tmpLP;        
        public NoGameNoLife(bool tmpTimer)
        {
            Board();
            if (tmpTimer)
            {
                CountDown_P1 = new System.Timers.Timer();
                CountDown_P1.Interval = 1000;
                CountDown_P1.Elapsed += OnTimedEvent;

                CountDown_P2 = new System.Timers.Timer();
                CountDown_P2.Interval = 1000;
                CountDown_P2.Elapsed += OnTimedEvent;

                CountSeconds_P1 = 180;
                CountSeconds_P2 = 180;
                CountDown_P1.Start();
            }
            BindingContext = this;

            
            InitializeComponent();
        }               
        public void Button_Clicked(object sender, EventArgs args)
        {
            ImageButton btn = (ImageButton)sender;
            if (Player1)
            {
                btn.Source = ImageSource.FromResource("TicTacToe.Images.x_player2.png");
                Console.WriteLine(btn.Source);
                Rada = Grid.GetRow(btn);
                Sloupec = Grid.GetColumn(btn);
                Console.WriteLine("Rada"+Rada);
                Console.WriteLine("Sloupec"+Sloupec);
                if (Pole[Rada-1,Sloupec-1] == "X" || Pole[Rada-1, Sloupec-1] == "O")
                {
                    Console.WriteLine("Nelze zabrat toto pole");
                }
                else
                {
                    Pole[Rada - 1, Sloupec - 1] = "X";
                }
                tmpLP = "X";
                btn.IsEnabled = false;
                tahy--;
                Player1 = false;
                Player2 = true;
            }
            else if (Player2)
            {
                btn.Source = ImageSource.FromResource("TicTacToe.Images.o_player.png");
                Console.WriteLine(btn.Source);
                Rada = Grid.GetRow(btn);
                Sloupec = Grid.GetColumn(btn);
                Console.WriteLine("Rada" + Rada);
                Console.WriteLine("Sloupec" + Sloupec);
                if (Pole[Rada - 1, Sloupec - 1] == "X" || Pole[Rada - 1, Sloupec - 1] == "O")
                {
                    Console.WriteLine("Nelze zabrat toto pole");
                }
                else
                {
                    Pole[Rada - 1, Sloupec - 1] = "O";                  
                }
                tmpLP = "O";
                btn.IsEnabled = false;
                tahy--;
                Player1 = true;
                Player2 = false;
            }
            GE.gameField = Pole;
            if (GE.CheckGameEnd(tmpLP))
            {
                Navigation.PushAsync(new EndOfSuffering(GE.lastPlayed) { });
            }
        }
        public void Board()
        {
            Pole = new string[Rady, Sloupce];
            for (int x = 0; x < Rady; x++)
            {
                for (int y = 0; y < Sloupce; y++)
                {
                    Pole[x, y] = "P";
                }
            }
        }
        public void OnTimedEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Player1)
            {
                CountDown_P2.Stop();
                CountDown_P1.Start();
                CountSeconds_P1--;
                //System.Diagnostics.Debug.WriteLine(CountSeconds_P1_String);
                //Console.WriteLine(CountSeconds_P1);
                //Console.WriteLine(CountSeconds_P2);
                // Label_Timer1.Text = CountSeconds_P1.ToString();
            }
            if (Player2)
            {
                CountDown_P1.Stop();
                CountDown_P2.Start();
                CountSeconds_P2--;
                //System.Diagnostics.Debug.WriteLine(CountSeconds_P2_String);
                //Console.WriteLine(CountSeconds_P1);
                //Console.WriteLine(CountSeconds_P2);
                //Label_Timer2.Text = CountSeconds_P2.ToString();
            }
            if (CountSeconds_P1 == 0)
            {
                CountDown_P1.Stop();
                GameTime1 = false;
                Device.BeginInvokeOnMainThread(() =>
                {
                    Game();
                });
            }
            else if (CountSeconds_P2 == 0)
            {
                CountDown_P2.Stop();
                GameTime2 = false;
                Device.BeginInvokeOnMainThread(() =>
                {
                    Game();
                });
            }
            else if (tahy == 0)
            {
                tahy--;
                Device.BeginInvokeOnMainThread(() =>
                {
                    Draw();
                });
            }
        }      
      async public void Game()
        {
            if (GameTime1)
            {
                GE.lastPlayed = "X";
            }
            else if (GameTime2)
            {
                GE.lastPlayed = "O";
            }            
            await Navigation.PushAsync(new EndOfSuffering(GE.lastPlayed) { });
        }
        async public void Draw()
        {
            GE.lastPlayed = "D";
            await Navigation.PushAsync(new EndOfSuffering(GE.lastPlayed) { });
        }
        async public void Surrender(object sender, EventArgs args)
        {          
            GE.lastPlayed = "D";
            await Navigation.PushAsync(new EndOfSuffering(GE.lastPlayed) { });
        }       
    }  
}