using System;
using SQLite;

namespace TicTacToe.Models
{
    public class Data
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
