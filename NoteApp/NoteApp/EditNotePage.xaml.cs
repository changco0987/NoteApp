using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteApp.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditNotePage : ContentPage
    {
        string finalSelectedIcon;
        public EditNotePage(Model.reminders Reminders)
        {
            InitializeComponent();

            SelectedReminder = Reminders;
            title.Text = Reminders.Title;
            IconPicker.Title = Reminders.Icon;
            contentText.Text = Reminders.NoteContent;
            displayIcon.Source = Reminders.Icon;
            IconPicker.ItemsSource = IconModel.IconList;
        }

        Model.reminders SelectedReminder;
        async void UpdateReminders()
        {
            if (finalSelectedIcon == null)
            {
                //This means that the user is not changing the Icon

                SelectedReminder.Title = title.Text;
                SelectedReminder.NoteContent = contentText.Text;
                await App.Database.UpdateReminders(SelectedReminder);
                await Navigation.PopAsync();

            }
            else
            {
                SelectedReminder.Title = title.Text;
                SelectedReminder.Icon = finalSelectedIcon;
                SelectedReminder.NoteContent = contentText.Text;
                await App.Database.UpdateReminders(SelectedReminder);
                await Navigation.PopAsync();
            }
        }

        //The method below will save the data to our model
        void ToolbarItemSubmit_Clicked(object sender, EventArgs e)
        {

            UpdateReminders();
        }

        private void IconPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIcon = IconPicker.SelectedIndex;
            displayIcon.Source = IconModel.IconList[selectedIcon].IconPath;

            finalSelectedIcon = IconModel.IconList[selectedIcon].IconName;//To get the selected icon
        }
    }
}