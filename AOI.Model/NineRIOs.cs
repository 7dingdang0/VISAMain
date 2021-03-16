/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              模型层的棋盘格中九个 ROI (Region of Interest)点的信息的包装类                                          
 *              2021/3/13 (Copyright statement here 版权信息待定) Author: Patrick  
 **********************************************************************************/

namespace AOI.Model
{
    /// <summary>
    /// 棋盘格中九个 ROI (Region of Interest)点的信息的包装类     
    /// </summary>
    public class NineRIOs
    {
        /// <summary>
        /// 数据，即那九个 ROI，在 setter 中请确保其数量为 9
        /// </summary>
        public ROI[] Data
        {
            get;set;
        }
    }
}
