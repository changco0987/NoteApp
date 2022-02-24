using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using NoteApp.Model;

namespace NoteApp
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            notesListView.ItemsSource = reminders.reminderList;

        }

        protected override async void OnAppearing() 
        {
            try 
            {
                base.OnAppearing();
                notesListView.ItemsSource = await App.Database.ReadReminders();
            }
            catch{ }
        }

        //This method is for Add button in toolbar
        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewNotePage());//This function will open and prompt to a new app page
        }

        //Method for exit button
        private void ToolbarItem_Clicked_2(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //This will ignore the letter case in search 
            notesListView.ItemsSource = await App.Database.Search(e.NewTextValue);
        }

        //This is the function when user tapped the note
        private async void notesListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {




            var Reminders = e.Item as reminders;//This will hold the current selected data


            await Navigation.PushAsync(new EditNotePage(Reminders));//This will open and prompt a new page
        }

        private void notesListView_Refreshing(object sender, EventArgs e)
        {
            notesListView.ItemsSource = null;
            notesListView.ItemsSource = reminders.reminderList;
            notesListView.EndRefresh();

        }

        //This is the swipe view delete function
        private async void SwipeItemDelete_Invoked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var selectedNote = menuItem.CommandParameter as reminders;

            var result = await DisplayAlert("Delete ",$"Delete { selectedNote.Title} from the database","Yes","No");

            if (result) 
            {
                await App.Database.DeleteReminders(selectedNote);
                notesListView.ItemsSource = await App.Database.ReadReminders();
            }


        }
    }
}
