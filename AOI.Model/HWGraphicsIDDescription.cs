/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              模型层的硬件校验图样 ID 的描述                                 
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
    /// 硬件校验图样 ID 的描述
    /// </summary>
    public class HWGraphicsIDDescription
    {
        /// <summary>
        /// 硬件校验图样 ID
        /// </summary>
        public HWGraphicsID Id
        {
            get; set;
        }

        /// <summary>
        /// 中文描述
        /// </summary>
        public string ChineseDescription
        {
            get; set;
        }

        /// <summary>
        /// 英文描述
        /// </summary>
        public string EnglishDescription
        {
            get; set;
        }

        public HWGraphicsIDDescription()
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">硬件校验图样 ID</param>
        /// <param name="ch">中文描述</param>
        /// <param name="en">英文描述</param>
        public HWGraphicsIDDescription(HWGraphicsID id, string ch, string en)
        {
            this.Id = id;
            this.ChineseDescription = ch;
            this.EnglishDescription = en;
        }

        /// <summary>
        /// 静态变量，预定义的全部硬件校验图样 ID 及其描述
        /// </summary>
        public static HWGraphicsIDDescription[] AllTestPatternIDDescriptions = new HWGraphicsIDDescription[5]
            {
                new HWGraphicsIDDescription(HWGraphicsID.HW001_4Corner, "四角图", "FourCorner"),
                new HWGraphicsIDDescription(HWGraphicsID.HW002_6Corner, "六角图", "SixCorner"),
                new HWGraphicsIDDescription(HWGraphicsID.HW003_CheckerBoard, "棋盘格", "CheckerBoard"),
                new HWGraphicsIDDescription(HWGraphicsID.HW004_BrightFlatField, "亮平场图", "BrightFlatField"),
                new HWGraphicsIDDescription(HWGraphicsID.HW005_DarkFlatField, "暗平场图", "DarkFlatField")
            };
    }
}
