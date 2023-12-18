using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
namespace UnmultApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string filepath = "";
        string folderpath = "";
        string name = "";
        public MainWindow()
        {
            InitializeComponent();
        }
        [DllImport("unmultdll.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        public static extern void Exec(string _loadpath, string _savepath, string _name);

        private void Select_File(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "mp4 video file (*.mp4)|*.mp4";
            if (dialog.ShowDialog()==System.Windows.Forms.DialogResult.OK)
                filepath = dialog.FileName;


        }

        private void Folder_Select(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                folderpath= dialog.SelectedPath;
            }
        }

        private async void Convert(object sender, RoutedEventArgs e)
        {
            name=filename.Text;
            if (filepath =="")
            {
                message.Content="Please select a file.";
            }
            else if (folderpath=="")
            {
                message.Content=("Please select a folder to save.");
            }
            else if (name=="")
            {
                message.Content="Please specify the file name";
            }else{
                message.Content="converting...";
                await Task.Delay(1);
                Exec(filepath, folderpath,name);
                message.Content="Completed!";
            }
        }
    }
}