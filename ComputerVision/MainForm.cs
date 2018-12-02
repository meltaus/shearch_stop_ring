using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;

namespace ComputerVision
{
    public partial class MainForm : Form
    {
        private SingDetectorMethodCanny _brickSingDetector;
        private SingDetectorMethodHaara _singDetectorHaar;
        
        private Thread _analizeCannyThread = null;
        private Thread _analizeHaarThread = null;
        private Thread _openFileThread = null;

        private long _haarDetectTime;
        private long _cannyDetectTime;
        
        private String _singFileCascad = null;
        private string _dirCanny = null;
        private string _dirHaar = null;
        private string _cannySingTag = null;
        private string _cannySingOnImageTag = null;
        private string _haarSingOnImageTag = null;

        private int _entryListView;
        private ImageList _imageList;
        private List<string> _imagePath;

        private int _canneActuation;
        private int _haarActuation;

        public MainForm()
        {
            InitializeComponent();

            _dirCanny = "Canny";
            _dirHaar = "Haar";
            _singFileCascad = "cascade.xml";
            _cannySingTag = "cannySing";
            _cannySingOnImageTag = "cannySingOnImage";
            _haarSingOnImageTag = "haarSingOnImage";

            _haarDetectTime = 0;
            _cannyDetectTime = 0;

            _entryListView = 0;
            listView.View = View.Details;
            _imageList = new ImageList();
            _imagePath = new List<string>();
        }

        private void menuExitProgram_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";
            openFileDialog.Title = "Выберите изображение";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in openFileDialog.FileNames)
                {
                    addEntryListView(file);
                }
            }
        }
        
        /// <summary>
        /// Открывает изображение в pictureImage
        /// </summary>
        /// <param name="fileName">Путь до изображения</param>
        private void openImage(string fileName)
        {
            Console.WriteLine(String.Format("fileName: {0}", fileName));

            cannyPictureBox1.Image = null;
            cannyPictureBox2.Image = null;
            haarPictureBox.Image = null;
            openDetectImage(fileName, _dirCanny, _cannySingTag);
            openDetectImage(fileName, _dirCanny, _cannySingOnImageTag);
            openDetectImage(fileName, _dirHaar, _haarSingOnImageTag);
            using (var imgStream = File.OpenRead(fileName))
            {
                pictureBox.Image = Image.FromStream(imgStream);
            }
        }

        /// <summary>
        /// Открытие ранее распознанного файла
        /// </summary>
        /// <param name="fileName">имя файла</param>
        /// <param name="dir">каталог</param>
        /// <param name="tag">тэг файла</param>
        private void openDetectImage(string fileName, string dir, string tag)
        {
            string detectFilePath = null;
            detectFilePath = fileName.Remove(0, fileName.LastIndexOf('\\') + 1);
            detectFilePath = dir + "\\" + detectFilePath.Substring(0, detectFilePath.IndexOf('.')) + "_" + tag + ".bmp";
            Console.WriteLine(String.Format("detectFilePath для {0} : {1}", tag, detectFilePath));
            if (File.Exists(detectFilePath))
            {
                switch (tag)
                {
                    case "cannySing":
                        using (var imgStream = File.OpenRead(detectFilePath))
                        {
                            cannyPictureBox1.Image = Image.FromStream(imgStream);
                        }
                        break;
                    case "cannySingOnImage":
                        using (var imgStream = File.OpenRead(detectFilePath))
                        {
                            cannyPictureBox2.Image = Image.FromStream(imgStream);
                        }
                        break;
                    case "haarSingOnImage":
                        using (var imgStream = File.OpenRead(detectFilePath))
                        {
                            haarPictureBox.Image = Image.FromStream(imgStream);
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Добавляет элементы в список
        /// </summary>
        /// <param name="file"></param>
        private void addEntryListView(string file)
        {
            _imageList.ImageSize = new Size(50, 50);

            try
            {
                _imageList.Images.Add(Image.FromFile(file));
                listView.SmallImageList = _imageList;
                listView.Items.Add(file.Remove(0, file.LastIndexOf('\\') + 1), _entryListView);
                _imagePath.Add(file);

                _entryListView++;
            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        private void listView_Click(object sender, EventArgs e)
        {
            foreach (string file in _imagePath)
            {
                if (file.Contains(listView.Items[listView.FocusedItem.Index].SubItems[0].Text))
                {
                    openImage(file);
                    break;
                }
            }
        }
        private void menuAnalizeFile_Click(object sender, EventArgs e)
        {
            //Создаем каталог для временных файлов
            CreateDir(_dirCanny);
            CreateDir(_dirHaar);
            
            
            _canneActuation = 0;
            _haarActuation = 0;
            if (StateLocalTread())
            {
                _analizeCannyThread.Resume();
                _analizeHaarThread.Resume();
            } else
            {
                _analizeCannyThread = new Thread(new ThreadStart(AlanizeCanny));
                _analizeHaarThread = new Thread(new ThreadStart(AlanizeHaar));
                _analizeCannyThread.Start();
                _analizeHaarThread.Start();
            }
            
        }

        private void SingDetectHaar(string fileName, string fileNameToSave)
        {
            try
            {
                IImage image = new UMat(fileName, ImreadModes.Color);

                List<Rectangle> sings = new List<Rectangle>();
                _singDetectorHaar = new SingDetectorMethodHaara();

                long detectTime;
                bool success = false;

                _singDetectorHaar.Detect(image, _singFileCascad, sings, out detectTime);

                foreach (Rectangle sing in sings)
                {
                    CvInvoke.Rectangle(image, sing, new Bgr(Color.Red).MCvScalar, 2);
                    success = true;
                }

                using (InputArray iaImage = image.GetInputArray())
                {
                    if (success)
                    {
                        timeChart.Invoke(new Action<int, double>(AddHaar), _haarActuation, detectTime);
                        SaveFileBmp(image.Bitmap, _dirHaar, _haarSingOnImageTag, fileNameToSave);
                        _haarActuation++;
                    }
                }
                _haarDetectTime += detectTime;
                Console.WriteLine(String.Format("_haarActuation : {0}", _haarActuation));
                haarLabel.Invoke(new Action<int, double>(AddHaarLabel), _haarActuation, _haarDetectTime);
            }
            catch
            {
            }
        }
        

        private void SingDetectCanny(Mat image, string fileName)
        {
            try
            {
                Stopwatch watch = Stopwatch.StartNew(); //Время выполнения
                List<Mat> brickSingList = new List<Mat>();
                List<Rectangle> brickSingBoxList = new List<Rectangle>();
                _brickSingDetector.DetectBrickSing(image, brickSingList, brickSingBoxList);
                bool success = false;

                watch.Stop(); //Таймер остановлен

                Point startPoint = new Point(10, 10);
                int numberSingBoxList = 0;

                for (int i = 0; i < brickSingList.Count; i++)
                {
                    Rectangle rect = brickSingBoxList[i];
                    
                    numberSingBoxList = i;
                    success = true;
                    CvInvoke.Rectangle(image, rect, new Bgr(Color.Aquamarine).MCvScalar, 2);
                }
                if (success)
                {
                    SaveFileBmp(brickSingList[numberSingBoxList].Bitmap, _dirCanny, _cannySingTag, fileName);
                    timeChart.Invoke(new Action<int, double>(AddCanny), _canneActuation, watch.ElapsedMilliseconds);
                    SaveFileBmp(image.Bitmap, _dirCanny, _cannySingOnImageTag, fileName);
                    _canneActuation++;
                }
                _cannyDetectTime += watch.ElapsedMilliseconds;
                Console.WriteLine(String.Format("_canneActuation : {0}", _canneActuation));
                cennyLabe.Invoke(new Action<int, double>(AddCennyLabel), _canneActuation, _cannyDetectTime);
            } catch { }


        }

        /// <summary>
        /// Сохраняем файл во временную папку
        /// </summary>
        /// <param name="image">Изображение</param>
        /// <param name="dir">Временная папка</param>
        /// <param name="tag">тэг для изображения</param>
        private void SaveFileBmp(Bitmap image, string dir, string tag, string fileName)
        {
            if ((image != null) && !StateLocalTread())
            {
                image.Save(dir + "\\" + fileName + "_" + tag + ".bmp", ImageFormat.Bmp);
            }
        }

        /// <summary>
        /// Создание временного каталога. Если каталог с таким именем уже имеется - каталог удаляется и создается заного
        /// </summary>
        /// <param name="nameDir">Путь до каталога</param>
        private void CreateDir(string nameDir)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(nameDir);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            } else
            {
                DeleteDir(nameDir);
                CreateDir(nameDir);
            }
        }

        /// <summary>
        /// Удаление дирректории с содержимым
        /// </summary>
        /// <param name="nameDir">Путь до каталога</param>
        private void DeleteDir(string nameDir)
        {
            cannyPictureBox1.Image = null;
            cannyPictureBox2.Image = null;
            haarPictureBox.Image = null;
            DirectoryInfo dirInfo = new DirectoryInfo(nameDir);
            if (dirInfo.Exists)
            {
                try
                {
                    dirInfo.Delete(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Возникла невиданная ранее ошибка! {0}", ex.Message));
                }
            }
        }

        private void AlanizeCanny()
        {
            foreach (string file in _imagePath)
            {
                using (Image<Bgr, Byte> brickSingModel = new Image<Bgr, Byte>(file))
                {
                    string fileName = file.Remove(0, file.LastIndexOf('\\') + 1);
                    fileName = fileName.Substring(0, fileName.LastIndexOf('.'));

                    Mat image = CvInvoke.Imread(file);

                    _brickSingDetector = new SingDetectorMethodCanny(brickSingModel);

                    SingDetectCanny(image, fileName);
                }
            }
        }

        private void AlanizeHaar()
        {
            foreach (string file in _imagePath)
            {
                using (Image<Bgr, Byte> brickSingModel = new Image<Bgr, Byte>(file))
                {
                    string fileName = file.Remove(0, file.LastIndexOf('\\') + 1);
                    fileName = fileName.Substring(0, fileName.LastIndexOf('.'));

                    SingDetectHaar(file, fileName);
                }
            }
        }

        private void AddCennyLabel(int empty, double time)
        {
            cennyLabe.Text = String.Format("Метод Кенни сработал {0} раз. Общее время выполнения {1} милисекунд", empty, time);
        }
        private void AddHaarLabel(int empty, double time)
        {
            haarLabel.Text = String.Format("Метод Хаара сработал {0} раз. Общее время выполнения {1} милисекунд", empty, time);
        }
        private void AddHaar(int x, double y)
        {
            timeChart.Series[0].Points.AddXY(x+1, y);
        }
        private void AddCanny(int x, double y)
        {
            timeChart.Series[1].Points.AddXY(x+1, y);
        }

        /// <summary>
        /// Проверяем состояние потоков. Если хотя бы один работает - true, инача false
        /// </summary>
        /// <returns></returns>
        private bool StateLocalTread()
        {
            if ((_analizeCannyThread != null) && (_analizeHaarThread != null))
            {
                if (((_analizeCannyThread.ThreadState & System.Threading.ThreadState.Running) > 0) || ((_analizeHaarThread.ThreadState & System.Threading.ThreadState.Running) > 0))
                {
                    return true;
                }
            }
            return false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Закрываем потоки, если работаю
            if (_analizeCannyThread != null)
            {
                _analizeCannyThread.Abort();
            }
            if (_analizeHaarThread != null)
            {
                _analizeHaarThread.Abort();
            }

            //Удаление временных каталогов
            DeleteDir(_dirCanny);
            DeleteDir(_dirHaar);
        }


        private void cleanListFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void abortThreadToolStripMenuItem_Click(object sender, EventArgs e)
        {
                _analizeCannyThread.Suspend();
                _analizeHaarThread.Suspend();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form about = new AboutBox1();
            about.Show();
        }
    }
}
