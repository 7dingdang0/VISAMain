/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              业务逻辑层的硬件控制类 - 马达的控制                                          
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
    /// 硬件控制类 - 马达的控制 
    /// </summary>
    public class HWController_Engine
    {
        /// <summary>
        /// 得到马达的当前位置
        /// </summary>
        /// <param name="inParameter">输入参数</param>
        /// <param name="outParameter">输出参数</param>
        /// <returns>成功与否</returns>
        public static bool GetCurrentLocation(object inParameter, out object outParameter)
        {
            outParameter = null;
            return false;
        }

        /// <summary>
        /// 设置马达的相对位置
        /// 按照我的想法，给正数将从近处往外运动，给负数从远处往近处运动
        /// </summary>
        /// <param name="inParameter">输入参数</param>
        /// <param name="distanceParameter">位置参数，很可能是浮点数类型</param>
        /// <returns>成功与否</returns>
        public static bool SetLocation(object inParameter, object distanceParameter)
        {
            return false;
        }

        /// <summary>
        /// 得到马达的当前对焦值
        /// </summary>
        /// <param name="inParameter">输入参数</param>
        /// <param name="outParameter">输出参数</param>
        /// <returns>成功与否</returns>
        public static bool GetCurrentFocusing(object inParameter, out object outParameter)
        {
            outParameter = null;
            return false;
        }

        /// <summary>
        /// 设置马达的对焦值
        /// 按照我的想法，给正数将往大的对焦运动，给负数往小的对焦运动
        /// </summary>
        /// <param name="inParameter">输入参数</param>
        /// <param name="focusingParameter">对焦参数，很可能是浮点数类型</param>
        /// <returns>成功与否</returns>
        public static bool SetFocusing(object inParameter, object focusingParameter)
        {
            return false;
        }
    }
}
