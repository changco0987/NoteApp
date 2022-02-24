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
    public partial class NewNotePage : ContentPage
    {
        string finalSelectedIcon;
        public NewNotePage()
        {
            InitializeComponent();

            IconPicker.ItemsSource = IconModel.IconList;
        }

        async void AddNewReminder() 
        {
            await App.Database.CreateReminders(new Model.reminders
            {
                Title = title.Text,
                Icon = finalSelectedIcon,
                NoteContent = contentText.Text
            });
            await Navigation.PopAsync();
        }


        //The method below will save the data to our model
        async void ToolbarItemSubmit_Clicked(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(title.Text) || string.IsNullOrWhiteSpace(contentText.Text))
            {
                await DisplayAlert("Invalid", "Blank or Whitespace value is Invalid!", "OK");
            }
            else 
            {
                AddNewReminder();
            }

        }

        private void IconPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIcon = IconPicker.SelectedIndex;
            displayIcon.Source = IconModel.IconList[selectedIcon].IconPath;

            finalSelectedIcon = IconModel.IconList[selectedIcon].IconName;//To get the selected icon

        }
    }
}