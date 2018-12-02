using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.Util;
using Emgu.CV.XFeatures2D;
using System.Drawing;

namespace ComputerVision
{
    public class SingDetectorMethodCanny : DisposableObject
    {
        private VectorOfKeyPoint _modelKeypoints;   //Модель изображения с ключевыми вхождениями требуемых точек
        private Mat _modelDescriptors;              //Модель с описанием требуемых точек
        private BFMatcher _modelDescriptorMatcher;  //Модель с описание совпадений искомых точек
        private SURF _detector;                     
        private VectorOfPoint _octagon;             //Искомая область

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="brickSingModel">Обрабатываемое изображение. Принимается Image<Bgr, Byte></param>
        public SingDetectorMethodCanny(IInputArray brickSingModel)
        {
            _detector = new SURF(500);
            
            using (Mat redMask = new Mat())
            {
                GetRedPixelMask(brickSingModel, redMask);
                _modelKeypoints = new VectorOfKeyPoint();
                _modelDescriptors = new Mat();
                _detector.DetectAndCompute(redMask, null, _modelKeypoints, _modelDescriptors, false);
                if (_modelKeypoints.Size == 0)
                {
                    //throw new Exception("Изображение для обработки не загружено");
                }
            }

            _modelDescriptorMatcher = new BFMatcher(DistanceType.L2);
            _modelDescriptorMatcher.Add(_modelDescriptors);
            
            _octagon = new VectorOfPoint(
                new Point[] {
                    new Point(1, 0),
                    new Point(2, 0),
                    new Point(3, 1),
                    new Point(3, 2),
                    new Point(2, 3),
                    new Point(1, 3),
                    new Point(0, 2),
                    new Point(0, 1)
                });
        }

        /// <summary>
        /// Поиск знака. Метод Кенни (поиск по границам)
        /// </summary>
        /// <param name="img">Исходное изображение</param>
        /// <param name="brickSingList">Список знаков на изображении</param>
        /// <param name="boxList">Список областей со знаком</param>
        /// <param name="contours">Контур</param>
        /// <param name="hierachy"></param>
        /// <param name="idx"></param>
        private void FindBrickSing(Mat img, List<Mat> brickSingList, List<Rectangle> boxList, VectorOfVectorOfPoint contours, int[,] hierachy, int idx)
        {
            for (; idx >= 0; idx = hierachy[idx, 0])
            {
                using (VectorOfPoint c = contours[idx])
                using (VectorOfPoint approx = new VectorOfPoint())
                {
                    CvInvoke.ApproxPolyDP(c, approx, CvInvoke.ArcLength(c, true) * 0.02, true);
                    double area = CvInvoke.ContourArea(approx);

                    if (area > 200)
                    {
                        double ratio = CvInvoke.MatchShapes(_octagon, approx, ContoursMatchType.I3);

                        if (ratio > 0.1)    //Подходящих совпадений не найдено
                        {
                            if (hierachy[idx, 2] >= 0)
                            {
                                FindBrickSing(img, brickSingList, boxList, contours, hierachy, hierachy[idx, 2]);
                            }
                            continue;
                        }

                        Rectangle box = CvInvoke.BoundingRectangle(c);

                        Mat candidate = new Mat();
                        
                        //Поиск кандидата на искомое вхождение
                        using (Mat tmp = new Mat(img, box))
                        {
                            CvInvoke.CvtColor(tmp, candidate, ColorConversion.Bgr2Gray);
                        }

                        //Устанавливаем значение пикселей вне контура равным нулю
                        using (Mat mask = new Mat(candidate.Size.Height, candidate.Width, DepthType.Cv8U, 1))
                        {
                            mask.SetTo(new MCvScalar(0));
                            CvInvoke.DrawContours(mask, contours, idx, new MCvScalar(255), -1, LineType.EightConnected, null, int.MaxValue, new Point(-box.X, -box.Y));
                            double mean = CvInvoke.Mean(candidate, mask).V0;

                            CvInvoke.Threshold(candidate, candidate, mean, 255, ThresholdType.Binary);
                            CvInvoke.BitwiseNot(candidate, candidate);
                            CvInvoke.BitwiseNot(mask, mask);

                            candidate.SetTo(new MCvScalar(0), mask);
                        }

                        int minMatchCount = 0;
                        double uniquenessThreshold = 0.0;
                        VectorOfKeyPoint observaredKeyPoint = new VectorOfKeyPoint();
                        Mat observeredDescriptor = new Mat();
                        _detector.DetectAndCompute(candidate, null, observaredKeyPoint, observeredDescriptor, false);

                        //Обозначаем искомое вхождение
                        if (observaredKeyPoint.Size >= minMatchCount)
                        {
                            int i = 2;
                            Mat mask;

                            using (VectorOfVectorOfDMatch matches = new VectorOfVectorOfDMatch())
                            {
                                _modelDescriptorMatcher.KnnMatch(observeredDescriptor, matches, i, null);
                                mask = new Mat(matches.Size, 1, DepthType.Cv8U, 1);
                                Features2DToolbox.VoteForUniqueness(matches, uniquenessThreshold, mask);
                            }

                            int nonZeroCount = CvInvoke.CountNonZero(mask);

                            if (nonZeroCount >= minMatchCount)
                            {
                                boxList.Add(box);
                                brickSingList.Add(candidate);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Нахождение знака крулглой, треугольной и квадратной формы на изображении
        /// </summary>
        /// <param name="img">Исходное изображение</param>
        /// <param name="brickSingList">Список знаков на изображении</param>
        /// <param name="boxList">Список возможных мест со знаками</param>
        public void DetectBrickSing(Mat img, List<Mat> brickSingList, List<Rectangle> boxList)
        {
            #region Find ring
            Mat smoothImg = new Mat();
            CvInvoke.GaussianBlur(img, smoothImg, new Size(5, 5), 1.5, 1.5);

            Mat smoothedResMask = new Mat();
            GetRedPixelMask(smoothImg, smoothedResMask);

            //Установка зазоров в контурах
            CvInvoke.Dilate(smoothedResMask, smoothImg, null, new Point(-1, -1), 1, BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue);
            CvInvoke.Erode(smoothedResMask, smoothImg, null, new Point(-1, -1), 1, BorderType.Constant, CvInvoke.MorphologyDefaultBorderValue);

            //Нахождение требуемого контура
            using (Mat canny = new Mat())
            using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
            {
                CvInvoke.Canny(smoothedResMask, canny, 100, 50);
                int[,] hierachy = CvInvoke.FindContourTree(canny, contours, ChainApproxMethod.ChainApproxSimple);

                if (hierachy.GetLength(0) > 0)
                {
                    FindBrickSing(img, brickSingList, boxList, contours, hierachy, 0);
                }
            }
            #endregion
        }

        /// <summary>
        /// Нахадит пиксели с красным цветом
        /// </summary>
        /// <param name="image">Изображение для обработки</param>
        /// <param name="mask">Пиксельная маска</param>
        private static void GetRedPixelMask(IInputArray image, IInputOutputArray mask)
        {
            bool useUMat;
            using (InputOutputArray ia = mask.GetInputOutputArray())
            {
                useUMat = ia.IsUMat;
            }

            using (IImage hsv = useUMat ? (IImage)new UMat() : (IImage)new Mat())
            using (IImage s = useUMat ? (IImage)new UMat() : (IImage)new Mat())
            {
                CvInvoke.CvtColor(image, hsv, ColorConversion.Bgr2Hsv);
                CvInvoke.ExtractChannel(hsv, mask, 0);
                CvInvoke.ExtractChannel(hsv, s, 1);

                //По маске от 20 до 160
                using (ScalarArray lower = new ScalarArray(20))
                using (ScalarArray upper = new ScalarArray(160))
                {
                    CvInvoke.InRange(mask, lower, upper, mask);
                }

                CvInvoke.BitwiseNot(mask, mask);

                //маска для насыщения не менее 10
                CvInvoke.Threshold(s, s, 15, 255, ThresholdType.Binary);
                CvInvoke.BitwiseAnd(mask, s, mask, null);
            }
        }

        protected override void DisposeObject()
        {
            if (_modelKeypoints != null)
            {
                _modelKeypoints.Dispose();
                _modelKeypoints = null;
            }
            if (_modelDescriptors != null)
            {
                _modelDescriptors.Dispose();
                _modelDescriptors = null;
            }
            if (_modelDescriptorMatcher != null)
            {
                _modelDescriptorMatcher.Dispose();
                _modelDescriptorMatcher = null;
            }
            if (_octagon != null)
            {
                _octagon.Dispose();
                _octagon = null;
            }
        }
    }
}
