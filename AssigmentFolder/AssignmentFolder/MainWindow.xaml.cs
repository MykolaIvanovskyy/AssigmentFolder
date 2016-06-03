using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AssignmentFolder
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

        private void Serialize(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            ClassSerialize serialize = new ClassSerialize();
            dialog.ShowDialog();
            serialize.SaveToBinaryFile(dialog.SelectedPath);
        }

        private void Deserialize(object sender, RoutedEventArgs e)
        {
            ClassDeserialize deserialize = new ClassDeserialize();
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            deserialize.SaveFolder(dialog.SelectedPath);
        }
    }
}
