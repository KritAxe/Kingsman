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
    /// Логика взаимодействия для EditClient.xaml
    /// </summary>
    public partial class EditClient : Window
    {
        DB.Client editClient = null;


        public EditClient()
        {
            InitializeComponent();
        }
        public EditClient(DB.Client client)
        {
            InitializeComponent();


            editClient = client;

            // заполнение полей
            TbFirstNameClient.Text = client.FirstName;
            TbLastNameClient.Text = client.LastName;
            TbPatronymicClient.Text = client.Patronymic;
            TbPhoneClient.Text = client.Phone;
            TbEmailClient.Text = client.Email;

            

        }

        private void BtnEdittClient_Click(object sender, RoutedEventArgs e)
        {
            editClient.FirstName = TbFirstNameClient.Text;
            editClient.LastName = TbLastNameClient.Text;
            editClient.Patronymic = TbPatronymicClient.Text;
            editClient.Phone = TbPhoneClient.Text;
            editClient.Email = TbEmailClient.Text;

            ClassHelper.EF.context.SaveChanges();

            MessageBox.Show("Данные успешно сохранны");

            this.Close();
        }
    }
}
