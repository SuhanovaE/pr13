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
using ListClass.Classes;

namespace ListClass
{
    /// <summary>
    /// Логика взаимодействия для WindowAddPreparate.xaml
    /// </summary>
    public partial class WindowAddPreparate : Window
    {
        public WindowAddPreparate()
        {
            InitializeComponent();
        }


        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student()
            {
                NameStudent = TxbName.Text,
                NamegGroup = TxbGroup.Text,
                CountGymnastic = int.Parse(TxbGymnastic.Text),
                CountChemistry = int.Parse(TxbChemistry.Text),
                CountPhysics=int.Parse(TxbPhysics.Text),
                CountAlgebra=int.Parse(TxbAlgebra.Text),
                CountLiterature=int.Parse(TxbLiterature.Text),
            };
            ConnectHelper.students.Add(student);
            
            this.Close();
        }
    }
}
