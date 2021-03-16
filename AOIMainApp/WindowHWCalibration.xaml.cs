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
        /// 基于产品的硬件标定流程的哪一步
        /// </summary>
        public enum Step
        {
            /// <summary>
            /// 每个测试画面及其相机等的设置
            /// </summary>
            TestPattern
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
                    PageTestPatterns pageTestPatterns = new PageTestPatterns();
                    this.Content = pageTestPatterns;
                    break;
            }
        }
    }
}
