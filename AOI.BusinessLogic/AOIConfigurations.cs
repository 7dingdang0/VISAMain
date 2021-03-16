/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              业务逻辑层的配置读取的类
 *              2021/3/15 (Copyright statement here 版权信息待定) Author: Patrick  
 **********************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AOI.BusinessLogic
{
    /// <summary>
    /// 配置读取的类
    /// </summary>
    public static class AOIConfigurations
    {
        /// <summary>
        /// 为INI文件中指定的节点取得字符串
        /// </summary>
        /// <param name="lpAppName">欲在其中查找关键字的节点名称</param>
        /// <param name="lpKeyName">欲获取的项名</param>
        /// <param name="lpDefault">指定的项没有找到时返回的默认值</param>
        /// <param name="lpReturnedString">指定一个字串缓冲区，长度至少为nSize</param>
        /// <param name="nSize">指定装载到lpReturnedString缓冲区的最大字符数量</param>
        /// <param name="lpFileName">INI文件完整路径</param>
        /// <returns>复制到lpReturnedString缓冲区的字节数量，其中不包括那些NULL中止字符</returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        /// <summary>
        /// 修改INI文件中内容
        /// </summary>
        /// <param name="lpApplicationName">欲在其中写入的节点名称</param>
        /// <param name="lpKeyName">欲设置的项名</param>
        /// <param name="lpString">要写入的新字符串</param>
        /// <param name="lpFileName">INI文件完整路径</param>
        /// <returns>非零表示成功，零表示失败</returns>
        [DllImport("kernel32")]
        private static extern int WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);

        /// <summary>
        /// 获取所有节点名称(Section)
        /// </summary>
        /// <param name="lpszReturnBuffer">存放节点名称的内存地址,每个节点之间用\0分隔</param>
        /// <param name="nSize">内存大小(characters)</param>
        /// <param name="lpFileName">Ini文件</param>
        /// <returns>内容的实际长度,为0表示没有内容,为nSize-2表示内存大小不够</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern uint GetPrivateProfileSectionNames(IntPtr lpszReturnBuffer, uint nSize, string lpFileName);

        /// <summary>
        /// 获取某个指定节点(Section)中所有KEY和Value
        /// </summary>
        /// <param name="lpAppName">节点名称</param>
        /// <param name="lpReturnedString">返回值的内存地址,每个之间用\0分隔</param>
        /// <param name="nSize">内存大小(characters)</param>
        /// <param name="lpFileName">Ini文件</param>
        /// <returns>内容的实际长度,为0表示没有内容,为nSize-2表示内存大小不够</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern uint GetPrivateProfileSection(string lpAppName, IntPtr lpReturnedString, uint nSize, string lpFileName);

        /// <summary>
        /// 读取INI文件中指定的Key的值
        /// </summary>
        /// <param name="lpAppName">节点名称。如果为null,则读取INI中所有节点名称,每个节点名称之间用\0分隔</param>
        /// <param name="lpKeyName">Key名称。如果为null,则读取INI中指定节点中的所有KEY,每个KEY之间用\0分隔</param>
        /// <param name="lpDefault">读取失败时的默认值</param>
        /// <param name="lpReturnedString">读取的内容缓冲区，读取之后，多余的地方使用\0填充</param>
        /// <param name="nSize">内容缓冲区的长度</param>
        /// <param name="lpFileName">INI文件名</param>
        /// <returns>实际读取到的长度</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, [In, Out] char[] lpReturnedString, uint nSize, string lpFileName);



        /// <summary>
        /// 根据配置目录下的子目录的名称读出来全部的产品名称
        /// 即 LabVIEW 里的 model_select 名字
        /// </summary>
        /// <returns>全部的产品(模型)名称</returns>
        public static IEnumerable<string> ReadOutAllProducts()
        {
            try
            {
                List<string> results = new List<string>();
                foreach (var v in Directory.EnumerateDirectories(GlobalVariants.ProductDataFilesRootPath, "*", SearchOption.TopDirectoryOnly))
                {
                    string productName = Path.GetFileName(v);
                    results.Add(productName);
                }
                return results;
            }
            catch
            { }
            return null;
        }

        /// <summary>
        /// 根据选择的产品名称读相应产品名称文件夹下的snap_set.ini配置文件中的所有节点
        /// </summary>
        /// <returns>所有节点名称</returns>
        public static List<string> ReadOutAllFromINI(string productName)
        {
            string path = GlobalVariants.ProductDataFilesRootPath + @"\" + productName + @"\" + "snap_set.ini";   //选定的产品信息路径
            if (!File.Exists(path))
                return null;
            else     //开始读取配置文件里的信息
            {
                string[] sections = INIGetAllSectionNames(path);  //所有节点名称
                if (sections == null || sections.Length <=0 )
                {
                    return null;
                }
                List<string> sectionList = new List<string>();
                foreach (string sec in sections)
                {
                    sectionList.Add(sec);
                }
                return sectionList;
                    //ReadINI("dust", "main_WB1", string.Empty, path);
            }

        }

        /// <summary>
        /// 根据选择的节点名称读取节点信息
        /// </summary>
        /// <returns>当前节点信息</returns>
        public static List<string> ReadOutSingleNodeFromINI(string productName, string NodeName)
        {
            string path = GlobalVariants.ProductDataFilesRootPath + @"\" + productName + @"\" + "snap_set.ini";   //选定的产品信息路径
            if (!File.Exists(path))
                return null;
            else     //开始读取配置文件里的信息
            {
                string[] sections = INIGetAllItems(path, NodeName);  //所有节点名称
                if (sections == null || sections.Length <= 0)
                {
                    return null;
                }
                List<string> sectionList = new List<string>();
                foreach (string sec in sections)
                {
                    sectionList.Add(sec);
                }
                return sectionList;
                //ReadINI("dust", "main_WB1", string.Empty, path);
            }

        }

        /// <summary>
        /// 根据选择的节点名称和指定的Key值读取节点信息
        /// </summary>
        /// <returns>当前节点信息</returns>
        public static string ReadOutSingleNodeByKey(string productName, string NodeName, string key, string defaultValue)
        {
            string path = GlobalVariants.ProductDataFilesRootPath + @"\" + productName + @"\" + "snap_set.ini";   //选定的产品信息路径
            if (!File.Exists(path))
                return null;
            else     //开始读取配置文件里的信息
            {
                string sections = INIGetStringValue(path, NodeName, key, defaultValue);  //所有节点名称
                if (sections == null || sections != string.Empty)
                {
                    return sections;
                }
            }
            return null;
        }

        /// <summary>
        /// 读取INI文件值
        /// </summary>
        /// <param name="section">节点名</param>
        /// <param name="key">键</param>
        /// <param name="def">未取到值时返回的默认值</param>
        /// <param name="filePath">INI文件完整路径</param>
        /// <returns>读取的值</returns>
        public static string ReadINI(string section, string key, string def, string filePath)
        {
            StringBuilder sb = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, sb, 1024, filePath);
            return sb.ToString();
        }

        /// <summary>
        /// 读取INI文件中指定INI文件中的所有节点名称(Section)
        /// </summary>
        /// <param name="iniFile">Ini文件</param>
        /// <returns>所有节点,没有内容返回string[0]</returns>
        public static string[] INIGetAllSectionNames(string iniFile)
        {
            uint MAX_BUFFER = 32767;    //默认为32767
            string[] sections = new string[0];      //返回值
            //申请内存
            IntPtr pReturnedString = Marshal.AllocCoTaskMem((int)MAX_BUFFER * sizeof(char));
            uint bytesReturned = GetPrivateProfileSectionNames(pReturnedString, MAX_BUFFER, iniFile);
            if (bytesReturned != 0)
            {
                //读取指定内存的内容
                string local = Marshal.PtrToStringAuto(pReturnedString, (int)bytesReturned).ToString();
                //每个节点之间用\0分隔,末尾有一个\0
                sections = local.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
            }
            //释放内存
            Marshal.FreeCoTaskMem(pReturnedString);
            return sections;
        }

        /// <summary>
        /// 获取INI文件中指定节点(Section)中的所有条目(key=value形式)
        /// </summary>
        /// <param name="iniFile">Ini文件</param>
        /// <param name="section">节点名称</param>
        /// <returns>指定节点中的所有项目,没有内容返回string[0]</returns>
        public static string[] INIGetAllItems(string iniFile, string section)
        {
            //返回值形式为 key=value,例如 Color=Red
            uint MAX_BUFFER = 32767;    //默认为32767
            string[] items = new string[0];      //返回值
            //分配内存
            IntPtr pReturnedString = Marshal.AllocCoTaskMem((int)MAX_BUFFER * sizeof(char));
            uint bytesReturned = GetPrivateProfileSection(section, pReturnedString, MAX_BUFFER, iniFile);
            if (!(bytesReturned == MAX_BUFFER - 2) || (bytesReturned == 0))
            {
                string returnedString = Marshal.PtrToStringAuto(pReturnedString, (int)bytesReturned);
                items = returnedString.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
            }
            Marshal.FreeCoTaskMem(pReturnedString);     //释放内存
            return items;
        }

        /// <summary>

        /// 读取INI文件中指定KEY的字符串型值

        /// </summary>
        /// <param name="iniFile">Ini文件</param>
        /// <param name="section">节点名称</param>
        /// <param name="key">键名称</param>
        /// <param name="defaultValue">如果没此KEY所使用的默认值</param>
        /// <returns>读取到的值</returns>
        public static string INIGetStringValue(string iniFile, string section, string key, string defaultValue)
        {
            string value = defaultValue;
            const int SIZE = 1024 * 10;
            if (string.IsNullOrEmpty(section))
            {
                throw new ArgumentException("必须指定节点名称", "section");
            }
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("必须指定键名称(key)", "key");
            }
            StringBuilder sb = new StringBuilder(SIZE);
            int bytesReturned = GetPrivateProfileString(section, key, defaultValue, sb, SIZE, iniFile);
            if (bytesReturned != 0)
            {
                value = sb.ToString();
            }
            sb = null;
            return value;
        }

        /// <summary>
        /// 写INI文件值
        /// </summary>
        /// <param name="section">欲在其中写入的节点名称</param>
        /// <param name="key">欲设置的项名</param>
        /// <param name="value">要写入的新字符串</param>
        /// <param name="filePath">INI文件完整路径</param>
        /// <returns>非零表示成功，零表示失败</returns>
        public static int Write(string section, string key, string value, string filePath)
        {
            return WritePrivateProfileString(section, key, value, filePath);
        }

        /// <summary>
        /// 删除节
        /// </summary>
        /// <param name="section">节点名</param>
        /// <param name="filePath">INI文件完整路径</param>
        /// <returns>非零表示成功，零表示失败</returns>
        public static int DeleteSection(string section, string filePath)
        {
            return Write(section, null, null, filePath);
        }

        /// <summary>
        /// 删除键的值
        /// </summary>
        /// <param name="section">节点名</param>
        /// <param name="key">键名</param>
        /// <param name="filePath">INI文件完整路径</param>
        /// <returns>非零表示成功，零表示失败</returns>
        public static int DeleteKey(string section, string key, string filePath)
        {
            return Write(section, key, null, filePath);
        }
    }
}
