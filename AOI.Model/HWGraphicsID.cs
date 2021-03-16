/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              模型层的硬件校验图样 ID 的枚举                                   
 *              2021/3/13 (Copyright statement here 版权信息待定) Author: Patrick  
 **********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOI.Model
{
    /// <summary>
    /// 硬件校验图样 ID 的枚举
    /// </summary>
    public enum HWGraphicsID : int
    {
        Unknown = 0,
        HW001_4Corner,
        HW002_6Corner,
        HW003_CheckerBoard,
        HW004_BrightFlatField,
        HW005_DarkFlatField
    }
}
