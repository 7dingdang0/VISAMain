/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              业务逻辑层的相机测试画面拍摄最佳参数标定的类                                          
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
    /// 相机测试画面拍摄最佳参数标定的类
    /// </summary>
    public class BestPatternParametersCalibrator
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BestPatternParametersCalibrator()
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

            TestPatternID[] patternIDsToLoop = new TestPatternID[]
            { // 依次显示各输入待测亮场画面
                TestPatternID.TD001, 
                TestPatternID.TD002,
                TestPatternID.TD003, 
                TestPatternID.TD004, 
                TestPatternID.TD005
            };

            foreach (TestPatternID testPatternID in patternIDsToLoop)
            {
                if (!CalibrateWithPattern(inParameter, testPatternID))
                    return false;
            }

            // 显示待测暗场画面：黑

            // 用暗场起始拍摄参数取像

            // 根据四角位置分析预定9个ROI内归一化亮度均值

            // 线性折算循环调整曝光时间直到落入条件：9个ROI中最大灰度值＝４0+/-2%
            // 暨最佳曝光参数=目标灰度/当前灰度x 当前曝光时间

            // 击中上步目标后根据四角位置分析记录9个ROI中亮度标准差

            //this.Output = new CameraDistanceParameters();
            // 请根据以上标定设置好输出参数的各项值，调用者准备使用 Output

            // Note: 请参阅顾东东的 LabVIEW 图形代码，改写出我们的 C# 代码
            // 
            return true;
        }

        /// <summary>
        /// 根据指定的测试画面进行标定
        /// </summary>
        /// <param name="inParameter">输入参数</param>
        /// <param name="currentPatternId">当前测试画面</param>
        /// <returns>标定成功了吗？</returns>
        public bool CalibrateWithPattern(object inParameter, TestPatternID currentPatternId)
        {
            // 用亮场起始拍摄参数取像

            // 根据四角位置分析预定9个ROI内归一化亮度值

            // 线性折算循环调整曝光时间直到落入条件：9个ROI中最大归一化亮度均值＝70+/- 2%

            // 击中上步目标后根据四角位置分析记录9个ROI中亮度标准差并落入规格区间

            return true;
        }
    }
}
