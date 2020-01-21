using System;
using SQLite;

namespace GymApp.Models
{
    [Table("OneRepMaxes")]
    public class OneRepMax
    {
        public OneRepMax()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ExerciseId { get; set; }
        [Unique]
        public string ExerciseName { get; set; }
        public double Weight { get; set; }
        public int Reps { get; set; }
        public double OneRep { get; set; }
    }
}