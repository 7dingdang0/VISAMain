/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              业务逻辑层的全局变量
 *              2021/3/15 (Copyright statement here 版权信息待定) Author: Patrick  
 **********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AOI.Model;

namespace AOI.BusinessLogic
{
    /// <summary>
    /// 业务逻辑层的全局变量
    /// </summary>
    public static class GlobalVariants
    {
        /// <summary>
        /// 数据文件的根目录
        /// 不同的机器上使用不同的目录，同一台机器上最好固定使用一个目录
        /// </summary>
        public static string DataFileRootPath = @"D:\AOIDataRootPath";

        /// <summary>
        /// 产品数据文件的根目录，相当于 LabVIEW 里的 model_select 目录
        /// 不同的机器上使用不同的目录，同一台机器上最好固定使用一个目录
        /// </summary>
        public static string ProductDataFilesRootPath = @"D:\AOIDataRootPath\ModelsRoot";

        /// <summary>
        /// 所有的产品信息，建议 UI 层一上来就读出来全部
        /// </summary>
        public static List<ProductInfo> AllProducts = null;
    }
}
