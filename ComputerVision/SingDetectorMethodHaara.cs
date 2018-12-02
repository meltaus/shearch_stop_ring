using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Cuda;
using Emgu.CV.CvEnum;
using System.Drawing;
using System.Diagnostics;

namespace ComputerVision
{
    public class SingDetectorMethodHaara
    {
        /// <summary>
        /// Нахождение знака по методу Хаара
        /// </summary>
        /// <param name="image">Исходное изображение</param>
        /// <param name="singFileName">Путь до каскада</param>
        /// <param name="sings">Список знаков на изображении</param>
        /// <param name="detectionTime">Время выполнения</param>
        public void Detect (IInputArray image, String singFileName, List<Rectangle> sings, out long detectionTime)
        {
            Stopwatch watch;
            using (InputArray iaImage = image.GetInputArray())
            {
                if (iaImage.Kind == InputArray.Type.CudaGpuMat && CudaInvoke.HasCuda)
                {
                    using (CudaCascadeClassifier sing = new CudaCascadeClassifier(singFileName))
                    {
                        sing.ScaleFactor = 1.1;             //Коэфициент увеличения
                        sing.MinNeighbors = 10;             //Группировка предварительно обнаруженных событий. Чем их меньше, тем больше ложных тревог
                        sing.MinObjectSize = Size.Empty;    //Минимальный размер

                        watch = Stopwatch.StartNew();       //Таймер
                        //Конвентируем изображение в серый цвет, подготавливаем регион с возможными вхождениями знаков на изображении
                        using (CudaImage<Bgr, Byte> gpuImage = new CudaImage<Bgr, byte>(image))
                        using (CudaImage<Gray, Byte> gpuGray = gpuImage.Convert<Gray, Byte>())
                        using (GpuMat region = new GpuMat())
                        {
                            sing.DetectMultiScale(gpuGray, region);
                            Rectangle[] singRegion = sing.Convert(region);
                            sings.AddRange(singRegion);
                        }
                        watch.Stop();
                    }
                } else
                {
                    //Читаем HaarCascade
                    using (CascadeClassifier sing = new CascadeClassifier(singFileName))
                    {
                        watch = Stopwatch.StartNew();

                        using (UMat ugray = new UMat())
                        {
                            CvInvoke.CvtColor(image, ugray, ColorConversion.Bgr2Gray);

                            //Приводим в норму яркость и повышаем контрастность
                            CvInvoke.EqualizeHist(ugray, ugray);

                            //Обнаруживаем знак на сером изображении и сохраняем местоположение в виде прямоугольника
                            Rectangle[] singsDetected = sing.DetectMultiScale(
                                ugray,              //Исходное изображение
                                1.1,                //Коэффициент увеличения изображения
                                10,                 //Группировка предварительно обнаруженных событий. Чем их меньше, тем больше ложных тревог
                                new Size(20, 20));  //Минимальный размер

                            sings.AddRange(singsDetected);
                            
                        }
                        watch.Stop();
                    }
                }
            }
            detectionTime = watch.ElapsedMilliseconds;
        }
    }
}
