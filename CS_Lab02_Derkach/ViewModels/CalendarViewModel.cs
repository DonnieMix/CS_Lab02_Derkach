using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using CS_Lab02_Derkach.Views;
using CS_Lab02_Derkach.Models;

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
            Person person = new Person(View.TbLastname.Text, View.TbSurname.Text, View.TbEmail.Text, View.DpBirthday.SelectedDate.Value);
            var isBirthdayTask = Task.Run(() => person.IsBirthday);
            var isAdultTask = Task.Run(() => person.IsAdult);
            var sunSignTask = Task.Run(() => person.SunSign);
            var chineseSignTask = Task.Run(() => person.ChineseSign);
            MessageBox.Show($"Lastname: {person.Lastname}\n" +
                $"Surname: {person.Surname}\n" +
                $"Email: {person.Email}\n" +
                $"Date of birth: {person.Birthday.Value.Day}.{person.Birthday.Value.Month}.{person.Birthday.Value.Year}\n" +
                $"{((await isAdultTask)?"Adult":"Is not adult")}\n" +
                $"Sun sign: {await sunSignTask}\n" +
                $"Chinese sign: {await chineseSignTask}\n" +
                $"{((await isBirthdayTask) ? "Birthday today" : "No birthday today")}\n", "Info about person");
        }
    }
}
