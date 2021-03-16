/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              模型层的相机 ID 的描述                                 
 *              2021/3/13 (Copyright statement here 版权信息待定) Author: Patrick  
 **********************************************************************************/
namespace AOI.Model
{
    /// <summary>
    /// 相机 ID 的描述
    /// </summary>
    public class CameraIDDescription
    {
        /// <summary>
        /// 相机 ID
        /// </summary>
        public CameraID Id
        {
            get;set;
        }

        /// <summary>
        /// 中文描述
        /// </summary>
        public string ChineseDescription
        {
            get;set;
        }

        /// <summary>
        /// 英文描述
        /// </summary>
        public string EnglishDescription
        {
            get; set;
        }

        public CameraIDDescription()
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">相机 ID</param>
        /// <param name="ch">中文描述</param>
        /// <param name="en">英文描述</param>
        public CameraIDDescription(CameraID id, string ch, string en)
        {
            this.Id = id;
            this.ChineseDescription = ch;
            this.EnglishDescription = en;
        }

        /// <summary>
        /// 静态变量，预定义的全部相机 ID 及其描述
        /// </summary>
        public static CameraIDDescription[] AllCameraIDDescriptions = new CameraIDDescription[9]
            {
                new CameraIDDescription(CameraID.MC001, "主相机黑白", "MainMono"),
                new CameraIDDescription(CameraID.MC002, "主相机黑白右侧", "MainMonoRight"),
                new CameraIDDescription(CameraID.MC003, "主相机黑白左侧", "MainMonoLeft"),
                new CameraIDDescription(CameraID.MC004, "主相机彩色", "MainColor"),
                new CameraIDDescription(CameraID.MC005, "主相机高速", "MainHighSpeed"),
                new CameraIDDescription(CameraID.SC001, "侧相机右", "SideRight"),
                new CameraIDDescription(CameraID.SC002, "侧相机左", "SideLeft"),
                new CameraIDDescription(CameraID.SC003, "侧相机上", "SideTop"),
                new CameraIDDescription(CameraID.SC004, "侧相机下", "SideBottom")
            };

    }
}
