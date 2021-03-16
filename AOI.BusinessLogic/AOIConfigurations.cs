/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              业务逻辑层的配置读取的类
 *              2021/3/15 (Copyright statement here 版权信息待定) Author: Patrick  
 **********************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOI.BusinessLogic
{
    /// <summary>
    /// 配置读取的类
    /// </summary>
    public static class AOIConfigurations
    {
        /// <summary>
        /// 根据配置目录下的子目录的名称读出来全部的产品名称
        /// 即 LabVIEW 里的 model_select 名字
        /// </summary>
        /// <returns>全部的产品(模型)名称</returns>
        public static IEnumerable<string> ReadOutAllProducts()
        {
            try
            {
                List<string> results = new List<string>();
                foreach (var v in Directory.EnumerateDirectories(GlobalVariants.ProductDataFilesRootPath, "*", SearchOption.TopDirectoryOnly))
                {
                    string productName = Path.GetFileName(v);
                    results.Add(productName);
                }
                return results;
            }
            catch
            { }
            return null;
        }
    }
}
