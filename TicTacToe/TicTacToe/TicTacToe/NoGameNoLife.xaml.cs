﻿using System;
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
        public int CountSeconds_P1;
        public int CountSeconds_P2;

        public bool Player1 = true;
        public bool Player2 = false;

        public bool GameTime = true;

        public static string[,] Pole;
        public int Rady = 3;
        public int Sloupce = 3;
        public int Rada;
        public int Sloupec;
        public NoGameNoLife()
        {
            Board();
            CountDown_P1 = new System.Timers.Timer();
            CountDown_P1.Interval = 1000;
            CountDown_P1.Elapsed += OnTimedEvent;

            CountDown_P2 = new System.Timers.Timer();
            CountDown_P2.Interval = 1000;
            CountDown_P2.Elapsed += OnTimedEvent;

            CountSeconds_P1 = 120;
            CountSeconds_P2 = 120;

            
            
            InitializeComponent();
            CountDown_P1.Start();


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
                
                btn.IsEnabled = false;
                Player1 = false;
                Player2 = true;
            }
            else if (Player2)
            {
                btn.Source = ImageSource.FromResource("TicTacToe.Images.o_player.png");
                Console.WriteLine(btn.Source);
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
                btn.IsEnabled = false;
                Player1 = true;
                Player2 = false;
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
                //Console.WriteLine(CountSeconds_P1);
                //Console.WriteLine(CountSeconds_P2);
                Label_Timer1.Text = CountSeconds_P1.ToString();
            }
            if (Player2)
            {
                CountDown_P1.Stop();
                CountDown_P2.Start();
                CountSeconds_P2--;
                //Console.WriteLine(CountSeconds_P1);
                //Console.WriteLine(CountSeconds_P2);
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
            await Navigation.PushAsync(new NoGameNoLife2 { });
        }


    }
   
}