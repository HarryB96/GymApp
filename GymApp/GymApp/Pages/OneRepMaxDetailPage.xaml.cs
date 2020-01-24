using System;
using System.Collections.Generic;
using GymApp.Models;

using Xamarin.Forms;

namespace GymApp.Pages
{
    public partial class OneRepMaxDetailPage : ContentPage
    {
        public OneRepMaxDetailPage()
        {
            InitializeComponent();
        }
        OneRepMax thisExercise;
        public OneRepMaxDetailPage(OneRepMax oneRepMax)
        {
            InitializeComponent();
            Title = oneRepMax.ExerciseName;
            RepsEditor.Text = oneRepMax.Reps.ToString();
            WeightEditor.Text = oneRepMax.Weight.ToString();
            ORMOutPut.Text = oneRepMax.OneRep.ToString();
            thisExercise = oneRepMax;
        }
        

        async void EditButton_Clicked(System.Object sender, System.EventArgs e)
        {
            if (EditButton.Text == "Edit")
            {
                WeightEditor.IsReadOnly = false;
                RepsEditor.IsReadOnly = false;
                EditButton.Text = "Save";
            }
            else
            {
                int.TryParse(RepsEditor.Text, out int reps);
                thisExercise.Reps = reps;
                double.TryParse(WeightEditor.Text, out double weight);
                thisExercise.Weight = weight;
                double oneRepMax = Math.Round((weight * 36) / (37 - reps), 1);
                thisExercise.OneRep = oneRepMax;
                ORMOutPut.Text = oneRepMax.ToString();
                EditButton.Text = "Edit";
                WeightEditor.IsReadOnly = true;
                RepsEditor.IsReadOnly = true;
                await App.ORMRepo.EditORMAsync(thisExercise);
            }
        }

        async void DeleteButton_Clicked(System.Object sender, System.EventArgs e)
        {
            bool answer = await DisplayAlert("Delete?", "Are you sure?", "Yes", "No");
            if (answer)
            {
                await App.ORMRepo.RemoveORMAsync(thisExercise);
                await App.ORMRepo.GetOneRepMaxesAsync();
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}
