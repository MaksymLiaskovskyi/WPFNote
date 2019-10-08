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
using WPFNote.Properties;

namespace WPFNote
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            #region задаю события фокуса textbox (визуал)
            regPassTextBox.GotFocus += TextBox_GotFocus;
            enterPassTextBox.GotFocus += TextBox_GotFocus;
            regLoginTextBox.GotFocus += TextBox_GotFocus;
            enterLoginTextBox.GotFocus += TextBox_GotFocus;

            regLoginTextBox.LostFocus += loginTextBox_LostFocus;
            enterLoginTextBox.LostFocus += loginTextBox_LostFocus;
            regPassTextBox.LostFocus += passTextBox_LostFocus;
            enterPassTextBox.LostFocus += passTextBox_LostFocus;
            #endregion

            #region события на наведения на текст вход/регистр курсора и их выбора
            enterAcc.MouseEnter += (s, a) => { enterAcc.Foreground = Brushes.Gray; };
            enterAcc.MouseLeave += (s, a) => { enterAcc.Foreground = Brushes.White; };
            regAcc.MouseEnter += (s, a) => { regAcc.Foreground = Brushes.Gray; };
            regAcc.MouseLeave += (s, a) => { regAcc.Foreground = Brushes.White; };
            enterAcc.Click += (s, a) => { contentTab.SelectedIndex = 4; };
            regAcc.Click += (s, a) => { contentTab.SelectedIndex = 5; };
            #endregion

            Grid.SetColumnSpan(menuBtn, 1);
            Grid.SetColumnSpan(treckerBtn, 2);
            Grid.SetColumnSpan(diaryBtn, 2);
            Grid.SetColumnSpan(settingsBtn, 2);
        }

        BrushConverter bc = new BrushConverter();

        #region клики по меню (визуал)
        private void menuClick(object sender, RoutedEventArgs e)
        {
            contentTab.SelectedIndex = 0;
            Grid.SetColumnSpan(menuBtn, 1);
            Grid.SetColumnSpan(treckerBtn, 2);
            Grid.SetColumnSpan(diaryBtn, 2);
            Grid.SetColumnSpan(settingsBtn, 2);
        }
        private void treckerClick(object sender, RoutedEventArgs e)
        {
            contentTab.SelectedIndex = 1;
            Grid.SetColumnSpan(menuBtn, 2);
            Grid.SetColumnSpan(treckerBtn, 1);
            Grid.SetColumnSpan(diaryBtn, 2);
            Grid.SetColumnSpan(settingsBtn, 2);
        }
        private void diaryClick(object sender, RoutedEventArgs e)
        {
            contentTab.SelectedIndex = 2;
            Grid.SetColumnSpan(menuBtn, 2);
            Grid.SetColumnSpan(treckerBtn, 2);
            Grid.SetColumnSpan(diaryBtn, 1);
            Grid.SetColumnSpan(settingsBtn, 2);
        }
        private void settingsClick(object sender, RoutedEventArgs e)
        {
            contentTab.SelectedIndex = 3;
            Grid.SetColumnSpan(menuBtn, 2);
            Grid.SetColumnSpan(treckerBtn, 2);
            Grid.SetColumnSpan(diaryBtn, 2);
            Grid.SetColumnSpan(settingsBtn, 1);
        }
        #endregion

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";
            ((TextBox)sender).Foreground = Brushes.Black;
        }

        private void passTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "Пароль";
            ((TextBox)sender).Foreground = Brushes.Gray;
        }

        private void loginTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "Логин";
            ((TextBox)sender).Foreground = Brushes.Gray;
        }
}
}