using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace SddTool
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var input = Base64Input.Text;
            byte[] data = Convert.FromBase64String(input);

            var directory = Path.Combine(Directory.GetCurrentDirectory(), "converted");
            Directory.CreateDirectory(directory);

            var filePath = Path.Combine(directory, $"{DateTime.Now.Ticks}.jpg");
            using (var imageFile = new FileStream(filePath, FileMode.Create))
            {
                imageFile.Write(data, 0, data.Length);
                imageFile.Flush();
            }

            Process.Start(directory);

            Close();
        }
    }
}
