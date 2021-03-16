/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *        业务逻辑层的基于产品的软件标定 - 缺陷起始检测规格设定的类                                          
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
    /// 缺陷起始检测规格设定的类
    /// </summary>
    public class SWSettings_DefectInit
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SWSettings_DefectInit()
        {

        }

        /// <summary>
        /// 初始化，暂时未实现
        /// </summary>
        /// <returns>初始化成功了没有</returns>
        public bool Initiaize()
        {
            return false;
        }

        /// <summary>
        /// 开始标定
        /// 当调用初始化 Initialize 返回 true 之后，即可调用本方法
        /// </summary>
        /// <param name="inParameter">输入参数</param>
        /// <returns>标定成功了吗？</returns>
        public bool Calibrate(object inParameter)
        {
            //this.Output = null; // 刚开始标定的时候，输出值清空

// 应用硬件标定中产生的各画面硬件配置参数

// 利用第一步中生成的四角位置计算并配置相机上长方形Crop区域：

//  再次显示四角图

// 用四角图拍摄参数取像解析Crop后新的四角位置坐标

// 应用第一步中产生的各画面拍摄配置参数，

/*
 依此显示标准缺陷模拟样品图样 （模拟的点类（亮点，暗点）和斑类不良（亮斑，暗斑））
先显示各画面暗态缺陷图样，取像后从起始分析模块（微观／宏观）中的配置参数循环迭代 （。。。。此处增加参数的列表，参数的可调整范围，调整优先次序，调整方向和调整步进宽度） 直到击中所有９个预定位置（Ｔ１～Ｔ９中心）的预定暗态缺陷，过检数量＞＝目标数量（９个） 且位置符合预期且缺陷绝对面积符合预期，如果100次后仍然不达，中止并汇报NG。 达成后，应用相同配置检测同画面标签同类型亮态缺陷，如顺利击中所有９个预定位置（Ｔ１～Ｔ９中心）的预定亮态缺陷。如无法击中，在原来基础上迭代分析模块（微观／宏观）中的配置参数直到击中所有９个预定位置（Ｔ１～Ｔ９中心）的预定亮态缺陷，如果100次后仍然不达，中止并汇报NG。再次返回暗态缺陷画面再次确认。循环执行直到一组分析配置适用并击中所有暗亮态缺陷。
为各画面留存击中目标缺陷所用的最佳配置文件及参数，并输出与该配置文件相应的各画面各相机检测到的各预定区域９个缺陷特征空间各参数。
*/

//this.Output = new CameraDistanceParameters();
// 请根据以上标定设置好输出参数的各项值，调用者准备使用 Output

// Note: 请参阅顾东东的 LabVIEW 图形代码，改写出我们的 C# 代码
// 
return true;
}
}
}
