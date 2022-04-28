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
using ListClass.Classes;

namespace ListClass
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
       // List<Pharmacy> pharmacies = new List<Pharmacy>();
        public MainWindow()
        {
            InitializeComponent();
            ConnectHelper.Students.Add(new Student("Цитрамон", "ИСП", 5, 5, 5, 5, 5));
            ConnectHelper.Students.Add(new Student("Парацетамол", "ИСП", 5, 5, 5, 5, 5));
            ConnectHelper.Students.Add(new Student("Нурофен", "ИСП", 5, 5, 5, 5, 5));
            ConnectHelper.Students.Add(new Student("Спазган", "ИСП", 5, 5, 5, 5, 5));
            ConnectHelper.Students.Add(new Student("Витамин C", "ИСП", 5, 5, 5, 5, 5));
            ConnectHelper.Students.Add(new Student("Зодак", "ИСП", 5, 5, 5, 5, 5));
            ConnectHelper.Students.Add(new Student("Ибупрофен", "ИСП", 5, 5, 5, 5, 5));
            ConnectHelper.Students.Add(new Student("Пенталгин", "ИСП", 5, 5, 5, 5, 5));

            DtgListStudent.ItemsSource = ConnectHelper.Students;
            //pharmacies.Add(new Pharmacy("Цитрамон", 100, 199.90, 36));
            //pharmacies.Add(new Pharmacy("Парацетамол", 200, 279.90, 24));
            //pharmacies.Add(new Pharmacy("Нурофен", 255, 356.90, 24));
            //pharmacies.Add(new Pharmacy("Спазган", 99, 555.01, 36));
            //pharmacies.Add(new Pharmacy("Витамин C", 1000, 50.00, 12));
            //pharmacies.Add(new Pharmacy("Зодак", 5, 356.90, 24));
            //pharmacies.Add(new Pharmacy("Ибупрофен", 35, 555.01, 36));
            //pharmacies.Add(new Pharmacy("Пенталгин", 8, 50.00, 12));
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            DtgListStudent.ItemsSource = ConnectHelper.Students.ToList();
            DtgListStudent.SelectedIndex = -1;
           
        }
        /// <summary>
        /// сортировка по алфавиту
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RbUp_Checked(object sender, RoutedEventArgs e)
        {
            DtgListStudent.ItemsSource = ConnectHelper.Students.OrderBy(x=>x.NameStudent).ToList();
        }
        /// <summary>
        /// сортировка в обратном порядке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RbDown_Checked(object sender, RoutedEventArgs e)
        {
            DtgListStudent.ItemsSource = ConnectHelper.Students.OrderByDescending(x => x.NameStudent).ToList();
        }
        /// <summary>
        /// поиск по названию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DtgListStudent.ItemsSource = ConnectHelper.Students.Where(x => 
                x.NameStudent.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
        }

       /// <summary>
       /// фильтр по количеству
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void CmbFiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (CmbFiltr.SelectedIndex == 0)
            {
                DtgListStudent.ItemsSource = ConnectHelper.Students.Where(x =>
                    x.CountGymnastic >= 0 && x.CountGymnastic <= 10).ToList();
                MessageBox.Show("Недостаточное количество препаратов на складе!",
                    "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
                if (CmbFiltr.SelectedIndex == 1)
            {
                DtgListStudent.ItemsSource = ConnectHelper.Students.Where(x =>
                    x.CountGymnastic >= 11 && x.CountGymnastic <= 50).ToList();
                MessageBox.Show("Необходимо пополнить запасы препаратов в ближайшее время",
                    "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                DtgListStudent.ItemsSource = ConnectHelper.Students.Where(x =>
                   x.CountGymnastic >= 51).ToList();
                MessageBox.Show("Достаточное количество препаратов на складе!",
                    "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAddPreparate windowAdd = new WindowAddPreparate();
            windowAdd.ShowDialog();
        }

       

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            DtgListStudent.ItemsSource = null;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

      
    }
}
