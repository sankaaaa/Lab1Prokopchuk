using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Lab1Prokopchuk.Models;

namespace Lab1Prokopchuk.ViewModels
{
    class BirthdayViewModel : INotifyPropertyChanged
    {
        #region Fields
        private Birthday _birthday = new Birthday();
        public event PropertyChangedEventHandler? PropertyChanged;
        private string _age;
        private string _chineseZodiac;
        private string _basicZodiac;
        #endregion

        #region Properties
        public DateTime UpdateDate
        {
            get { return _birthday.Date; }
            set { _birthday.Date = value; OnPropertyChanged(); }
        }

        public string Age
        {
            get { return _age; }
            set { _age = value; OnPropertyChanged(); }
        }

        public string ChineseZodiac
        {
            get { return _chineseZodiac; }
            set { _chineseZodiac = value; OnPropertyChanged(); }
        }

        public string BasicZodiac
        {
            get { return _basicZodiac; }
            set { _basicZodiac = value; OnPropertyChanged(); }
        }
        #endregion

        public void ChooseDate()
        {
            if (_birthday.CheckIfValidBD())
            {
                var countedAge = _birthday.CountUserAge();
                if (_birthday.CheckIfBDToday())
                    Age = $"Congratulations! Your birthday is today! \nYour current age is: {countedAge}";
                else
                    Age = $"Your current age is: {countedAge}";

                ChineseZodiac = $"Chinese zodiac sign: {_birthday.ZodiacChinese()}";
                BasicZodiac = $"Basic zodiac sign: {_birthday.ZodiacBasic()}";
            }
            else
                InvalidBDay();
        }

        private void InvalidBDay()
        {
            Age = "";
            BasicZodiac = "";
            ChineseZodiac = "";
            MessageBox.Show("Wrong data entered! Try again!");
        }

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

    }
}
