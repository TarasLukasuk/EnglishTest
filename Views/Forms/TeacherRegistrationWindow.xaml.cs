using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace EnglishTest.Views.Forms
{
    public partial class TeacherRegistrationWindow : Window
    {
        public TeacherRegistrationWindow()
        {
            InitializeComponent();
        }

        private void PasswordBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string password = EnterPassword.Text;
            string rePassword = ReEnterPassword.Text;

            int strength = CalculatePasswordStrength(password, rePassword);

            AnimateProgressBar(strength);

            PasswordStrengthBar.Value = strength;

            if (PasswordStrengthBar.Template.FindName("PART_Indicator", PasswordStrengthBar) is Rectangle indicator)
            {
                GradientStopCollection gradient = new();

                if (strength < 40)
                {
                    gradient.Add(new GradientStop(Colors.Red, 0.0));
                    gradient.Add(new GradientStop(Colors.OrangeRed, 1.0));
                }
                else if (strength < 70)
                {
                    gradient.Add(new GradientStop(Colors.Orange, 0.0));
                    gradient.Add(new GradientStop(Colors.Yellow, 1.0));
                }
                else
                {
                    gradient.Add(new GradientStop(Colors.LimeGreen, 0.0));
                    gradient.Add(new GradientStop(Colors.Green, 1.0));
                }

                indicator.Fill = new LinearGradientBrush(gradient, new Point(0, 0), new Point(1, 0));
            }
        }

        private void AnimateProgressBar(int newValue)
        {
            DoubleAnimation animation = new()
            {
                To = newValue,
                Duration = TimeSpan.FromMilliseconds(400),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };

            PasswordStrengthBar.BeginAnimation(ProgressBar.ValueProperty, animation);
        }

        private int CalculatePasswordStrength(string password, string rePassword)
        {
            int score = 0;

            if (string.IsNullOrEmpty(password))
                return 0;

            if (password.Length >= 8)
                score += 20;

            if (Regex.IsMatch(password, @"[a-z]"))
                score += 15;
            if (Regex.IsMatch(password, @"[A-Z]")) 
                score += 15;
            if (Regex.IsMatch(password, @"\d"))    
                score += 15;
            if (Regex.IsMatch(password, @"[\W_]"))
                score += 15;

            if (password == rePassword && !string.IsNullOrEmpty(rePassword))
                score += 20;

            return Math.Min(score, 100); 
        }
    }
}
