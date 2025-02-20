﻿using System;
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

namespace QRCodeGenerator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursor(index);
            switch (index)
            {
                case 0:
                    GridContent.Children.Clear();
                    GridContent.Children.Add(new CreateQR());
                    break;
                case 1:
                    GridContent.Children.Clear();
                    GridContent.Children.Add(new ScanQR());
                    break;
                case 2:
                    GridContent.Children.Clear();
                    GridContent.Children.Add(new GenerationHistory());
                    break;
                case 3:
                    GridContent.Children.Clear();
                    GridContent.Children.Add(new UsersList());
                    break;
            }
        }

        private void MoveCursor(int index)
        {
            TransitionContentSlide.OnApplyTemplate();
            TransitionGrid.Margin = new Thickness(0, (index * 70) + 70, 0, 0);
        }

        private void DragGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            GridContent.Children.Clear();
            GridContent.Children.Add(new CreateQR());
            Vis();
        }

        private void Vis()
        {
            switch (QRCodeGenerator.Authorization.authorizationRole)
            {
                case "Администратор":
                    break;
                case "Модератор":
                    break;
                case "Пользователь":
                    LVUsers.Visibility = Visibility.Collapsed;
                    break;
                default:
                    return;
            }
        }
    }
}
