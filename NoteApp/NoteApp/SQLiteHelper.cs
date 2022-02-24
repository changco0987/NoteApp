using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using NoteApp.Model;

namespace NoteApp
{
    public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<reminders>();
        }

        public Task<int> CreateReminders(reminders Reminders)
        {
            return db.InsertAsync(Reminders);
        }

        public Task<List<reminders>> ReadReminders()
        {
            return db.Table<reminders>().ToListAsync();
        }

        public Task<int> UpdateReminders(reminders Reminders)
        {
            return db.UpdateAsync(Reminders);
        }

        public Task<int> DeleteReminders(reminders Reminders)
        {
            return db.DeleteAsync(Reminders);
        }

        public Task<List<reminders>> Search(string search) 
        {
            return db.Table<reminders>().Where(p => p.Title.StartsWith(search)).ToListAsync();
        }
    }
}
