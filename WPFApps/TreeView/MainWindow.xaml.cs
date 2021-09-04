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

            //if (item.Items.Count != 1 || item.Items[0] != null)
            //    return;

            item.Items.Clear();

            string path = item.Tag.ToString();

            var directories = new List<string>();

            var dirs = Directory.GetDirectories(path);
            if (dirs.Length > 0)
                directories.AddRange(dirs);

            directories.ForEach(directoryPath =>
            {
                var subItem = new TreeViewItem()
                {
                    Header = System.IO.Path.GetFileName(directoryPath),
                    Tag = directoryPath
                };

                item.Items.Add(subItem);
                subItem.Items.Add(null);
                subItem.Expanded += FolderExpaned;
            });
        }
    }
}
