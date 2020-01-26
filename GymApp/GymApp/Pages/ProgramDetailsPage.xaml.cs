using System;
using System.Collections.Generic;
using GymApp.Models;

using Xamarin.Forms;

namespace GymApp.Pages
{
    public partial class ProgramDetailsPage : ContentPage
    {
        static Exercise thisExercise;
        public ProgramDetailsPage(Exercise exercise)
        {
            InitializeComponent();
            Title = exercise.ExerciseName;
            PreviousEditor.Text = exercise.Weight.ToString();
            thisExercise = exercise;
        }

        void AchievedEditor_TextChanged(System.Object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            Save.IsEnabled = true;
        }

        async void Save_Clicked(System.Object sender, System.EventArgs e)
        {

            double.TryParse(AchievedEditor.Text, out double achievedWeight);
            thisExercise.Weight = achievedWeight;
            await App.ExerciseRepo.EditExerciseAsync(thisExercise);
            await DisplayAlert("Saved", "Weight achieved for this session has been saved", "OK");
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
