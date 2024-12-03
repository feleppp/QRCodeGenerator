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

namespace QRCodeGenerator
{
    /// <summary>
    /// Логика взаимодействия для RefreshRoleWindow.xaml
    /// </summary>
    public partial class RefreshRoleWindow : Window
    {

        private Account _account;
        public RefreshRoleWindow(Account account)
        {
            InitializeComponent();
            _account = account;
            RoleComboBox.ItemsSource = QRCodeGeneratorDBEntities.GetContext().Roles.ToList();

            RoleComboBox.SelectedItem = account.Roles;
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var context = QRCodeGeneratorDBEntities.GetContext();
            _account.id_role = ((Roles)RoleComboBox.SelectedItem).id_role;
            context.SaveChanges();
            MessageBox.Show("Данные обновлены");
            this.Close();
        }

        private void DragGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
