using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ЛР1_ЭСвЭ_3е.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private double? _weight; // Вес
        private double? _height; // Рост
        private int _excessWeight; // Избыток веса
        private int _gender; // Пол
        private double? _cigarettes; // Пачек сигарет в день
        private double? _alcohol; // Грамм алкоголя
        private bool _chestPain;
        private bool _backPain;
        private string _result;

        public event PropertyChangedEventHandler PropertyChanged;

        public double? Weight
        {
            get => _weight;
            set
            {
                if (value != null)
                {
                    _weight = value;
                    CalculateExcessWeight();
                    CalculateScore();
                    OnPropertyChanged();
                }
            }
        }
        public double? Height
        {
            get => _height;
            set
            {
                if (value != null)
                {
                    _height = value;
                    CalculateExcessWeight();
                    CalculateScore();
                    OnPropertyChanged();
                }
            }
        }
        public int ExcessWeight
        {
            get => _excessWeight;
            set
            {
                _excessWeight = value;
                OnPropertyChanged();
            }
        }
        public int Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                CalculateScore();
                OnPropertyChanged();
            }
        }
        public double? Cigarettes
        {
            get => _cigarettes;
            set
            {
                if (value != null)
                {
                    _cigarettes = value;
                    CalculateScore();
                    OnPropertyChanged();
                }
            }
        }
        public double? Alcohol
        {
            get => _alcohol;
            set
            {
                if (value != null)
                {
                    _alcohol = value;
                    CalculateScore();
                    OnPropertyChanged();
                }
            }
        }
        public bool ChestPain
        {
            get => _chestPain;
            set
            {
                _chestPain = value;
                CalculateScore();
                OnPropertyChanged();
            }
        }
        public bool BackPain
        {
            get => _backPain;
            set
            {
                _backPain = value;
                CalculateScore();
                OnPropertyChanged();
            }
        }

        public string Result
        {
            get => _result;
            private set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel(){
            ExcessWeight = 0;
            CalculateScore();
        }

        public void CalculateExcessWeight() => ExcessWeight = (Weight > (Height - 100)) ? (int)(Weight - Height + 100) : 0;
        private void CalculateScore()
        {
            int score = 0;

            if (Gender == 0) score += 3;
            if (Weight > (Height - 100)) score += Math.Min(10, (int)(Weight - Height + 100) / 10);
            if (Cigarettes > 0)score += Math.Min(5, (int)(Cigarettes / 0.5));
            if (Alcohol > 0) score += Math.Min(5, (int)(Alcohol / 100));
            if (ChestPain) score += 5;
            if (BackPain) score += 5;

            int percent = score * 100 / 33;

            Result = (percent <= 33 ? "Низкая вероятность инфаркта: " : percent <= 65 ? "Средняя вероятность инфаркта: " : "Высокая вероятность инфаркта: ") + percent + "%";
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
