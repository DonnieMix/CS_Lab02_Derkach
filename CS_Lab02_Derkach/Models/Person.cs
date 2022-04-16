using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Lab02_Derkach.Models
{
    internal class Person
    {
        private string _lastname;
        private string _surname;
        private string? _email;
        private DateTime? _birthday;

        public string Lastname { get => _lastname; set => _lastname = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public string? Email { get => _email; set => _email = value; }
        public DateTime? Birthday { get => _birthday; set => _birthday = value; }
        public bool IsAdult { get => (Birthday.Value.AddYears(18).CompareTo(DateTime.Now) <= 0); }
        public string SunSign {
            get
            {
                switch (Birthday.Value.Month)
                {
                    case 1: return (Birthday.Value.Day <= 20) ? "Capricorn" : "Aquarius"; break;
                    case 2: return (Birthday.Value.Day <= 19) ? "Aquarius" : "Pisces"; break;
                    case 3: return (Birthday.Value.Day <= 20) ? "Pisces" : "Aries"; break;
                    case 4: return (Birthday.Value.Day <= 20) ? "Aries" : "Taurus"; break;
                    case 5: return (Birthday.Value.Day <= 21) ? "Taurus" : "Gemini"; break;
                    case 6: return (Birthday.Value.Day <= 21) ? "Gemini" : "Cancer"; break;
                    case 7: return (Birthday.Value.Day <= 22) ? "Cancer" : "Leo"; break;
                    case 8: return (Birthday.Value.Day <= 23) ? "Leo" : "Virgo"; break;
                    case 9: return (Birthday.Value.Day <= 23) ? "Virgo" : "Libra"; break;
                    case 10: return (Birthday.Value.Day <= 23) ? "Libra" : "Scorpio"; break;
                    case 11: return (Birthday.Value.Day <= 22) ? "Scorpio" : "Sagittarius"; break;
                    case 12: return (Birthday.Value.Day <= 23) ? "Sagittarius" : "Capricorn"; break;
                    default: return "How did you even get this case?";
                }
            } }
        public string ChineseSign
        {
            get
            {
                switch (Birthday.Value.Year % 12)
                {
                    case 0: return "Monkey"; break;
                    case 1: return "Rooster"; break;
                    case 2: return "Dog"; break;
                    case 3: return "Pig"; break;
                    case 4: return "Rat"; break;
                    case 5: return "Bull"; break;
                    case 6: return "Tiger"; break;
                    case 7: return "Rabbit"; break;
                    case 8: return "Dragon"; break;
                    case 9: return "Snake"; break;
                    case 10: return "Horse"; break;
                    case 11: return "Goat"; break;
                    default: return "Another unreachable return";
                }
            } }

        public bool IsBirthday { get => (DateTimeOffset.Now.Day == Birthday.Value.Day) && (DateTimeOffset.Now.Month == Birthday.Value.Month); }
        public Person(string lastname, string surname, string email, DateTime birthday)
        {
            Lastname = lastname;
            Surname = surname;
            Email = email;
            Birthday = birthday;
        }
        public Person(string lastname, string surname, string email)
        {
            Lastname = lastname;
            Surname = surname;
            Email = email;
        }
        public Person(string lastname, string surname, DateTime birthday)
        {
            Lastname = lastname;
            Surname = surname;
            Birthday = birthday;
        }
    }
}
