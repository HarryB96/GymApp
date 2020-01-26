using System;
using System.Collections.Generic;
using System.Linq;
using GymApp.Models;

using Xamarin.Forms;

namespace GymApp.Pages
{
    public partial class DayPage : ContentPage
    {
        IEnumerable<Exercise> Exercises = new List<Exercise>();
        public DayPage(IEnumerable<Exercise> exercises)
        {
            InitializeComponent();
            this.Exercises = exercises;
            this.Title = exercises.First().Day;
        }
        public void Initialise()
        {
            ProgramList.ItemsSource = Exercises.OrderBy(e => e.ExerciseId);
        }
        async void ProgramList_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var item = e.Item as Exercise;
            await Navigation.PushAsync(new ProgramDetailsPage(item));
        }
        protected override void OnAppearing()
        {
            Initialise();
            base.OnAppearing();
        }
    }
}
