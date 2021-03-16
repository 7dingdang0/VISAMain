using AOI.BusinessLogic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AOIMainApp
{
    /// <summary>
    /// PageTestPatterns.xaml 的交互逻辑
    /// </summary>
    public partial class PageTestPatterns : Page
    {
        /// <summary>
        /// 用户选择的产品名称
        /// </summary>
        public string chooseProductName { get; set; }

        public PageTestPatterns()
        {
            InitializeComponent();
        }

        public PageTestPatterns(string productName)
        {
            InitializeComponent();
            this.chooseProductName = productName;
            Page_Load();
        }

        /// <summary>
        /// 窗口刚加载时查出所有节点值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Load()  //object sender, RoutedEventArgs e
        {
            if (chooseProductName != string.Empty)
            {
                List<string> sections = AOIConfigurations.ReadOutAllFromINI(chooseProductName);
                if (sections != null && sections.Count > 0)
                {
                    this.listAllTestPatterns.ItemsSource = null;   //在使用ItemsSource之前，项集合必须为空
                    this.listAllTestPatterns.ItemsSource = sections;
                }
                else
                    MessageBox.Show(
                    string.Format("当前配置文件{0}未能读取出来任何节点", chooseProductName),
                    "读取节点失败",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }
        }

        /// <summary>
        /// 当选择节点时触发，刷新其他两个页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectProduct_SelectionChanged(object sender, System.EventArgs e)
        {
            string NodeName = this.listAllTestPatterns.SelectedValue.ToString();
            //读取指定节点的所有信息，以Key=Value形式返回
            AOIConfigurations.ReadOutSingleNodeFromINI(chooseProductName, NodeName);
            //读取指定节点和key的Value信息
            string led = AOIConfigurations.ReadOutSingleNodeByKey(chooseProductName, NodeName, "LED", "enable");
            string times = AOIConfigurations.ReadOutSingleNodeByKey(chooseProductName, NodeName, "times", "enable");
            string pat = AOIConfigurations.ReadOutSingleNodeByKey(chooseProductName, NodeName, "PAT", "enable");
            string enable = AOIConfigurations.ReadOutSingleNodeByKey(chooseProductName, NodeName, "enable", "enable");
            UserControlTestPattern userControlTestPattern = new UserControlTestPattern(times, pat, enable);
        }
    }
}
