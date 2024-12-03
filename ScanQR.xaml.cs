using MessagingToolkit.QRCode.Codec.Data;
using MessagingToolkit.QRCode.Codec;
using System;
using System.Collections.Generic;
using System.Drawing;
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
using Microsoft.Win32;

namespace QRCodeGenerator
{
    /// <summary>
    /// Логика взаимодействия для ScanQR.xaml
    /// </summary>
    public partial class ScanQR : UserControl
    {
        QRCodeDecoder decoder = new QRCodeDecoder();
        OpenFileDialog openFileDialog = new OpenFileDialog();

        public ScanQR()
        {
            InitializeComponent();
        }

        private void BtnScan_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog.ShowDialog() == true)
            {
                imgQR.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                txtQR.Text = decoder.Decode(new QRCodeBitmapImage(new Bitmap(openFileDialog.FileName)));
            }
        }

        private void BtnCopy_Click(object sender, RoutedEventArgs e)
        {
            string textCopy = txtQR.Text;
            for (int i = 0; i < 10; ++i)
            {
                try
                {
                    Clipboard.SetText(textCopy);
                    return;
                }
                catch { }
                System.Threading.Thread.Sleep(10);
            }
        }
    }
}
