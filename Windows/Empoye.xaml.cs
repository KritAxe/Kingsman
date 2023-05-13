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

namespace Kingsman.Windows
{
    /// <summary>
    /// Логика взаимодействия для Empoye.xaml
    /// </summary>
    public partial class Empoye : Window
    {
        public Empoye()
        {
            InitializeComponent();
            GetListEmploye();
        }
        private void GetListEmploye()
        {
            LvEmploye.ItemsSource = ClassHelper.EF.context.Employe.ToList();
        }

        private void BtnEditEmploye_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button == null)
            {
                return;
            }

            var employe = button.DataContext as DB.Employe; // получаем выбранную запись


            EditEmploye editEmploye = new EditEmploye(employe);
            editEmploye.ShowDialog();

            GetListEmploye();
        }//

        private void BtnAddEmploye_Click(object sender, RoutedEventArgs e)
        {
            EditEmploye editemploye = new EditEmploye();
            editemploye.ShowDialog();
        }
    }///////////
}
