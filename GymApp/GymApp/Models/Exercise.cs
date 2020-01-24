using System;
namespace GymApp.Models
{
    public class Exercise
    {
        public Exercise()
        {
        }

        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public double? Weight { get; set; }
        public string Superset { get; set; }
        public string Day { get; set; }
    }
}
