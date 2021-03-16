/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              业务逻辑层的所有算法分析模块的类                                          
 *              2021/3/13 (Copyright statement here 版权信息待定) Author: Patrick  
 **********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOI.BusinessLogic
{
    /// <summary>
    /// 所有算法分析模块的类
    /// </summary>
    public class AllAlgorism
    {
        /// <summary>
        /// 所有的算法分析数据
        /// </summary>
        public static string[] Data
        {
            get;
            private set;
        }

        /// <summary>
        /// 加载所有的算法分析数据
        /// 程序刚开始的时候一次性读取
        /// </summary>
        /// <returns>加载成功否？</returns>
        public static bool LoadAllData()
        {
            return false;
        }
    }
}
