/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              每个 ROI (Region of Interest)点的信息的包装类                                          
 *              2021/3/13 (Copyright statement here 版权信息待定) Author: Patrick  
 **********************************************************************************/
using System.Drawing;

namespace AOI.Model
{
    /// <summary>
    /// 每个 ROI (Region of Interest)点的信息的包装类
    /// </summary>
    public class ROI
    {
        /// <summary>
        /// 该 ROI 所在的矩形
        /// </summary>
        public RectangleF Rectangle
        {
            get;set;
        }

        /// <summary>
        /// 图像的解析分辨率
        /// </summary>
        public float Resolution
        {
            get;set;
        }

        /// <summary>
        /// 标注，保留的属性，可用于内部目的或自定义目的
        /// </summary>
        public object Tag
        {
            get;set;
        }
    }
}
