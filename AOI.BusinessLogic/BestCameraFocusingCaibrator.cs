/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              业务逻辑层的相机最佳焦距标定的类                                          
 *              2021/3/13 (Copyright statement here 版权信息待定) Author: Patrick  
 **********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AOI.Model;

namespace AOI.BusinessLogic
{
    /// <summary>
    /// 相机最佳焦距标定的类 
    /// </summary>
    public class BestCameraFocusingCaibrator
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BestCameraFocusingCaibrator()
        {

        }

        /// <summary>
        /// 初始化，暂时未实现
        /// </summary>
        /// <returns>初始化成功了没有</returns>
        public bool Initiaize()
        {
            return false;
        }

        /// <summary>
        /// 开始标定
        /// 当调用初始化 Initialize 返回 true 之后，即可调用本方法
        /// </summary>
        /// <param name="inParameter">输入参数</param>
        /// <returns>标定成功了吗？</returns>
        public bool Calibrate(object inParameter)
        {
            //this.Output = null; // 刚开始标定的时候，输出值清空

            object returnVaueOfCheckerBoardGraphic;
            if (!HWController_SignalGenerator.GenerateCheckerBoardGraphic(null, out returnVaueOfCheckerBoardGraphic))
            {  // 第一步让屏幕显示棋盘格
                return false;
            }

            object returnValueOfCameraTakingShot;
            if (!HWController_Camera.TakeShot(null, out returnValueOfCameraTakingShot))
            { // 第二步用棋盘图的起始拍摄参数取像
                return false;
            }

            FourCornerLocations fourCornerLocations = null; //  请使用最佳相机物距标定得到的参数值中的四角位置
            NineRIOs nineRIOs = SWController_Graphics.ComputeNineROI(null, fourCornerLocations);
            if (nineRIOs == null)
            { // 第三步分析棋盘格中 9 个 ROIs 的图像解析分辨率
                return false;
            }

            // 根据 3.19 方案，暂时没有马达，此处需要等待用户手动调整相机，从远端位置循环调整对焦马达位置至中心 RIO
            // 图像解析率 > 75%，9个 ROI 之间差异 < 10%

            // 击中上步目标后再次显示四角图，如何显示四角图？

            float horizontalPercentage; // 水平屏占比
            float verticalPercentage; // 垂直屏占比
            if (!SWController_Graphics.ComputeFourCornerLocation(null, out fourCornerLocations, out horizontalPercentage, out verticalPercentage))
            { // 第五步，用四角图起始拍摄参数取像，再次解析四角位置并计算更新参数旋转度、倾斜度，中心偏移量，并计算水平和垂直屏占比
                return false;
            }

            // 第六步根据四角位置计算域内屏幕有效区域总像素并计算总系统放大率（有效区域总像素除以输入屏幕面积）

            // 第七步，根据四角位置确定将来相机ROI Cropping区域

            // 第八步，根据四角位置确定将来取图后的分区外框（用于建立大小分区）与内框（联合外框用于确认中心和上下左右边缘区）

            //this.Output = new CameraDistanceParameters();
            // 请根据以上标定设置好输出参数的各项值，调用者准备使用 Output

            // Note: 请参阅顾东东的 LabVIEW 图形代码，改写出我们的 C# 代码
            // 
            return true;
        }

    }
}
