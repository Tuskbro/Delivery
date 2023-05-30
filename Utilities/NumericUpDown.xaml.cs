using Delivery.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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

namespace Delivery.Utilities
{
    /// <summary>
    /// Логика взаимодействия для NumericUpDown.xaml
    /// </summary>
    public partial class NumericUpDown : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(int), typeof(NumericUpDown), new FrameworkPropertyMetadata(0, OnValueChanged));


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        int minvalue = 0,
        maxvalue = 100,
        startvalue = 0;

        public NumericUpDown()
        {
            InitializeComponent();
            NUDTextBox.Text = (Value == null) ? Value.ToString() : startvalue.ToString();

        }

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is NumericUpDown numericUpDown)
            {
                numericUpDown.NUDTextBox.Text = numericUpDown.Value.ToString();
            }
        }

        private void NUDButtonUP_Click(object sender, RoutedEventArgs e)
        {
            if (Value < maxvalue)
            {
                Value++;
                SetValue(ValueProperty, Value);
                OnPropertyChanged(nameof(Value));
                NUDTextBox.Text=Value.ToString();
            }
        }

        private void NUDButtonDown_Click(object sender, RoutedEventArgs e)
        {
            if (Value > minvalue)
            {
                Value--;
                SetValue(ValueProperty, Value);
                OnPropertyChanged(nameof(Value));
                NUDTextBox.Text = Value.ToString();
            }
        }

        private void NUDTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                NUDButtonUP.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(NUDButtonUP, new object[] { true });
            }

            if (e.Key == Key.Down)
            {
                NUDButtonDown.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(NUDButtonDown, new object[] { true });
            }
        }

        private void NUDTextBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(NUDButtonUP, new object[] { false });
            }

            if (e.Key == Key.Down)
            {
                typeof(Button).GetMethod("set_IsPressed", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(NUDButtonDown, new object[] { false });
            }
        }

        private void NUDTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(NUDTextBox.Text, out int number))
            {
                NUDTextBox.Text = startvalue.ToString();
            }
            if (number > maxvalue)
            {
                NUDTextBox.Text = maxvalue.ToString();
            }
            if (number < minvalue)
            {
                NUDTextBox.Text = minvalue.ToString();
            }
            NUDTextBox.SelectionStart = NUDTextBox.Text.Length;
        }
    }
}
