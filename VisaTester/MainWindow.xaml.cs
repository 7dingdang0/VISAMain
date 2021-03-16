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

using VISAWrapper;

namespace VisaTester
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 包装 VISA 的对象
        /// </summary>
        private VisaWrapper visaWrapper = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 关闭程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 打开 VISA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOpenVisa_Click(object sender, RoutedEventArgs e)
        {
            if (this.visaWrapper == null)
                this.visaWrapper = new VisaWrapper();
            string errorInfo;
            if (!this.visaWrapper.Open(this.textVisaResourceName.Text, out errorInfo))
            {
                MessageBox.Show(errorInfo, "试图打开VISA失败", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBox.Show(
                string.Format("打开{0}成功，您可以测试读、写或设置属性了", this.visaWrapper.ResourceName),
                "打开VISA成功", 
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        /// <summary>
        /// 关闭 VISA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCloseVisa_Click(object sender, RoutedEventArgs e)
        {
            if (this.visaWrapper != null)
            {
                this.visaWrapper.Close();
                this.visaWrapper = null;
            }
        }

        /// <summary>
        /// 得到属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonGet_Click(object sender, RoutedEventArgs e)
        {
            if (this.visaWrapper != null)
            {
                int v;
                string errorInfo;
                if (this.visaWrapper.GetAttribute(VisaAttribute.VI_ATTR_ASRL_BAUD, out v, out errorInfo))
                {
                    Dictionary<string, object> allProperties = null;
                    Dictionary<string, object> existingProperties = this.listviewVisaProperties.ItemsSource as Dictionary<string, object>;
                    if (existingProperties != null)
                        allProperties = existingProperties;
                    else
                        allProperties = new Dictionary<string, object>();

                    string attrName = @"波特率";
                    allProperties[attrName] = v;

                    this.listviewVisaProperties.ItemsSource = null;
                    this.listviewVisaProperties.ItemsSource = allProperties;
                }
                else
                {
                    MessageBox.Show(errorInfo, "无法得到属性", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSet_Click(object sender, RoutedEventArgs e)
        {
            if (this.visaWrapper != null)
            {
                int baud = 9600 * (new Random().Next() % 10 + 1);
                string errorInfo;
                if (this.visaWrapper.SetAttribute(VisaAttribute.VI_ATTR_ASRL_BAUD, baud, out errorInfo))
                {
                    MessageBox.Show(string.Format("设置波特率为{0}", baud), "成功设置了属性", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(errorInfo, "无法得到属性", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// 读按钮点击了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRead_Click(object sender, RoutedEventArgs e)
        {
            if (this.visaWrapper != null)
            {
                byte[] buffer = new byte[100];
                int count;
                string errorInfo;
                if (this.visaWrapper.Read(buffer, 100, out count, out errorInfo))
                {
                    this.textRead.Text = Encoding.UTF8.GetString(buffer, 0, count);
                }
                else
                {
                    MessageBox.Show(errorInfo, "无法读", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// 写按钮按下了
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWrite_Click(object sender, RoutedEventArgs e)
        {
            if (this.visaWrapper != null)
            {
                string text = this.textWrite.Text;
                if (string.IsNullOrEmpty(text))
                {
                    return;
                }
                byte[] buffer = Encoding.UTF8.GetBytes(text);
                int count;
                string errorInfo;
                if (this.visaWrapper.Write(buffer, buffer.Length, out count, out errorInfo))
                {
                    MessageBox.Show(string.Format("写了{0}个字节的数据", count), "写成功了", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(errorInfo, "无法写", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
