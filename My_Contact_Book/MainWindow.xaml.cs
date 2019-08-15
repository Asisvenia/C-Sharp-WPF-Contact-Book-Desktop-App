using My_Contact_Book.ViewModels;
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

namespace My_Contact_Book
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ContactsBtn_Click(this, null);
        }
        public static bool allowBG = false;

        private void addBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            addBtn.Content = FindResource("AddImgHover");
        }

        private void addBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            addBtn.Content = FindResource("AddImg");
        }

        private void EditBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            EditBtn.Content = FindResource("EditImgHover");
        }

        private void EditBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            EditBtn.Content = FindResource("EditImg");
        }

        private void RemoveBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            RemoveBtn.Content = FindResource("DeleteImgHover");
        }

        private void RemoveBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            RemoveBtn.Content = FindResource("DeleteImg");
        }

        public void ChangeBG()
        {
            ContactsBtn.Background = Brushes.LightGreen;
        }

        private void ContactsBtn_Click(object sender, RoutedEventArgs e)
        {
            ContactsBtn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#2C4B99"));
            ContactsBtn.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#DFE8D8"));
            FavsBtn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#3867d6"));
            FavsBtn.Foreground = Brushes.Wheat;
        }

        private void FavsBtn_Click(object sender, RoutedEventArgs e)
        {
            FavsBtn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#2C4B99"));
            FavsBtn.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#DFE8D8"));
            ContactsBtn.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#3867d6"));
            ContactsBtn.Foreground = Brushes.Wheat;
        }
    }
}
