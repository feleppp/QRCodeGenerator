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
    /// Логика взаимодействия для RefreshWindow.xaml
    /// </summary>
    public partial class RefreshWindow : Window
    {

        private GenerationsHistory _history;
        public RefreshWindow(GenerationsHistory history)
        {
            InitializeComponent();
            _history = history;

            SusComboBox.ItemsSource = new List<int> { 0, 1, 2, 3, 4, 5 };

            SusComboBox.SelectedItem = history.susoiciouslvl;
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var context = QRCodeGeneratorDBEntities.GetContext();
            _history.susoiciouslvl = Convert.ToInt32(SusComboBox.SelectedItem);
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
