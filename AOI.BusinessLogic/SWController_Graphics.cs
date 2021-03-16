/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              业务逻辑层的软件控制类 - 图像处理模块的包装                                         
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
    /// 软件控制类 - 图像处理模块的包装
    /// </summary>
    public class SWController_Graphics
    {
        /// <summary>
        /// 解析四角位置坐标并计算水平和垂直屏占比
        /// </summary>
        /// <param name="inParameter">输入参数</param>
        /// <param name="fourCornerLocations">输出四角位置坐标</param>
        /// <param name="horizentalPercentage">输出水平屏占比</param>
        /// <param name="verticalPercentage">输出垂直屏占比</param>
        /// <returns>成功与否</returns>
        public static bool ComputeFourCornerLocation(object inParameter, out FourCornerLocations fourCornerLocations, out float horizentalPercentage, out float verticalPercentage)
        {
            fourCornerLocations = null;
            horizentalPercentage = 0.0f;
            verticalPercentage = 0.0f;
            return false;
        }

        /// <summary>
        /// 分析棋盘格图像中预定 9 个 ROI 内图像的解析分辨率
        /// </summary>
        /// <param name="inParameter">输入参数</param>
        /// <param name="fourCornerLocations">四角位置坐标</param>
        /// <returns>9 个 ROI 内图像的解析分辨率</returns>
        public static NineRIOs ComputeNineROI(object inParameter, FourCornerLocations fourCornerLocations)
        {
            NineRIOs results = new NineRIOs();
            results.Data = new ROI[9];
            foreach (var v in results.Data)
            { // 未实现，请调用图像处理引擎的相关方法

            }
            return results;
        }
    }
}
