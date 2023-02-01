using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace paternMVVC
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
       
        public List<string> ComboChange // свойство для заполнения Combobox
        {
            get
            {
                return Model.dataList;
            }
        }
        public string CountChange // свойство для отображения числа в TextBlock
        {
            get
            {
                return Model.count.ToString();
            }
        }
        double firstNum = 0;
        double secondNum = 0;
        public double TBFirst
        {
            set
            {
                // индек - это необходимое значение, которое нужно получить
                firstNum = value;
            // событие, которое реагирует на изменение свойства
            }
        }
        public double TBSecond
        {
            set
            {
                // индек - это необходимое значение, которое нужно получить
                secondNum = value;
                 // событие, которое реагирует на изменение свойства
            }
        }

        int cbIndex = -1;
        public int IndexSelected // свойство для нахождения индекса выбранного в Combobox элемента
        {
            set
            {
                // индек - это необходимое значение, которое нужно получить
                cbIndex = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CBIndex"));  // событие, которое реагирует на изменение свойства
            }
        }
        public string CBIndex // свойство для отображения фамилии в Combobox
        {
            get
            {
                if (cbIndex == -1)
                {
                    return "";
                }
                else
                {
                    return Model.dataZnak[cbIndex];
                }

            }
        }
        public RoutedCommand Command { get; set; } = new RoutedCommand();
        public CommandBinding bind;
        private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789,".IndexOf(e.Text) < 0;

        }
        public void Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {

            switch (cbIndex)
            {
                case 0:
                    Model.count = firstNum + secondNum;
                   
                    break;
                case 1:
                    Model.count = firstNum - secondNum;
                    break;
                case 2:
                   
                    if(secondNum== 0 | firstNum==0)
                    {
                        MessageBox.Show("Делить на 0 нельзя!");
                    }
                    else Model.count = firstNum / secondNum;

                    break;
                case 3:
                    Model.count = firstNum * secondNum;
                    break;
            }
            

            PropertyChanged(this, new PropertyChangedEventArgs("CountChange"));
        }
        public ViewModel()
        {
            bind = new CommandBinding(Command);  // инициализация объекта для привязки данных
            bind.Executed += Command_Executed;
            // добавление обработчика событий
        }
    }
}
