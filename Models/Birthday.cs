using System;

namespace Lab1Prokopchuk.Models
{
    class Birthday
    {
        #region Fields
        private DateTime _birthday;
        private readonly string[] zodiacSignsChinese =
        { "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox", "Tiger",
          "Rabbit", "Dragon", "Snake", "Horse", "Sheep",
        };

        private readonly string[] zodiacSignsBasic =
        { "Capricorn", "Aquarius", "Pisces", "Aries", "Taurus", "Gemini", "Cancer",
          "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius",
        };

        #endregion

        #region DataBDay
        public DateTime Date
        {
            get { return _birthday; }
            set { _birthday = value; }
        }
        #endregion

        public int CountUserAge()
        {
            var currentDay = DateTime.Today;
            var userAge = currentDay.Year - _birthday.Year;
            userAge = _birthday.Date > currentDay.AddYears(userAge * -1) ? userAge - 1 : userAge;
            return userAge;
        }

        public Boolean CheckIfValidBD()
        {
            var userAge = CountUserAge();
            if (userAge < 0)
                return false;
            if (userAge > 135)
                return false;
            return true;
        }
        public Boolean CheckIfBDToday()
        {
            return _birthday.Date == DateTime.Today.Date;
        }

        public string ZodiacChinese()
        {
            var bdayYear = _birthday.Year;
            return zodiacSignsChinese[bdayYear % 12];
        }

        public string ZodiacBasic()
        {
            var bdayMonth = _birthday.Month;
            var bdayDay = _birthday.Day;

            if (bdayMonth == 1)
                return bdayDay < 20 ? zodiacSignsBasic[0] : zodiacSignsBasic[1];

            else if (bdayMonth == 2)
                return bdayDay < 19 ? zodiacSignsBasic[1] : zodiacSignsBasic[2];

            else if (bdayMonth == 3)
                return bdayDay < 21 ? zodiacSignsBasic[2] : zodiacSignsBasic[3];

            else if (bdayMonth == 4)
                return bdayDay < 20 ? zodiacSignsBasic[3] : zodiacSignsBasic[4];

            else if (bdayMonth == 5)
                return bdayDay < 21 ? zodiacSignsBasic[4] : zodiacSignsBasic[5];

            else if (bdayMonth == 6)
                return bdayDay < 21 ? zodiacSignsBasic[5] : zodiacSignsBasic[6];

            else if (bdayMonth == 7)
                return bdayDay < 23 ? zodiacSignsBasic[6] : zodiacSignsBasic[7];

            else if (bdayMonth == 8)
                return bdayDay < 23 ? zodiacSignsBasic[7] : zodiacSignsBasic[8];

            else if (bdayMonth == 9)
                return bdayDay < 23 ? zodiacSignsBasic[8] : zodiacSignsBasic[9];

            else if (bdayMonth == 10)
                return bdayDay < 23 ? zodiacSignsBasic[9] : zodiacSignsBasic[10];

            else if (bdayMonth == 11)
                return bdayDay < 22 ? zodiacSignsBasic[10] : zodiacSignsBasic[11];

            else if (bdayMonth == 12)
                return bdayDay < 22 ? zodiacSignsBasic[11] : zodiacSignsBasic[0];

            else
                return "Error";
        }
    }
}
