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

namespace WPFInteractiveGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller controller;
        public MainWindow()
        {
            InitializeComponent();
            controller = new Controller();
        }

        private void NewPerson_Click(object sender, RoutedEventArgs e)
        {
            Controller controller = new Controller();
            controller.AddPerson();
            DeletePerson.IsEnabled = true;
            Up.IsEnabled = true;
            Down.IsEnabled = true;
            FirstName.IsEnabled = true;
            LastName.IsEnabled = true;
            Age.IsEnabled = true;
            TelephoneNo.IsEnabled = true;
            personCountBlock.Text = $"Person count {controller.PersonCount.ToString()}";
            IndexBlock.Text = controller.PersonIndex.ToString();

        }

        private void FirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            controller.CurrentPerson.FirstName = FirstName.Text;
        }

        private void LastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            controller.CurrentPerson.LastName = LastName.Text;
        }

        private void Age_TextChanged(object sender, TextChangedEventArgs e)
        {
            controller.CurrentPerson.Age = int.Parse(Age.Text);

        }

        private void TelephoneNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            controller.CurrentPerson.TelephoneNo = TelephoneNo.Text;
        }

        private void DeletePerson_Click(object sender, RoutedEventArgs e)
        {
            controller.DeletePerson();
            if (controller.PersonCount < 1)
            {
                DeletePerson.IsEnabled = false;
                Up.IsEnabled = false;
                Down.IsEnabled = false;
                FirstName.IsEnabled = false;
                LastName.IsEnabled = false;
                Age.IsEnabled = false;
                TelephoneNo.IsEnabled = false;
            }
            IndexBlock.Text = controller.PersonIndex.ToString();
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            controller.NextPerson();
            FirstName.Text = controller.CurrentPerson.FirstName;
            LastName.Text = controller.CurrentPerson.LastName;
            Age.Text = controller.CurrentPerson.Age.ToString();
            TelephoneNo.Text = controller.CurrentPerson.TelephoneNo;
            IndexBlock.Text = controller.PersonIndex.ToString();
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            controller.PrevPerson();
            FirstName.Text = controller.CurrentPerson.FirstName;
            LastName.Text = controller.CurrentPerson.LastName;
            Age.Text = controller.CurrentPerson.Age.ToString();
            TelephoneNo.Text = controller.CurrentPerson.TelephoneNo;
            IndexBlock.Text = controller.PersonIndex.ToString();
        }
    }
}
