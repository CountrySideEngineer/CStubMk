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

namespace CStubMKGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CStubMkGui : Window
    {
        public CStubMkGui()
        {
            InitializeComponent();
        }

        private void StubDefFilePathTextBox_PreviewDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop, true))
            {
                e.Effects = System.Windows.DragDropEffects.Copy;
            }
            else
            {
                e.Effects = System.Windows.DragDropEffects.None;
            }
            e.Handled = true;
        }

        private void StubDefFilePathTextBox_Drop(object sender, DragEventArgs e)
        {
            var dropFiles = e.Data.GetData(System.Windows.DataFormats.FileDrop) as string[];
            if (null == dropFiles)
            {
                return;
            }
            else
            {
                StubDefFilePathTextBox.Text = dropFiles[0];
            }
        }

        private void StubOutputPathTextBox_PreviewDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
            e.Handled = true;
        }

        private void StubOutputPathTextBox_Drop(object sender, DragEventArgs e)
        {
            var dropFiles = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (null == dropFiles)
            {
                return;
            }
            else
            {
                StubOutputPathTextBox.Text = dropFiles[0];
            }
        }
    }
}
