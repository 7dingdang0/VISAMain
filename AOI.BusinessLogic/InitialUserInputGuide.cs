/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              业务逻辑层的用户初始化输入的向导类  
 *              这应该是本系统第一个被调用的业务逻辑层的对象
 *              2021/3/13 (Copyright statement here 版权信息待定) Author: Patrick  
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
    /// 用户初始化输入的向导类
    /// </summary>
    public class InitialUserInputGuide
    {
        /// <summary>
        /// 用户输入或选中的产品信息
        /// 只有当 Guide 返回 true 之后本对象才被生成，一次生成永久使用
        /// </summary>
        public static ProductInfo ProductInfo
        {
            get;
            private set;
        }

        /// <summary>
        /// 唯一的公共方法，引导用户，内部分为几个步骤
        /// 只有返回成功才会创建 ProductInfo
        /// </summary>
        /// <returns>成功 - true, 失败 - false</returns>
        public static bool Guide()
        {
            // 调用 UI，给两个选择，扫描产品(屏幕)，或者创建新产品

            // 如果扫描的产品在配置文件里存在，读取出产品信息，否则调用 UI 让用户输入产品信息

            // 第三步，测试画面设置，是否调用相机，是否调用分析模块

            // 创建测试流程 (Test Sequence & Settings)

            // 最后一步，等待用户点击 "校验" 按钮成功返回

            ProductInfo = new ProductInfo()
            {

            };
            return true;
        }
    }
}
