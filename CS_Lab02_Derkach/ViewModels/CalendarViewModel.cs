using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using CS_Lab02_Derkach.Views;
using CS_Lab02_Derkach.Models;
using CS_Lab02_Derkach.Models.InputExceptions;

namespace CS_Lab02_Derkach.ViewModels
{
    class CalendarViewModel
    {
        private readonly CalendarView _view;

        public CalendarView View { get => _view; }
        public CalendarViewModel(CalendarView view)
        {
            this._view = view;
        }

        public async void BProceed_Click(object sender, EventArgs e)
        {
            try
            {
                Person person = new Person(View.TbLastname.Text, View.TbSurname.Text, View.TbEmail.Text, View.DpBirthday.SelectedDate.Value);
                person.validate();
                var isBirthdayTask = Task.Run(() => person.IsBirthday);
                var isAdultTask = Task.Run(() => person.IsAdult);
                var sunSignTask = Task.Run(() => person.SunSign);
                var chineseSignTask = Task.Run(() => person.ChineseSign);
                MessageBox.Show($"Lastname: {person.Lastname}\n" +
                    $"Surname: {person.Surname}\n" +
                    $"Email: {person.Email}\n" +
                    $"Date of birth: {person.Birthday.Value.Day}.{person.Birthday.Value.Month}.{person.Birthday.Value.Year}\n" +
                    $"{((await isAdultTask) ? "Adult" : "Is not adult")}\n" +
                    $"Sun sign: {await sunSignTask}\n" +
                    $"Chinese sign: {await chineseSignTask}\n" +
                    $"{((await isBirthdayTask) ? "Birthday today" : "No birthday today")}\n", "Info about person");
            }
            catch (ImpossibleAgeException)
            {
                MessageBox.Show("Age of person is too big!", "ErrorMessage",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            catch (FutureBirthdayException)
            {
                MessageBox.Show("Person hasn't even born yet!", "ErrorMessage",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            catch (InvalidEmailException)
            {
                MessageBox.Show("Given the wrong email address!", "ErrorMessage",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            catch (InvalidLastnameException)
            {
                MessageBox.Show("Invalid lastname!", "ErrorMessage",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            catch (InvalidSurnameException)
            {
                MessageBox.Show("Invalid surname!", "ErrorMessage",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            catch(CapitalLastnameException)
            {
                MessageBox.Show("Lastname should start with capital letter,\nfollowing with lowercase letters", "ErrorMessage",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            catch(CapitalSurnameException)
            {
                MessageBox.Show("Surname should start with capital letter,\nfollowing with lowercase letters", "ErrorMessage",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
}
