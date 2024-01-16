using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PictureAlbum
{
    public partial class MainWindow : Window
    {
        private List<BitmapImage> myPics = new List<BitmapImage>();
        private int curPic = 0;
        private int totalPics = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //Get the current working directory and a list of files in ./MyPics
                string path = Environment.CurrentDirectory;
                string[] allPics = Directory.GetFiles($@"{path}/MyPics/");

                //Populate myPics with all the pics
                foreach (string pic in allPics)
                {
                    myPics.Add(new BitmapImage(new Uri($@"{pic}")));
                    totalPics++;
                }

                //Load up the first image
                imageHolder.Source = myPics[curPic];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Whoops! Something went wrong:\n{0}", ex.Message);
            }
        }

        private void btnPreviousImage_Click(object sender, RoutedEventArgs e)
        {
            //Get the prev pic
            curPic = (curPic - 1) % totalPics;
            //Display that pic
            imageHolder.Source = myPics[curPic];
        }

        private void btnNextImage_Click(object sender, RoutedEventArgs e)
        {
            //Get the next pic
            curPic = (curPic + 1) % totalPics;
            //Display that pic
            imageHolder.Source = myPics[curPic];
        }
    }
}