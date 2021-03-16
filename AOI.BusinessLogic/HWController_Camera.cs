/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              业务逻辑层的硬件控制类 - 相机的控制                                          
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
    /// 硬件控制类 - 相机的控制 
    /// </summary>
    public class HWController_Camera
    {
        /// <summary>
        /// 控制相机取像
        /// </summary>
        /// <param name="inParameter">输入参数</param>
        /// <param name="outParameter">输出参数</param>
        /// <returns>成功与否</returns>
        public static bool TakeShot(object inParameter, out object outParameter)
        {
            outParameter = null;
            return false;
        }
    }
}
