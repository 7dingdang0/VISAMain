/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              模型层的相机最佳物距标定后的结果，即输出参数                                  
 *              2021/3/13 (Copyright statement here 版权信息待定) Author: Patrick  
 **********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOI.Model
{
    /// <summary>
    /// 相机最佳物距标定后的结果，即输出参数 
    /// </summary>
    public class CameraDistanceParameters
    {
        /// <summary>
        /// 四角位置
        /// </summary>
        public FourCornerLocations FourCornerLocations
        {
            get;set;
        }

        /// <summary>
        /// 水平屏占比
        /// </summary>
        public float HorizontalScreenPercentage
        {
            get; set;
        }

        /// <summary>
        /// 垂直屏占比
        /// </summary>
        public float VerticalScreenPercentage
        {
            get; set;
        }

        /// <summary>
        /// 旋转度
        /// </summary>
        public float RorateRatio
        {
            get; set;
        }

        /// <summary>
        /// 中心偏移量 - x 轴上的
        /// </summary>
        public float CentralOffsetX
        {
            get; set;
        }

        /// <summary>
        /// 中心偏移量 - y 轴上的
        /// </summary>
        public float CentralOffsetY
        {
            get; set;
        }
    }
}
