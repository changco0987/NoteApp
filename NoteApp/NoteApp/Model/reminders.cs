using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SQLite;

namespace NoteApp.Model
{
    public class reminders
    {
        public static ObservableCollection<reminders> reminderList = new ObservableCollection<reminders>();

        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        public string Icon { get; set; }
        public string NoteContent { get; set; }
    }
}
