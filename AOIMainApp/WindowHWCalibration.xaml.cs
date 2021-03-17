/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              UI 层的硬件标定的主窗口，内部包含很多 Pages
 *              2021/3/16 (Copyright statement here 版权信息待定) Author: Patrick  
 **********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AOIMainApp
{
    /// <summary>
    /// WindowHWCalibration.xaml 的交互逻辑
    /// </summary>
    public partial class WindowHWCalibration : Window
    {
        /// <summary>
        /// 用户选择的产品名称
        /// </summary>
        public string chooseProductName { get; set; }

        /// <summary>
        /// 基于产品的硬件标定流程的哪一步
        /// </summary>
        public enum Step
        {
            /// <summary>
            /// 每个测试画面及其相机等的设置
            /// </summary>
            TestPattern,

            /// <summary>
            /// 四角图各相机起始拍摄参数设置
            /// </summary>
            FourCorner,

            /// <summary>
            /// 棋盘图各相机起始拍摄参数
            /// </summary>
            CheckerBoard
        }

        public WindowHWCalibration()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 进入到哪一步，就准备显示相应的页面
        /// </summary>
        /// <param name="step">步骤</param>
        public void GoToStep(Step step)
        {
            switch (step)
            {
                case Step.TestPattern:
                    PageTestPatterns pageTestPatterns = new PageTestPatterns(chooseProductName);
                    this.Content = pageTestPatterns;
                    break;

                case Step.FourCorner:
                    PageFourCornerSettings pageFourCornerSettings = new PageFourCornerSettings();
                    this.Content = pageFourCornerSettings;
                    break;

                case Step.CheckerBoard:
                    //PageTestPatterns pageTestPatterns = new PageTestPatterns();
                    //this.Content = pageTestPatterns;
                    break;
            }
        }
    }
}
