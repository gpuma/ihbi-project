using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using ihbiproject.ViewModels;

namespace ihbiproject.Views
{
    public partial class WellnessView : ContentPage
    {
		
        double stepValue = 1.0;
        public WellnessViewModel vm { get { return (WellnessViewModel)BindingContext; } }
        public WellnessView()
        {
            InitializeComponent();
			this.Title = "Wellness";
            BindingContext = new WellnessViewModel();
            AddMoodOptions();
        }

        void OnSldSleepValueChanged(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue);
            vm.SleepHours = newStep * stepValue;
            //the following line makes it so the step changes are not smooth on the UI
            //sldSleep.Value = vm.SleepHours;
            lblSleep.Text = String.Format("slept {0} hours", vm.SleepHours);
        }

        void AddMoodOptions()
        {
            //hardcoded to be 3x3
            int rows = 3;
            int cols = 3;
            //we get all the filenames to prepare to display the images
            var filenames = new List<string>(vm.moods.Keys);

            //images cannot handle taps out of the box
            var tapRecognizer = new TapGestureRecognizer();
            //tapRecognizer.NumberOfTapsRequired = 1;
            tapRecognizer.Tapped += OnTapGestureRecognizerTapped;

            //to iterate through every image
            int k = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++, k++)
                {
                    var moodImg = new Image { Source = filenames[k], Opacity = CONST.DEFAULT_OPACITY };
                    moodImg.GestureRecognizers.Add(tapRecognizer);
                    grdMoods.Children.Add(moodImg, j, i);
                }
            }
        }

        void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {
            //todo: display value of face selected
            var moodCells = grdMoods.Children;
            foreach (Image cell in moodCells)
            {
                cell.Opacity = 1;
            }
            foreach (Image cell in moodCells)
            {
                if (cell != sender)
                {
                    cell.Opacity = CONST.DEFAULT_OPACITY;
                    continue;
                }
                //fuck you xamarin
                var filename = (cell.Source as FileImageSource).File;
                //todo: property change in viewmodel should trigger change in view. it doesn't.
                vm.SelectedMood = vm.moods[filename];
                lblMood.Text = vm.SelectedMood;
            }
        }
    }
}
