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
using WPFNote.Model;

namespace WPFNote
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            #region задаю события фокуса textbox (визуал)
            regPassTextBox.GotFocus += passTextBox_GotFocus;
            enterPassTextBox.GotFocus += passTextBox_GotFocus;
            regLoginTextBox.GotFocus += loginTextBox_GotFocus;
            enterLoginTextBox.GotFocus += loginTextBox_GotFocus;

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
            enterAcc.Click += (s, a) => {
                loginCheck = false;
                passCheck = false;
                contentTab.SelectedIndex = 4;
            };
            regAcc.Click += (s, a) => {
                loginCheck = false;
                passCheck = false;
                contentTab.SelectedIndex = 5; 
            };
            #endregion

            Grid.SetColumnSpan(menuBtn, 1);
            Grid.SetColumnSpan(treckerBtn, 2);
            Grid.SetColumnSpan(diaryBtn, 2);
            Grid.SetColumnSpan(settingsBtn, 2);

            trackerMonth.Text = DateTime.Now.ToString("MMMM");
            trackerYear.Text = DateTime.Now.ToString("yyyy");
        }

        //BrushConverter bc = new BrushConverter();

        //TODO: решить дублирование кода

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

        #region фокус по текст боксу
        bool loginCheck = false,
            passCheck = false;
        private void loginTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!loginCheck)
            {
            ((TextBox)sender).Text = "";
            ((TextBox)sender).Foreground = Brushes.Black;
            }
            loginCheck = true;
        }
        private void passTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (!passCheck)
            {
            ((TextBox)sender).Text = "";
            ((TextBox)sender).Foreground = Brushes.Black;
            }
            passCheck = true;
        }

        private void passTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if(((TextBox)sender).Text == "" || ((TextBox)sender).Text == null)
            {
                ((TextBox)sender).Text = "Пароль";
                ((TextBox)sender).Foreground = Brushes.Gray;
                passCheck = false;
            }
        }

        private void loginTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text == "" || ((TextBox)sender).Text == null)
            {
                ((TextBox)sender).Text = "Логин";
                ((TextBox)sender).Foreground = Brushes.Gray;
                loginCheck = false;
            }
        }
        #endregion

        #region Клики по входу/регистрации (дублирование кода)
        private void regClick(object sender, RoutedEventArgs e)
        {
            if (!loginCheck || regLoginTextBox.Text == "" || regLoginTextBox == null || !passCheck || regPassTextBox.Text == "" || regPassTextBox.Text == null) // если поля пустые то ошибка иначе продолжает
            {
                MessageBox.Show("Введите логин или пароль");
            }
            else
            {
                if (!registration.regPerson(regLoginTextBox.Text, regPassTextBox.Text)) // если нет такого акка в базе вносит его иначе ошибка
                    MessageBox.Show("Логин уже занят.");
                else
                    entering(regLoginTextBox.Text);
            }
        }

        private void enterClick(object sender, RoutedEventArgs e)
        {
            if (!loginCheck || enterLoginTextBox.Text == "" || enterLoginTextBox == null || !passCheck || enterPassTextBox.Text == "" || enterPassTextBox.Text == null)
            {
                MessageBox.Show("Введите логин или пароль");
            }
            else 
            {
                if (enter.enterPerson(enterLoginTextBox.Text, enterPassTextBox.Text)){
                    entering(enterLoginTextBox.Text);
                }
                else
                {
                    MessageBox.Show("Не правильный логин или пароль");
                }
            }
        }
        void entering(string login)
        {
            signInBlock.Visibility = Visibility.Hidden;
            loginLabel.Text = login;
            loginLabel.Visibility = Visibility.Visible;
            contentTab.SelectedIndex = 0;
        }
        #endregion

        DateTime currDate;
        private void nextMonth(object sender, RoutedEventArgs e)
        {
            currDate = dateChange.monthChange(true);
            trackerMonth.Text = currDate.ToString("MMMM");
            trackerYear.Text = currDate.ToString("yyyy");
        }
        private void prevMonth(object sender, RoutedEventArgs e)
        {
            currDate = dateChange.monthChange(false);
            trackerMonth.Text = currDate.ToString("MMMM");
            trackerYear.Text = currDate.ToString("yyyy");
        }
    }
}