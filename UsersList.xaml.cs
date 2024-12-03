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
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;

namespace QRCodeGenerator
{
    /// <summary>
    /// Логика взаимодействия для UsersList.xaml
    /// </summary>
    public partial class UsersList : UserControl
    {
        public UsersList()
        {
            InitializeComponent();
        }

        private void Users_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshUsersDataGrid();
            ComboRole.ItemsSource = QRCodeGeneratorDBEntities.GetContext().Roles.ToList();
            Vis();
        }

        private void RefreshUsersDataGrid()
        {
            var context = QRCodeGeneratorDBEntities.GetContext();
            var requestsWithRelations = context.Account
            .Include(r => r.Roles)
            .ToList();

            Users.ItemsSource = requestsWithRelations;
        }

        private void Vis()
        {
            switch (QRCodeGenerator.Authorization.authorizationRole)
            {
                case "Администратор":
                    break;
                case "Модератор":
                    BtnEditGroup.Visibility = Visibility.Collapsed;
                    break;
                case "Пользователь":
                    BtnBanGroup.Visibility = Visibility.Collapsed;
                    BtnEditGroup.Visibility = Visibility.Collapsed;
                    break;
                default:
                    return;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = (sender as Button)?.DataContext as Account;
            if (selectedUser != null)
            {
                RefreshRoleWindow addEditWindow = new RefreshRoleWindow(selectedUser);
                if (addEditWindow.ShowDialog() == true)
                {
                    RefreshUsersDataGrid();
                }
            }
        }


        private void BtnBan_Click(object sender, RoutedEventArgs e)
        {
            var selectedUser = (sender as Button)?.DataContext as Account;
            var context = QRCodeGeneratorDBEntities.GetContext();
            if (selectedUser != null)
            {
                if (selectedUser.Roles.name_role == "Администратор")
                {
                    MessageBox.Show("Нельзя заблокировать администратора!");
                }
                else if (selectedUser.login_ == Authorization.authorisationName)
                {
                    MessageBox.Show("Нельзя заблокировать себя!");
                }
                else
                { 
                    selectedUser.is_banned = !(selectedUser.is_banned);
                    context.SaveChanges();

                    if (selectedUser.is_banned == true)
                    {
                        MessageBox.Show("Пользователь заблокирован!");
                    }
                    else
                    {
                        MessageBox.Show("Пользователь разблокирован!");
                    }
                }

            }
        }

        private void BtnUp_Click(object sender, RoutedEventArgs e)
        {
            Users.ItemsSource = QRCodeGeneratorDBEntities.GetContext().Account.ToList();
            RefreshUsersDataGrid();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchBox.Text.ToLower();
            var context = QRCodeGeneratorDBEntities.GetContext();
            try
            {
                Users.ItemsSource = context.Account
                .Include(r => r.Roles)
                .Where(r =>
                r.id_account.ToString().Contains(searchText) ||
                r.login_.ToString().Contains(searchText) ||
                r.Roles.name_role.ToLower().Contains(searchText) ||
                r.is_banned.ToString().Contains(searchText))
                .ToList();
            }
            catch (System.Data.Entity.Core.EntityCommandExecutionException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
            }
        }

        private void BtnOut_Click (object sender, RoutedEventArgs e)
        {
            if (ComboRole.SelectedItem is Roles selectedRole)
            {
                var selectedRoleID = selectedRole.id_role;
                var context = QRCodeGeneratorDBEntities.GetContext();
                Users.ItemsSource = context.Account
                .Include(r => r.Roles)
                .Where(r => r.id_role == selectedRoleID)
                .ToList();
            }
        }

        

    }
}
