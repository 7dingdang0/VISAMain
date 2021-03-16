/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              模型层的四角坐标的包装类                                          
 *              2021/3/13 (Copyright statement here 版权信息待定) Author: Patrick  
 **********************************************************************************/
using System.Drawing;

namespace AOI.Model
{
    /// <summary>
    /// 四角坐标的包装类
    /// 四个点不会构成一个规则的矩形
    /// </summary>
    public class FourCornerLocations
    {
        /// <summary>
        /// 左上顶点
        /// </summary>
        public PointF TopLeft
        {
            get;set;
        }

        /// <summary>
        /// 右上点
        /// </summary>
        public PointF TopRight
        {
            get; set;
        }

        /// <summary>
        /// 左下顶点
        /// </summary>
        public PointF BottomLeft
        {
            get; set;
        }

        /// <summary>
        /// 右下点
        /// </summary>

        public PointF BottomRight
        {
            get; set;
        }
    }
}
