/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              业务逻辑层的总的业务逻辑
 *              2021/3/15 (Copyright statement here 版权信息待定) Author: Patrick  
 **********************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AOI.Model;

namespace AOI.BusinessLogic
{
    /// <summary>
    /// 总的业务逻辑
    /// </summary>
    public static class GeneralBusinessLogic
    {
        /// <summary>
        /// 从配置文件里读取出来全部的产品信息
        /// 读出来的全部产品信息都将放到 GlobalVariants.AllProducts
        /// </summary>
        /// <returns>成功或失败</returns>
        public static bool LoadAllProducts()
        {
            IEnumerable<string> all = AOIConfigurations.ReadOutAllProducts();
            if (all == null || all.Count() <= 0)
                return false; // 不可能读不到任何产品名称，实际上就是产品信息根目录下的子目录名
            int startId = 1;
            GlobalVariants.AllProducts = new List<ProductInfo>();
            foreach (var v in all)
            { // 产品信息的其它几个参数暂时还未读取 TODO: 请把其它参数都从配置文件里读出来
                ProductInfo productInfo = new ProductInfo()
                {
                    ID = startId,
                    Name = v,
                    Model = v
                };
                GlobalVariants.AllProducts.Add(productInfo);
                startId++;
            }
            return true;
        }
    }
}
