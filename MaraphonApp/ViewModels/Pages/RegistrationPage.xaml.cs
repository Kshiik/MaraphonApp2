using MaraphonApp.Controllers;
using MaraphonApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace MaraphonApp.ViewModels.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Window
    {
        Core context = new Core();
        public RegistrationPage()
        {
            InitializeComponent();
            RoleComboBox.ItemsSource = context.obj.roles.ToList();
            RoleComboBox.DisplayMemberPath = "role_name";
            RoleComboBox.SelectedValuePath = "role_id";

            GenderComboBox.ItemsSource = context.obj.genders.ToList();
            GenderComboBox.DisplayMemberPath = "gender_name";
            GenderComboBox.SelectedValuePath = "gender_code";
        }
        /// <summary>
        /// добавление данных
        /// </summary>
        private async void RegButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                DataBaseController obj = new DataBaseController();
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Marathon_db;Integrated Security=True";
                if (await obj.DataBaseConnect(connectionString))
                {
                    UserController objUser = new UserController();
                    if (objUser.SaveRunnerData(EmailTextBox.Text, FirstTextBox.Text, LastNameTextBox.Text, RoleComboBox.Text, GenderComboBox.Text, PasswordTextBox.Text))
                    {
                        ResultTextBlock.Text = "Сохранено";
                        //переход на страницу RunnerMenuPage (если роль - бегун) }
                    }
                    else
                    {
                        ResultTextBlock.Text = "Соединенеие не установлено";
                    }
                }
            }
            catch (Exception ex)
            {
                ResultTextBlock.Text = "Соединенеие не установлено";
            }

        }
    }
}
