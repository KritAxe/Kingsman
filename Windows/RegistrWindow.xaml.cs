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
    /// Логика взаимодействия для RegistrWindow.xaml
    /// </summary>
    public partial class RegistrWindow : Window
    {
        public RegistrWindow()
        {
            InitializeComponent();
            CmbGender.ItemsSource = ClassHelper.EF.context.Gender.ToList();
            CmbGender.DisplayMemberPath = "Name";
            CmbGender.SelectedIndex = 0;
        }
        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            // валидация
            if (string.IsNullOrWhiteSpace(TbLastName.Text))
            {
                MessageBox.Show("Поле Фамилия не заполнено");
                return;
            }

            if (string.IsNullOrWhiteSpace(TbFirstName.Text))
            {
                MessageBox.Show("Поле Имя не заполнено");
                return;
            }
            // добавление 
            DB.Client addClient = new DB.Client();
            addClient.Login = TbLogin.Text;
            addClient.Password = PbPassword.Password;
            addClient.Phone = TbPhone.Text;
            addClient.FirstName = TbFirstName.Text;
            addClient.LastName = TbLastName.Text;
            if (TbMiddleName.Text != string.Empty)
            {
                addClient.Patronymic = TbMiddleName.Text;
            }
            addClient.Gender = (CmbGender.SelectedItem as DB.Gender).id;

            ClassHelper.EF.context.Client.Add(addClient);

            // сохранение
            ClassHelper.EF.context.SaveChanges();

            MessageBox.Show("Пользователь успешно добавлен");


        }
    }
}
