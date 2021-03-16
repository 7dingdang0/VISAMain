/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              业务逻辑层的缺陷检测的类                                          
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
    /// 缺陷检测的类
    /// </summary>
    public class DefectChecker
    {
        /// <summary>
        /// 开始检测
        /// </summary>
        /// <returns>成功返回 true, 失败返回 false</returns>
        public static bool Start()
        {
            // 第一步，显示白画面各相机取像，调用ＭＡＳＫ生成模块生成ＭＡＳＫ图样

            // 第二步，显示其余各待测画面预定各相机用硬件标定的参数取像

            // 第三步，并行调用软件标定中生成的分析模块和分析引擎

            // 第四步，输出生成各画面各相机各分析模块缺陷信息

            // 第五步，显示除尘屏并取像

            // 第六步 经除尘过滤，坏点过滤和信息增强生成新的缺陷特征表

            // 第七步，决策归类，输出不良代码和缺陷特征向量
            return false;
        }
    }
}
