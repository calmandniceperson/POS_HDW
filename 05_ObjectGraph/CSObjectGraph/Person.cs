using System;
using System.Text;

namespace ConsoleApplication
{
    public class Person
    {
        public int ID { get; set; }
        
        public enum PersonGender
        {
            Male,
            Female
        }
        public PersonGender Gender { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        
        private enum PersonZodiac
        {
            Aries,
            Taurus,
            Gemini,
            Cancer,
            Leo,
            Virgo,
            Libra,
            Scorpio,
            Sagittarius,
            Capricorn,
            Aquarius,
            Pisces
        }
        private PersonZodiac Zodiac { get; set; }
        
        public Person(int id, PersonGender gender, string lastName,
                      string firstName, DateTime birthDate)
        {
            ID = id;
            Gender = gender;
            LastName = lastName;
            FirstName = firstName;
            BirthDate = birthDate;
            Zodiac = PersonZodiac.Aquarius; /*calculate*/
        }
        
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"\tID: {ID}\n");
            sb.Append($"\tGender: {Gender}\t");
            sb.Append($"\tDate of birth: {BirthDate.ToString()}");
            sb.Append($"\tZodiac sign: {Zodiac.ToString()}");
            return sb.ToString();
        }
    }
}    