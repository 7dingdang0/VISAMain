/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              模型层的相机起始拍摄参数                                      
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
    /// 相机起始拍摄参数   
    /// </summary>
    public class CameraShotSettings
    {
        /// <summary>
        /// 增益
        /// 如果确定增益的值的类型不是浮点数，请更改类型
        /// </summary>
        public float Gain
        {
            get; set;
        }

        /// <summary>
        /// 曝光时间
        /// 如果确定曝光时间的值的类型不是浮点数，请更改类型
        /// </summary>
        public float Exposure
        {
            get; set;
        }

        /// <summary>
        /// 白平衡，针对彩色相机
        /// </summary>
        public WhiteBalance WhiteBalance
        {
            get; set;
        }
    }
}
