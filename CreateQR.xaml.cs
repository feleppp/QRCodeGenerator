using MessagingToolkit.QRCode.Codec;
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для CreateQR.xaml
    /// </summary>
    public partial class CreateQR : UserControl
    {
        QRCodeEncoder encoder = new QRCodeEncoder();
        Bitmap bitmap;
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        private GenerationsHistory generation = new GenerationsHistory();

        public CreateQR()
        {
            InitializeComponent();
        }

        private void BtnCreateQR_Click(object sender, RoutedEventArgs e)
        {
            encoder.QRCodeScale = 8;
            bitmap = encoder.Encode(txtQR.Text);
            imgQR.Source = ConvertImage.ToBitmapImage(bitmap);

            try
            {
                var context = QRCodeGeneratorDBEntities.GetContext();

                generation.id_account = QRCodeGeneratorDBEntities.GetContext().Account.FirstOrDefault(a => a.login_ == Authorization.authorisationName).id_account;
                generation.generationTime = DateTime.Now;
                generation.generationText = txtQR.Text;
                string fileName = Authorization.authorisationName + '-' + Convert.ToString(generation.generationTime).Replace(":", "").Replace(" ", "-");
                generation.image_path = System.IO.Path.GetFullPath("QRCodeGenerator\\AllQRPics\\" + fileName);
                generation.susoiciouslvl = 0;

                context.GenerationsHistory.Add(generation);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            txtQR.Clear();
        }

        private void BtnSaveQR_Click(object sender, RoutedEventArgs e)
        {
            saveFileDialog.Filter = "PNG | *.png";
            saveFileDialog.FileName = Authorization.authorisationName + '-' + Convert.ToString(generation.generationTime).Replace(":", "").Replace(" ", "-");
            if (saveFileDialog.ShowDialog() == true)
            {
                if (bitmap != null)
                {
                    bitmap.Save(string.Concat(saveFileDialog.FileName, ".png"), ImageFormat.Png);
                }
            }
        }
    }
}
