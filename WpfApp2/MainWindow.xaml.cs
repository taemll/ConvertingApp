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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ExchangeRate call = new ExchangeRate();
        static List<ExchangeRate> rates = new List<ExchangeRate>();
        public MainWindow()
        {
            InitializeComponent();
            rates = call.UseXml();
            input_combobox.Items.Add("KZT");
            foreach(var item in rates)
            {
                output_combobox.Items.Add(item.title);
            }
        }

        private void btn_switch_click(object sender, RoutedEventArgs e)
        {
            if (check)
            {
                input_combobox.Items.Clear();
                output_combobox.Items.Clear();
                output_combobox.Items.Add("KZT");
                foreach (var item in rates)
                {
                    input_combobox.Items.Add(item.title);
                }
                check = false;
            }
            else
            {
                input_combobox.Items.Clear();
                output_combobox.Items.Clear();
                input_combobox.Items.Add("KZT");
                foreach (var item in rates)
                {
                    output_combobox.Items.Add(item.title);
                }
                check = true;
            }
        }

        bool check = true;
        private void btn_output_click(object sender, RoutedEventArgs e)
        {
            if (inputValue.Text != "")
            {
                if (input_combobox.SelectedItem != null && input_combobox.SelectedItem != null)
                {
                    output.Text = Check.ConvertValue(rates, inputValue.Text, input_combobox.Text, output_combobox.Text, check);
                }
                else MessageBox.Show("Выберите валюту для преобразования");

            }
            else MessageBox.Show("Введите сумму для преобразования");
        }
    }
}
