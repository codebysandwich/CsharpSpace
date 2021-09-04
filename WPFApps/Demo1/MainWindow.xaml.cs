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

namespace Demo1
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

        private void Apply_Click(object sender, RoutedEventArgs e)
        {
            tb_status.Text = "OK";
        }

        private void FinishCombox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //如果初始化时设置了selectedIndex，并文本框后生成则必须考虑这个问题
            if (NoteText == null)
            {
                return;
            }

            //NoteText.Text = (string)((ComboBoxItem)FinishCombox.SelectedItem).Content;
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem comboBoxItem = (ComboBoxItem)comboBox.SelectedItem;
            NoteText.Text = comboBoxItem.Content.ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 初始化完成同步信息
            FinishCombox_SelectionChanged(FinishCombox, null);
        }

        private void CodeText_TextChanged(object sender, TextChangedEventArgs e)
        {
            MassText.Text = CodeText.Text;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            LengthText.Text += ((CheckBox)sender).Content;
        }

        private void RestButton_Click(object sender, RoutedEventArgs e)
        {
            WildCheckBox.IsChecked = AssemblyCheckBox.IsChecked = PlasmaCheckBox.IsChecked =
                LaserCheckBox.IsChecked = PurchaseCheckBox.IsChecked = LatheCheckBox.IsChecked =
                DrillCheckBox.IsChecked = DrillCheckBox.IsChecked = FoldCheckBox.IsChecked =
                RowCheckBox.IsChecked = SawCheckBox.IsChecked = false;

            LengthText.Text = string.Empty;

        }
    }
}
