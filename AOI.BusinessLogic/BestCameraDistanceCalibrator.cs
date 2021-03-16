/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              业务逻辑层的相机最佳物距标定的类                                          
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
    /// 业务逻辑层的相机最佳物距标定的类
    /// </summary>
    public class BestCameraDistanceCalibrator
    {
        /// <summary>
        /// 相机最佳物距标定成功后的输出参数
        /// </summary>
        public CameraDistanceParameters Output
        {
            get;
            private set;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public BestCameraDistanceCalibrator()
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
            this.Output = null; // 刚开始标定的时候，输出值清空

            object returnVaueOfFourCornerGraphic;
            if (!HWController_SignalGenerator.GenerateFourCornerGraphic(null, out returnVaueOfFourCornerGraphic))
            {  // 第一步让屏幕显示四角图
                return false;
            }

            object returnValueOfCameraTakingShot;
            if (!HWController_Camera.TakeShot(null, out returnValueOfCameraTakingShot))
            { // 第二步用四角图的起始拍摄参数取像
                return false;
            }

            FourCornerLocations fourCornerLocations;
            float horizontalPercentage; // 水平屏占比
            float verticalPercentage; // 垂直屏占比
            if (!SWController_Graphics.ComputeFourCornerLocation(null, out fourCornerLocations, out horizontalPercentage, out verticalPercentage))
            { // 第三步解析四角位置坐标，并计算水平和垂直屏占比
                return false;
            }

            /*if (!this.MoveDistanceEngineToTarget(null, 0.8f, 0.8f))
            { // 第四步从远端位置调整物距马达至水平或垂直屏占比中最大规格值 > 80%
                return false;
            }

            if (!this.MoveFocusingEngineToTarget(null, 0.8f, 0.8f, null))
            { // 第五步，解析四角位置坐标，再次计算屏占比，旋转度，倾斜度，中心偏移量，以上参数与提供的规格比较
                return false;
            }*/
            // 根据 3.19 方案，暂时没有马达，此处需要等待用户手动调整相机

            this.Output = new CameraDistanceParameters();
            // 请根据以上标定设置好输出参数的各项值，调用者准备使用 Output
            return true;
        }

        /// <summary>
        /// 调整马达物距，直到水平或垂直屏占比中的最大规格值大于期望值
        /// 注意：只要屏占比未到期望值，请循环调整马达物距
        /// 本方法中需要循环调用 HWController_Engine 调整马达物距，调用 HWController_Camera 照相，调用 SWController_Graphics 做图像处理
        /// Note: 根据 3.19 方案，暂时没有马达，所以本方法暂时不要实现
        /// </summary>
        /// <param name="inParameter">输入参数</param>
        /// <param name="expectedHorizentalPercentage">水平屏占比的期望值</param>
        /// <param name="expectedVerticalPercentage">垂直屏占比的期望值</param>
        /// <returns>成功还是失败</returns>
        public bool MoveDistanceEngineToTarget(object inParameter, float expectedHorizentalPercentage, float expectedVerticalPercentage)
        {
            return false;
        }

        /// <summary>
        /// 调整对焦马达，计算屏幕的各种参数到达期望值
        /// 注意：只要未到期望值，请循环调整马达对焦
        /// 还需要加入逻辑：判断是否有对焦马达，如果没有，要允许用户手动调焦
        /// 本方法中需要循环调用 HWController_Engine 调整马达对焦，调用 HWController_Camera 照相，调用 SWController_Graphics 做图像处理
        /// Note: 根据 3.19 方案，暂时没有马达，所以本方法暂时不要实现
        /// </summary>
        /// <param name="inParameter">输入参数</param>
        /// <param name="expectedHorizentalPercentage">水平屏占比的期望值</param>
        /// <param name="expectedVerticalPercentage">垂直屏占比的期望值</param>
        /// <param name="otherExpectedParameterValues">其它期望的参数值</param>
        /// <returns>成功还是失败</returns>
        public bool MoveFocusingEngineToTarget(object inParameter, float expectedHorizentalPercentage, float expectedVerticalPercentage, object otherExpectedParameterValues)
        {
            return false;
        }
    }
}
