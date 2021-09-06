using System;
using System.Collections.Generic;
using System.IO;
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

namespace TreeView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var drive in Directory.GetLogicalDrives())
            {
                var item = new TreeViewItem()
                {
                    Header = drive,
                    Tag = drive
                };
                item.Expanded += FolderExpaned;
                FolderView.Items.Add(item);
                item.Items.Add(null);
            }
        }

        private void FolderExpaned(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("open");
            var item = (TreeViewItem)sender;

            if (item.Items.Count != 1 || item.Items[0] != null)
                //if (item.Items.Count > 1)
                return;

            item.Items.Clear();

            string path = item.Tag.ToString();

            var directories = new List<string>();
            try
            {
                var dirs = Directory.GetDirectories(path);
                if (dirs.Length > 0)
                    directories.AddRange(dirs);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("无访问权限!");
                return;
            }

            directories.ForEach(directoryPath =>
            {
                var subItem = new TreeViewItem()
                {
                    Header = System.IO.Path.GetFileName(directoryPath),
                    Tag = directoryPath
                };

                item.Items.Add(subItem);
                //if ( (Directory.GetFiles(directoryPath).Length +
                //        Directory.GetDirectories(directoryPath).Length) > 0)
                //{
                //    subItem.Items.Add(null);
                //}
                subItem.Items.Add(null);
                subItem.Expanded += FolderExpaned;
            });


            var files = new List<string>();
            var fs = Directory.GetFiles(path);
            if (fs.Length > 0)
                files.AddRange(fs);

            files.ForEach(filePath =>
            {
                var subItem = new TreeViewItem()
                {
                    Header = System.IO.Path.GetFileName(filePath),
                    Tag = filePath
                };
                item.Items.Add(subItem);
            });
        }
    }
}
