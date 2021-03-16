/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              UI 层的产品选择界面
 *              2021/3/15 (Copyright statement here 版权信息待定) Author: Patrick  
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

using AOI.BusinessLogic;
using AOI.Model;

namespace AOIMainApp
{
    /// <summary>
    /// WindowScanDut.xaml 的交互逻辑
    /// </summary>
    public partial class WindowScanDut : Window
    {
        public WindowScanDut()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 注册一个新产品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonNewProduct_Click(object sender, RoutedEventArgs e)
        {
            WindowNewProduct windowNewProduct = new WindowNewProduct();
            windowNewProduct.Show();
        }

        /// <summary>
        /// 手动选择一个已有的产品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonProductModel_Click(object sender, RoutedEventArgs e)
        {
            if (this.comboProducts.SelectedItem == null)
                return;
            //string test = AOIConfigurations.ReadOutAllFromINI(this.comboProducts.Text);
            WindowHWCalibration windowHWCalibration = new WindowHWCalibration();
            windowHWCalibration.chooseProductName = this.comboProducts.Text;           //传递用户选择的产品名称
            windowHWCalibration.Show();
            windowHWCalibration.GoToStep(WindowHWCalibration.Step.TestPattern);
            this.Close();
        }

        /// <summary>
        /// 窗口刚加载完应该做的事情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            if (!GeneralBusinessLogic.LoadAllProducts())
            {
                MessageBox.Show(
                    string.Format("请确保产品根目录{0}下有以产品型号命名的子目录，当前未能读取出来任何子目录名", GlobalVariants.ProductDataFilesRootPath),
                    "读取产品型号失败",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                this.Close();
                return;
            }
            this.comboProducts.ItemsSource = null;
            this.comboProducts.ItemsSource = GlobalVariants.AllProducts;  //绑定产品名称到comboProducts
        }
    }
}
