using Microsoft.Win32;
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
    /// Логика взаимодействия для EditEmploye.xaml
    /// </summary>
    public partial class EditEmploye : Window
    {
        DB.Employe editEmploye = null;
        private string pathImage = null;
        public EditEmploye()
        {
            InitializeComponent();
        }
        public EditEmploye(DB.Employe employe)
        {
            InitializeComponent();


            editEmploye = employe;

            ImgImageService.Source = new BitmapImage(new Uri(employe.Image));

            // заполнение полей
            TbFirstNameEmploye.Text = employe.FirstName;
            TbLastNameEmploye.Text = employe.LastName;
            TbPatronymicEmploye.Text = employe.Patronymic;
            TbPhoneEmploye.Text = employe.Phone;
            TbEmailEmploye.Text = employe.Email;



        }

        private void BtnEdittEmlpoye_Click(object sender, RoutedEventArgs e)
        {
            editEmploye.FirstName = TbFirstNameEmploye.Text;
            editEmploye.LastName = TbLastNameEmploye.Text;
            editEmploye.Patronymic = TbPatronymicEmploye.Text;
            editEmploye.Phone = TbPhoneEmploye.Text;
            editEmploye.Email = TbEmailEmploye.Text;

            ClassHelper.EF.context.SaveChanges();

            MessageBox.Show("Данные успешно сохранны");

            this.Close();
        }

        private void BtnChooseImageEmploye_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgImageService.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                pathImage = openFileDialog.FileName;
            }
        }
    }
}
