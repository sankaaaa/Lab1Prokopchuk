using Lab1Prokopchuk.Models;
using Lab1Prokopchuk.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab1Prokopchuk.ViewModels
{
    class BirthdayViewModel : INotifyPropertyChanged
    {
        #region Fields
        private Birthday _birthday = new Birthday();
        private RelayCommand<object> _informationAboutBirthdayCommand;
        public event PropertyChangedEventHandler? PropertyChanged;
        private string _age;
        private string _chineseZodiac;
        private string _basicZodiac;
        #endregion

        

        #region Properties
        public DateTime UpdateDate 
        {
            get {return _birthday.Date; }
            set {_birthday.Date = value; } 
        }

       
        public RelayCommand<object> InformationCommand
        {
            get
            {
                return _informationAboutBirthdayCommand ??= new RelayCommand<object>(_ => ChooseDate(), CanExecute);
            }
        }

        public string Age
        {
            get { return _age; }
            set 
            {
                _age = value;
                OnPropertyChanged("Age");
            }
        }

        public string ChineseZodiac
        {
            get
            {
                return _chineseZodiac;
            }
            set
            {
                _chineseZodiac = value;
                OnPropertyChanged("ChineseZodiac");
            }
        }

        public string BasicZodiac
        {
            get
            {
                return _basicZodiac;
            }
            set
            {
                _basicZodiac= value;
                OnPropertyChanged("BasicZodiac");
            }
        }
        #endregion

        public void ChooseDate()
        {
            if (_birthday.CheckIfValidBD())
            {
                var countedAge = _birthday.CountUserAge();
                if (_birthday.CheckIfBDToday())
                {
                    Age = $"Congratulations! Your birthday is today! \nYour current age is: {countedAge}";
                }
                else
                {
                    Age = $"Your current age is: {countedAge}";
                }
                ChineseZodiac = $"Chinese zodiac sign: {_birthday.ZodiacChinese()}";
                BasicZodiac = $"Basic zodiac sign: {_birthday.ZodiacBasic()}";
            }
            else
            {
                InvalidBDay();
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private bool CanExecute(object obj)
        {
            return _birthday != null;
        }

        private void InvalidBDay()
        {
            Age = "";
            BasicZodiac = "";
            ChineseZodiac = "";
            MessageBox.Show("idinaxui invalid! Try again!");
        }
    }
}
