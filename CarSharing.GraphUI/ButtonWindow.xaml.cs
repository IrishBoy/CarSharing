using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarSharing.GraphUI
{
    /// <summary>
    /// Логика взаимодействия для ButtonWindow.xaml
    /// </summary>
    public partial class ButtonWindow : Window
    {
        CommonComponent _counterComponent;

        public ButtonWindow(CommonComponent counterComponent)
        {
            InitializeComponent();
            _counterComponent = counterComponent;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _counterComponent.IncreseCounter();
        }
    }
}
