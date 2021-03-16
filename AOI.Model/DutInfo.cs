/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              模型层的相机信息结构                                          
 *              2021/3/13 (Copyright statement here 版权信息待定) Author: Patrick  
 **********************************************************************************/
using System;
using System.Drawing;

namespace AOI.Model
{
    /// <summary>
    /// 待测产品信息
    /// </summary>
    public class DutInfo
    {
        /// <summary>
        /// 屏幕型号
        /// </summary>
        public string Model
        {
            get;set;    
        }

        /// <summary>
        /// 屏幕有效区尺寸
        /// 如果确定长和宽是整数，请更改类型为 System.Drawing.Size,而不使用 SizeF
        /// </summary>
        public SizeF Size
        {
            get; set;
        }

        /// <summary>
        /// 屏幕分辨率
        /// </summary>
        public int Resolution
        {
            get;set;
        }
    }
}
