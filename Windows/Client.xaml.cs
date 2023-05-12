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
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Client : Window
    {
        public Client()
        {
            InitializeComponent();
            GetListClient();
        }
        //private void GetListClient()
        //{
        //    DgClient.ItemsSource = ClassHelper.EF.context.Client.ToList();
        //}
        private void GetListClient()
        {
            LvClient.ItemsSource = ClassHelper.EF.context.Client.ToList();
        }

        private void BtnEditClient_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button == null)
            {
                return;
            }

            var client = button.DataContext as DB.Client; // получаем выбранную запись


            EditClient editClient = new EditClient(client);
            editClient.ShowDialog();

            GetListClient();
        }//
    }
}
