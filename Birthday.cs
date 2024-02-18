using System;

namespace Lab1Prokopchuk
{
	class Birthday
	{
        #region DataBDay
        public DateTime Date
        {
            get { return _birthday; }
            set { _birthday = value; }
        }
        #endregion

        #region Fields
        private DateTime _birthday;
        private readonly string[] zodiacSignsChinese = 
        { "rooster", "dog", "pig", "rat", "ox", "tiger", 
          "rabbit", "dragon", "snake", "horse", "sheep", 
          "monkey" 
        };
        #endregion

        public int CountUserAge()
        {
            var currentDay = DateTime.Today;
            var userAge = currentDay.Year - _birthday.Year;
            userAge = _birthday.Date > currentDay.AddYears(userAge * -1) ? userAge-1 : userAge;
            return userAge;
        }

        public Boolean CheckIfValidBD()
        {
            var userAge = CountUserAge();
            if(userAge < 0) 
                return false;
            if(userAge > 135)
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
            var bdayMonth  = _birthday.Month;
            var bdayDay = _birthday.Day;

            if (bdayMonth == 1)
                return bdayDay < 20 ? "Capricorn" : "Aquarius";

            else if (bdayMonth == 2)
                return bdayDay < 19 ? "Aquarius" : "Pisces";

            else if (bdayMonth == 3)
                return bdayDay < 21 ? "Pisces" : "Aries";

            else if (bdayMonth == 4)
                return bdayDay < 20 ? "Aries" : "Taurus";

            else if (bdayMonth == 5)
                return bdayDay < 21 ? "Taurus" : "Gemini";

            else if (bdayMonth == 6)
                return bdayDay < 21 ? "Gemini" : "Cancer";

            else if (bdayMonth == 7)
                return bdayDay < 23 ? "Cancer" : "Leo";

            else if (bdayMonth == 8)
                return bdayDay < 23 ? "Leo" : "Virgo";

            else if (bdayMonth == 9)
                return bdayDay < 23 ? "Virgo" : "Libra";

            else if (bdayMonth == 10)
                return bdayDay < 23 ? "Libra" : "Scorpio";

            else if (bdayMonth == 11)
                return bdayDay < 22 ? "Scorpio" : "Sagittarius";

            else if (bdayMonth == 12)
                return bdayDay < 22 ? "Sagittarius" : "Capricorn";

            else 
                return "Error";
        }
    }
}
