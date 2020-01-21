using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace GymApp.Pages
{
    public partial class StopwatchPage : ContentPage
    {
        public static Stopwatch s = new Stopwatch();
        public StopwatchPage()
        {
            InitializeComponent();
            Output.Text = "00:00:00.00";
        }
        private void StartButton_Clicked(object sender, EventArgs e)
        {
            //Timer to update the screen when the stopwatch ticks
            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            {
                TimeSpan ts = s.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                Output.Text = elapsedTime;
                return true;
            });

            //If and else statement to change the start button from start to stop
            if (StartButton.Text == "Start")
            {
                s.Start();
                StartButton.Text = "Stop";
                ResetButton.IsEnabled = false;
            }
            else
            {
                StartButton.Text = "Start";
                s.Stop();
                ResetButton.IsEnabled = true;
            }
        }

        //Button click event to reset the stopwatch
        private void ResetButton_Clicked(object sender, EventArgs e)
        {
            s.Reset();
            ResetButton.IsEnabled = false;
        }

    }
}
