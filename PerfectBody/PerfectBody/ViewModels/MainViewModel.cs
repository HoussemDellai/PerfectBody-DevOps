using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Azure.Mobile.Analytics;
using Xamarin.Forms;

namespace PerfectBody.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private double _bmi;
        private string _category;

        /// <summary>
        /// Unit in Kg.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Unit in meter.
        /// </summary>
        public double Height { get; set; }

        public double Bmi
        {
            get => _bmi;
            set
            {
                _bmi = value;
                OnPropertyChanged();
            }
        }

        public string Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged();
            }
        }

        public ICommand CalculateImcCommand
        {
            get
            {
                return new Command(() =>
                {
                    Bmi = Weight / Math.Pow(Height, 2);

                    if (Bmi <= 18.5)
                        Category = "Underweight";
                    else if (18.5 <= Bmi && Bmi < 25)
                        Category = "Normal weight";
                    else if (25 <= Bmi && Bmi < 30)
                        Category = "Overweight";
                    else if (30 <= Bmi)
                        Category = "Obesity";

                    Analytics.TrackEvent("Bmi button clicked", new Dictionary<string, string> {
                        { "Weight", Weight.ToString() },
                        { "Height", Height.ToString() },
                        { "BMI", Bmi.ToString() },
                        { "Category", Category },
                    });
                });
            }
        }

        public MainViewModel()
        {
            Height = 1.8;
            Weight = 66;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
