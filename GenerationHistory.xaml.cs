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

namespace QRCodeGenerator
{
    /// <summary>
    /// Логика взаимодействия для GenerationHistory.xaml
    /// </summary>
    public partial class GenerationHistory : UserControl
    {
        public GenerationHistory()
        {
            InitializeComponent();
        }

        private void History_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshHistoryDataGrid();
            Vis();
        }

        private void RefreshHistoryDataGrid()
        {
            var context = QRCodeGeneratorDBEntities.GetContext();
            var requestsWithRelations = context.GenerationsHistory
            .Include(r => r.Account)
            .Include(r => r.Account.Roles)
            .ToList();

            History.ItemsSource = requestsWithRelations;
        }

        private void Vis()
        {
            switch (QRCodeGenerator.Authorization.authorizationRole)
            {
                case "Администратор":
                    break;
                case "Модератор":
                    BtnDelet.Visibility = Visibility.Collapsed;
                    break;
                case "Пользователь":
                    BtnDelet.Visibility = Visibility.Collapsed;
                    BtnEditGroup.Visibility = Visibility.Collapsed;
                    break;
                default:
                    return;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedRequest = (sender as Button)?.DataContext as GenerationsHistory;
            if (selectedRequest != null)
            {
                RefreshWindow addEditWindow = new RefreshWindow(selectedRequest);
                if (addEditWindow.ShowDialog() == true)
                {
                    RefreshHistoryDataGrid();
                }
            }
        }


        private void BtnDelet_Click(object sender, RoutedEventArgs e)
        {
            var infoForRemoving = History.SelectedItems.Cast<GenerationsHistory>().ToList();
            if (infoForRemoving.Any()
            && MessageBox.Show($"Вы уверены, что хотите удалить следующие {infoForRemoving.Count()} элементы? ", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) ==
            MessageBoxResult.Yes)
            {
                var context = QRCodeGeneratorDBEntities.GetContext();
                context.GenerationsHistory.RemoveRange(infoForRemoving);
                context.SaveChanges();
                MessageBox.Show("Данные удалены");
                RefreshHistoryDataGrid();
            }
        }

        private void BtnUp_Click(object sender, RoutedEventArgs e)
        {
            History.ItemsSource = QRCodeGeneratorDBEntities.GetContext().GenerationsHistory.ToList();
            RefreshHistoryDataGrid();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchText = SearchBox.Text.ToLower();
            var context = QRCodeGeneratorDBEntities.GetContext();
            try
            {
                History.ItemsSource = context.GenerationsHistory
                .Include(r => r.Account)
                .Include(r => r.Account.Roles)
                .Where(r =>
                r.Account.login_.ToString().Contains(searchText) ||
                r.generationTime.ToString().Contains(searchText) ||
                r.generationText.ToLower().Contains(searchText) ||
                r.susoiciouslvl.ToString().Contains(searchText))
                .ToList();
            }
            catch (System.Data.Entity.Core.EntityCommandExecutionException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
            }
        }
    }
}
