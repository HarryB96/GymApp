using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GymApp.Models;
using Xamarin.Forms;

namespace GymApp.Pages
{
    public partial class OneRepMaxPage : ContentPage
    {
        public OneRepMaxPage()
        {
            InitializeComponent();
            Initialise();
        }
        void ClaculateButton_Clicked(System.Object sender, System.EventArgs e)
        {
            double.TryParse(WeightEditor.Text, out double weight);
            int.TryParse(RepsEditor.Text, out int reps);
            double oneRepMax = Math.Round((weight * 36) / (37 - reps), 1);
            ORMEditor.Text = oneRepMax.ToString();
            ClearButton.IsEnabled = true;
        }
        private void Clear()
        {
            ORMEditor.Text = string.Empty;
            WeightEditor.Text = string.Empty;
            RepsEditor.Text = string.Empty;
            ClearButton.IsEnabled = false;
        }
        void ClearButton_Clicked(System.Object sender, System.EventArgs e)
        {
            Clear();
        }
        public async void Initialise()
        {
            exerciseEntry.Text = string.Empty;
            List<OneRepMax> oneRepMaxes = await App.ORMRepo.GetOneRepMaxesAsync();
            OneRepMaxList.ItemsSource = oneRepMaxes;
            Clear();
        }

        async void SaveButton_Clicked(System.Object sender, System.EventArgs e)
        {
            double.TryParse(WeightEditor.Text, out double weight);
            int.TryParse(RepsEditor.Text, out int reps);
            double oneRepMax = Math.Round((weight * 36) / (37 - reps), 1);
            await App.ORMRepo.AddNewORMAsync(exerciseEntry.Text, oneRepMax, weight, reps);
            await DisplayAlert("Added", "Your new one rep max has been added", "OK");
            Initialise();
        }

        async void OneRepMaxList_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var item = e.Item as OneRepMax;
            await Navigation.PushAsync(new OneRepMaxDetailPage(item), true);
        }
    }
}
