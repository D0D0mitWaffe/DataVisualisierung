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
using System.IO;

namespace DataVisualisierung {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        string Path_0 = @"E:\C# Prjekte\DataVisualisierung\trainingsdata_.txt";
        string Path_1 = @"E:\C# Prjekte\DataVisualisierung\trainingdata1.txt";
        List<List<System.Drawing.Bitmap>> Bitmaps = new List<List<System.Drawing.Bitmap>>();

        public MainWindow() {
            InitializeComponent();
            Start();
        }
        
        void Start() {
            string[] lines = File.ReadAllLines(Path_1);
            for (int i = 0; i < lines.Length; i++) {
                string s = lines[i];
                lines[i] = s.Replace(".", ",");
            }
            string[][] data0 = new string[lines.Length][];
            float[][] data1 = Enumerable
                .Range(0, lines.Length)
                .Select(i => new float[15 * 15 + 1])
                .ToArray();
            for (int i = 0; i < lines.Length; i++) {
                data0[i] =  lines[i].Split(' ');
            }
            for (int i = 0; i < data0.Length; i++) {
                for (int j = 0; j < data0[i].Length; j++) {
                    data1[i][j] = float.Parse(data0[i][j]);
                }
            }
            System.Drawing.Bitmap bm = new System.Drawing.Bitmap(15, 15);
            int counter = 0;
            int number = 0;
            for (int i = 0; i < lines.Length; i++) {
                if(number == 10) {
                    number = 0;
                }
                counter = 0;
                for (int j = 0; j < 15; j++) {
                    for (int k = 0; k < 15; k++) {
                        System.Drawing.Color c = System.Drawing.Color.FromArgb((byte)Math.Round(data1[i][counter] * 255, 0), 255, 255, 255);
                        bm.SetPixel(x: j, y: k, c);
                        counter++;
                    }
                }
                bm.RotateFlip(System.Drawing.RotateFlipType.Rotate270FlipNone);
                bm.Save(@"E:\C# Prjekte\DataVisualisierung\test\" + number + "_"+ i / 10 + ".png");
                number++;
            }
            
        }
    }
}
