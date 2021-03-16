/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              UI 层的主窗口
 *              2021/3/15 (Copyright statement here 版权信息待定) Author: Patrick  
 **********************************************************************************/
using System;
using System.Windows;

namespace AOIMainApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 登录按钮点击之后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.textUserName.Text) || string.IsNullOrEmpty(this.textPassword.Password))
            {
                this.textStatus.Text = "空的用户名和密码，请输入正确的用户名和密码";
                return;
            }
            WindowScanDut windowScanDut = new WindowScanDut();
            windowScanDut.Show();      //显示窗体
            this.Close();
        }

        /// <summary>
        /// 关闭按钮点击之后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            /*if (MessageBox.Show(
                "您确认要退出本程序吗？一旦确定将关闭本程序，下次进行 AOI 请重新运行本程序。",
                "您确认要退出本程序吗?",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)*/ // 登录界面可以不用提示
            {
                this.Close();
                return;
            }
        }
    }
}
