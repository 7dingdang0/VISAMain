/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              业务逻辑层的硬件控制类 - 信号发生器的控制                                          
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
    /// 硬件控制类 - 信号发生器的控制
    /// </summary>
    public class HWController_SignalGenerator
    {
        /// <summary>
        /// 生成四角图
        /// </summary>
        /// <param name="inParameter">输入参数</param>
        /// <param name="outParameter">输出参数</param>
        /// <returns>成功与否</returns>
        public static bool GenerateFourCornerGraphic(object inParameter, out object outParameter)
        { // 根据文档，我们需要先调用信号发生器，产生图像，然后控制信号发生器显示四角图，最后显示到屏幕上
            outParameter = null;
            return false;
        }

        /// <summary>
        /// 生成棋盘格
        /// </summary>
        /// <param name="inParameter">输入参数</param>
        /// <param name="outParameter">输出参数</param>
        /// <returns>成功与否</returns>
        public static bool GenerateCheckerBoardGraphic(object inParameter, out object outParameter)
        { // 根据文档，我们需要先调用信号发生器，产生图像，然后控制信号发生器显示棋盘格，最后显示到屏幕上
            outParameter = null;
            return false;
        }
    }
}
