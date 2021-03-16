/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              业务逻辑层的光学测量的类                                          
 *              2021/3/13 (Copyright statement here 版权信息待定) Author: Patrick  
 **********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOI.BusinessLogic
{
    /// <summary>
    /// 光学测量的类 
    /// </summary>
    public class OpticalMeasurementManager
    {
        /// <summary>
        /// 开始测量
        /// </summary>
        /// <returns>成功返回 true, 失败返回 false</returns>
        public static bool Start()
        {
            // 第一步，取图后调用分析模块计算粗/细分区下的RGB Map

            // 第二步，对照同样分区下平场图的RGB Map做归一化（相除）

            // 第三步，依照权重表做修正生成Luminance/Chromaticity Map

            // 第四步，计算粗分区3 x 3 九ROI方框内色亮度均匀性

            // 第五步，计算细分区30x30全分区网格全局色亮度均匀性

            return false;
        }
    }
}
