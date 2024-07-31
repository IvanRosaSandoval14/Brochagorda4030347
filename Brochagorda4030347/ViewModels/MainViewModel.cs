using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Brochagorda4030347.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _result;
        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Result)));
            }
        }

        private string _area;
        public string Area
        {
            get { return _area; }
            set
            {
                _area = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Area)));
            }
        }

        private string _costPerSquareMeter;
        public string CostPerSquareMeter
        {
            get { return _costPerSquareMeter; }
            set
            {
                _costPerSquareMeter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CostPerSquareMeter)));
            }
        }

        public ICommand CalculateBudgetCommand => new Command(() =>
        {
            if (double.TryParse(Area, out double area) && double.TryParse(CostPerSquareMeter, out double cost))
            {
                double budget = area * cost;
                Result = $"Presupuesto: {budget:C}";
                Application.Current.MainPage.Navigation.PushAsync(new ResultPage(budget));
            }
            else
            {
                Result = "Por favor ingrese números válidos.";
            }
        });

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
