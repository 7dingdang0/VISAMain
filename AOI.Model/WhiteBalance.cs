/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              模型层的白平衡信息结构                                          
 *              2021/3/13 (Copyright statement here 版权信息待定) Author: Patrick  
 **********************************************************************************/

namespace AOI.Model
{
    /// <summary>
    /// 白平衡信息结构，针对彩色相机
    /// </summary>
    public class WhiteBalance
    {
        /// <summary>
        /// RIG
        /// 如果确定 RIG 的值的类型不是浮点数，请更改类型
        /// </summary>
        public float RIG
        {
            get; set;
        }

        /// <summary>
        /// BIG
        /// 如果确定 BIG 的值的类型不是浮点数，请更改类型
        /// </summary>
        public float BIG
        {
            get; set;
        }
    }
}
