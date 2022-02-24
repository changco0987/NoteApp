using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace NoteApp.Model
{
    internal class IconModel
    {
        public static ObservableCollection<IconModel> IconList = new ObservableCollection<IconModel> 
        {
            new IconModel
            {
                IconName = "smiley",
                IconPath = "smiley.png"
            },
            new IconModel
            {
                IconName = "love",
                IconPath = "love.png"
            },
            new IconModel
            {
                IconName = "birthday",
                IconPath = "birthday.png"
            },
            new IconModel
            {
                IconName = "crying",
                IconPath = "crying.png"
            },
            new IconModel
            {
                IconName = "halloween",
                IconPath = "halloween.png"
            },
            new IconModel
            {
                IconName = "christmas",
                IconPath = "christmas.png"
            }
        };
        public string IconName { get; set; }

        public string IconPath { get; set; }
    }
}
