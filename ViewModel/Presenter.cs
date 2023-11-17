using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using WaterApp.Model;
using WaterApp.Service;

namespace WaterApp.ViewModel
{
    public class Presenter : ObservableObject
    {
        private const int _MaxWater = 1800;
        private int _remainingWater;
        private int _allWater;

        private string _textRemainingWater = "Допить до нормы:";

        private readonly TextConverter _textConverter
            = new TextConverter(int.Parse);

        private string _waterVolume;

        private static DBRepository _repository = new DBRepository();

        private ObservableCollection<History> _historys = new ObservableCollection<History>(_repository.GetHistorys());

        public ObservableCollection<History> Historys
        {
            get { return _historys; }
            set
            {
                _historys = value;
            }
        }

        public string WaterVolume
        {
            get { return _waterVolume; }
            set
            {
                _waterVolume = value;
                RaisePropertyChangedEvent("WaterVolume");
            }
        }

        public int MaxWater
        {
            get { return _MaxWater; }
        }

        public int AllWater
        {
            get { return SumOfWater(); }
            set
            {
                _allWater = value;
                RaisePropertyChangedEvent("AllWater");
            }
        }

        public int RemainingWater
        {
            get 
            {
                var res = _MaxWater - AllWater;
                if (res < 0)
                {
                    TextRemainingWater = "Выпито сверх нормы:";
                } else
                {
                    TextRemainingWater = "Допить до нормы:";
                }
                return res; 
            }
            set
            {
                _remainingWater = value;
                RaisePropertyChangedEvent("RemainingWater");
            }
        }

        public string TextRemainingWater
        {
            get { return _textRemainingWater; }
            set
            {
                _textRemainingWater = value;
                RaisePropertyChangedEvent("TextRemainingWater");
            }
        }

        public string CurrentDateUI 
        {
            get { return DateTime.Now.ToLongDateString(); }
        }

        public ICommand ConvertTextCommand
        {
            get { return new DelegateCommand<object>(ConvertText); }
        }

        public ICommand DeleteCommand
        {
            get { return new DelegateCommand<object>(Delete); }
        }

        private void ConvertText(object item)
        {
            if (string.IsNullOrWhiteSpace(WaterVolume))
            {
                return;
            }

            History newItem = new History()
            {
                CurrentDate = DateTime.Now.ToString(),
                Volume = _textConverter.ConvertText(WaterVolume)
            };
                
            AddToHistory(newItem);
            WaterVolume = string.Empty;
        }

        private void Delete(object item)
        {
            if (item == null) return;
            _repository.RemoveHistory((History)item);
            Historys.Remove((History)item);
            RaisePropertyChangedEvent("AllWater");
            RaisePropertyChangedEvent("RemainingWater");
        }

        private void AddToHistory(History item)
        {
            _repository.AddHistory(item);
            Historys.Add(item);
            RaisePropertyChangedEvent("AllWater");
            RaisePropertyChangedEvent("RemainingWater");
        }

        private int SumOfWater()
        {
            var result = Historys.Sum(h => h.Volume);
            return result;
        }
    }
}
