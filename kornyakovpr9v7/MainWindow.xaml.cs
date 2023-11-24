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

namespace kornyakovpr9v7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<PersonData> list = new List<PersonData>();
        PersonData p1 = new(),
            p2 = new(),
            p3 = new(),
            p4 = new(),
            p5 = new(),
            p6 = new(),
            p7 = new();

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа№9 Заполнить таблицу со списком телефонных абонентов на 7 человек с полями: ФИО, \r\nномер телефона, адрес. Вывести результат на экран. Вывести список абонентов \r\nживущих на заданной улице.  Разработчик Корняков Д.Д.");
        }

        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            list.Add(p1);
            list.Add(p2);
            list.Add(p3);
            list.Add(p4);
            list.Add(p5);
            list.Add(p6);
            list.Add(p7);

            dataGrid.ItemsSource = list;
        }

        private void btnResult_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tbResult.Clear();

                string adress = tbClassNumber.Text;

                List<string> result = PersonData.GetResult(list, adress);

                foreach (string name in result)
                {
                    tbResult.Text = tbResult.Text + name + "\n";
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                tbResult.Clear();
                tbClassNumber.Clear();
            }

        }

        private void dataGrid_CellEditing(object sender, DataGridCellEditEndingEventArgs e)
        {
            int columnIndex = e.Column.DisplayIndex,
                rowIndex = e.Row.GetIndex();

            try
            {
                PersonData temp = list[rowIndex];

                switch (columnIndex)
                {
                    case 0:
                        temp.Name = ((TextBox)e.EditingElement).Text;
                        break;
                    case 1:
                        temp.Familya = ((TextBox)e.EditingElement).Text;
                        break;
                    case 2:
                        temp.Otchestvo = ((TextBox)e.EditingElement).Text;
                        break;
                    case 3:
                        temp.PhoneNumber = Convert.ToUInt64(((TextBox)e.EditingElement).Text);
                        break;
                    case 4:
                        temp.Address = ((TextBox)e.EditingElement).Text;
                        break;
                }
                list[rowIndex] = temp;
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный ввод");
                ((TextBox)e.EditingElement).Text = "0";
            }
            catch (OverflowException)
            {
                MessageBox.Show("Некорректный ввод");
                ((TextBox)e.EditingElement).Text = "0";
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так");
            }

       
        }
    }
}
