using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using TicTacToe.Models;

namespace TicTacToe.Dabase
{
    public class Dabase1
    {
        readonly SQLiteAsyncConnection _database;

        public Dabase1(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Data>().Wait();
        }

        public Task<List<Data>> GetNotesAsync()
        {
            return _database.Table<Data>().ToListAsync();
        }

        public Task<Data> GetNoteAsync(int id)
        {
            return _database.Table<Data>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Data note)
        {
            if (note.ID != 0)
            {
                return _database.UpdateAsync(note);
            }
            else
            {
                return _database.InsertAsync(note);
            }
        }

        public Task<int> DeleteNoteAsync(Data note)
        {
            return _database.DeleteAsync(note);
        }
    }
}