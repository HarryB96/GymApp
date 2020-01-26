using System;
using System.Collections.Generic;
using Xamarin.Forms;
using GymApp.Models;
using System.Linq;

namespace GymApp.Pages
{
    public partial class ProgramPage : TabbedPage
    {
        public ProgramPage()
        {
            InitializeComponent();
            Initialise();
        }
        public async void Initialise()
        {
            List<Exercise> Program = await App.ExerciseRepo.GetProgramAsync();
            this.Children.Add(new DayPage(Program.Where(e => e.Day == "Legs")));
            this.Children.Add(new DayPage(Program.Where(e => e.Day == "Chest")));
            this.Children.Add(new DayPage(Program.Where(e => e.Day == "Back")));
            this.Children.Add(new DayPage(Program.Where(e => e.Day == "Shoulders")));
        }
    }
}
