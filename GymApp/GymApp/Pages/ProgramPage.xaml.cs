using System;
using System.Collections.Generic;
using Xamarin.Forms;
using GymApp.Models;

namespace GymApp.Pages
{
    public partial class ProgramPage : ContentPage
    {
        public ProgramPage()
        {
            InitializeComponent();
            Initialise();
        }
        public async void Initialise()
        {
            List<Exercise> Program = await App.ExerciseRepo.GetProgramAsync();
            ProgramList.ItemsSource = Program;
        }
    }
}
