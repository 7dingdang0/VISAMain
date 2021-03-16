/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              模型层的相机信息结构                                          
 *              2021/3/13 (Copyright statement here 版权信息待定) Author: Patrick  
 **********************************************************************************/
namespace AOI.Model
{
    /// <summary>
    /// 相机信息
    /// </summary>
    public class CameraInfo
    {
        /// <summary>
        /// 相机 ID
        /// </summary>
        public CameraID Id
        {
            get;set;
        }

        /// <summary>
        /// 屏幕分辨率
        /// </summary>
        public int Resolution
        {
            get; set;
        }

        /// <summary>
        /// 所属物距马达行程
        /// 变量名可以修改，英文不太贴近功能
        /// </summary>
        public float MaxDistance
        {
            get; set;
        }

        /// <summary>
        /// 对焦马达行程
        /// 变量名可以修改，英文不太贴近功能
        /// </summary>
        public float MaxFocusing
        {
            get; set;
        }
    }
}
