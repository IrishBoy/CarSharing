using CarSharing.Core;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarSharing.GraphUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository _repo = new Repository();
        //private CommonComponent _counterComponent = new CommonComponent();

        public MainWindow()
        {
            InitializeComponent();
            listBoxCars.ItemsSource = _repo.Cars;
            modelsDataGrid.ItemsSource = _repo.Models;
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.userEntered += RegisterUser;
            registrationWindow.Show();

           // _counterComponent.CounterChanged += IncreseCounter;

           // var buttonWindow = new ButtonWindow(_counterComponent);
          //  buttonWindow.Show();

        }
        public void UserWelcome(string name)
        {
            welcomeTextBlock.Text = $"Добро пожаловать, {name}";
        }
        public void RegisterUser(string name, string phoneNumber, string login, string password)
        {
            _repo.AddUser(name, phoneNumber, login, password);
            UserWelcome(name);
        }
        //public void IncreseCounter(int counter)
       // {
        //    textBlockCount.Text = counter.ToString();
        //}
    }
}
