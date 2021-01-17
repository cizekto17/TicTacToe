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
        //Vytvoření Timerů a počtu vteřin
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

        //Nastavení počtu tahů
        public int tahy = 9;

        //Vytvoření Bindingovatelné proměnné časovače hráče X
        public int CountSeconds_P1
        {
            get { return this._P1; }
            set
            {
                this._P1 = value;
                //Zobrazení v minutách
                this.seconds1 = _P1 % 60;
                this.minutes1 = _P1 / 60 % 60;
                //Vytvoření Bindingu
                this.CountSeconds_P1_String = minutes1 + ":" + seconds1;                
                OnPropertyChanged("CountSeconds_P1_String");
            }
        }
        //Vytvoření Bindingovatelné proměnné časovače hráče O
        public int CountSeconds_P2
        {
            get { return this._P2; }
            set
            {
                this._P2 = value;
                //Zobrazení v minutách
                this.seconds2 = _P2 % 60;
                this.minutes2 = _P2 / 60 % 60;
                //Vytvoření Bindingu
                this.CountSeconds_P2_String = minutes2 + ":" + seconds2;
                OnPropertyChanged("CountSeconds_P2_String");
            }

        }
        //Vytvoření hráčů
        public bool Player1 = true;
        public bool Player2 = false;

        public bool GameTime1 = true;
        public bool GameTime2 = true;

        //Vytoření Pole
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
                //Ńastavení Timeru hráče X
                CountDown_P1 = new System.Timers.Timer();
                CountDown_P1.Interval = 1000;
                CountDown_P1.Elapsed += OnTimedEvent;

                //Ńastavení Timeru hráče O
                CountDown_P2 = new System.Timers.Timer();
                CountDown_P2.Interval = 1000;
                CountDown_P2.Elapsed += OnTimedEvent;

                //Nastavení času Hráče X
                CountSeconds_P1 = 30;
                //Nastavení času Hráče 0
                CountSeconds_P2 = 29;

                // Spuštění časovače pro Hráče X
                CountDown_P1.Start();
            }
            BindingContext = this;

            
            InitializeComponent();
        }
        //po kliknutí na tlačítko
        public void Button_Clicked(object sender, EventArgs args)
        {
            ImageButton btn = (ImageButton)sender;
            //Hráč X
            if (Player1)
            {
                //získání obrázku hráče O
                btn.Source = ImageSource.FromResource("TicTacToe.Images.x_player2.png");

                //Ověření obrázku pro vývojáře
                Console.WriteLine(btn.Source);

                //získání souřadnic
                Rada = Grid.GetRow(btn);
                Sloupec = Grid.GetColumn(btn);

                //ověření souřadnic
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
                //Vypnutí tlačítka
                btn.IsEnabled = false;

                //odečtení zbývajících tahů
                tahy--;

                //přepnutí hráčů
                Player1 = false;
                Player2 = true;
            }
            //Hráč O
            else if (Player2)
            {
                //získání obrázku hráče O
                btn.Source = ImageSource.FromResource("TicTacToe.Images.o_player.png");

                //Ověření obrázku pro vývojáře
                Console.WriteLine(btn.Source);

                //získání souřadnic
                Rada = Grid.GetRow(btn);
                Sloupec = Grid.GetColumn(btn);

                //ověření souřadnic
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

                //Vypnutí tlačítka
                btn.IsEnabled = false;

                //odečtení zbývajících tahů
                tahy--;

                //přepnutí hráčů
                Player1 = true;
                Player2 = false;
            }
            GE.gameField = Pole;
            //Konec hry
            if (GE.CheckGameEnd(tmpLP))
            {
                CountDown_P1.Stop();
                CountDown_P2.Stop();
                Navigation.PushAsync(new EndOfSuffering(GE.lastPlayed) { });
            }
        }
        //vytvoření pole identické k hernímu poli
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
            //Odčítání času hráče X
            if (Player1)
            {
                //Zastavení časovače hráče O
                CountDown_P2.Stop();
                //Spuštění časovače hráče X
                CountDown_P1.Start();
                CountSeconds_P1--;

                //Ověření zdali časovače fungují
                //System.Diagnostics.Debug.WriteLine(CountSeconds_P1_String);
                Console.WriteLine(CountSeconds_P1);
                Console.WriteLine(CountSeconds_P2);
                // Label_Timer1.Text = CountSeconds_P1.ToString();
            }
            //Odčítání času hráče O
            if (Player2)
            {
                //Zastavení časovače hráče X
                CountDown_P1.Stop();
                //Spuštění časovače hráče O
                CountDown_P2.Start();
                CountSeconds_P2--;

                //Ověření zdali časovače fungují
                //System.Diagnostics.Debug.WriteLine(CountSeconds_P2_String);
                Console.WriteLine(CountSeconds_P1);
                Console.WriteLine(CountSeconds_P2);
                //Label_Timer2.Text = CountSeconds_P2.ToString();
            }
            //Výsledek když dojde hráči X čas
            if (CountSeconds_P1 == 0)
            {
                //zastavení časovačů
                CountDown_P1.Stop();
                CountDown_P2.Stop();
                GameTime1 = false;
                //přesměrování na výslednou stranu
                Device.BeginInvokeOnMainThread(() =>
                {
                    Game();
                });
            }
            //Výsledek když dojde hráči O čas
            else if (CountSeconds_P2 == 0)
            {
                //zastavení časovačů
                CountDown_P1.Stop();
                CountDown_P2.Stop();
                GameTime2 = false;
                //přesměrování na výslednou stranu
                Device.BeginInvokeOnMainThread(() =>
                {
                    Game();
                });
            }
            //Výsledek když jsou zabrány všechny pole => remíza
            else if (tahy == 0)
            {
                tahy--;
                //přesměrování na výslednou stranu
                Device.BeginInvokeOnMainThread(() =>
                {
                    Draw();
                });
            }
        }
      //získání hráče, který hrál naposledy
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
            //přesměrování na výslednou stranu s informací o výherci
            await Navigation.PushAsync(new EndOfSuffering(GE.lastPlayed) { });
        }
        //vyhodnocení remízy
        async public void Draw()
        {
            GE.lastPlayed = "D";

            //přesměrování na výslednou stranu s informací o remíze
            await Navigation.PushAsync(new EndOfSuffering(GE.lastPlayed) { });
        }
        //vzdát se - remíza, jelikož hra nebyla dohrána
        async public void Surrender(object sender, EventArgs args)
        {          
            GE.lastPlayed = "D";
            //přesměrování na výslednou stranu s informací o remíze
            await Navigation.PushAsync(new EndOfSuffering(GE.lastPlayed) { });
        }       
    }  
}