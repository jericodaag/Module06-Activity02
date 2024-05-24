using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App8
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonalInfoPage : ContentPage
    {
        public PersonalInfoPage()
        {
            InitializeComponent();
            MiddleNameEntry.IsEnabled = MNameSwitch.IsToggled;
            MNameSwitch.Toggled += (sender, e) =>
            {
                MiddleNameEntry.IsEnabled = e.Value;
            };
            BirthdatePicker.DateSelected += BirthdatePicker_DateSelected;
            PasswordEntry.IsPassword = true;
            RepeatPasswordEntry.IsPassword = true;
            SubmitButton.Clicked += SubmitButton_Clicked;
        }

        private void BirthdatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var today = DateTime.Today;
            var age = today.Year - e.NewDate.Year;
            if (e.NewDate.Date > today.AddYears(-age)) age--;
            AgeLabel.Text = $"Age: {age}";
        }

        private void SubmitButton_Clicked(object sender, EventArgs e)
        {

            DisplayAlert("Success", "Your information has been submitted.", "OK");
        }
    }
}
