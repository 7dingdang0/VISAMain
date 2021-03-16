/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              业务逻辑层的 EXE 可执行工具的调用的封装类                                          
 *              2021/3/13 (Copyright statement here 版权信息待定) Author: Patrick  
 **********************************************************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOI.BusinessLogic
{
    /// <summary>
    /// EXE 可执行工具的调用的封装类 
    /// </summary>
    public class ExecutableInvokerWrapper
    {
        /// <summary>
        /// BlemishDefectInspector.exe
        /// </summary>
        public static string Executable_BlemishDefectInspector = @"BlemishDefectInspector.exe";

        /// <summary>
        /// PandoraVison.exe
        /// </summary>
        public static string Executable_PandoraVison = @"PandoraVison.exe";

        /// <summary>
        /// ProjectW.exe
        /// </summary>
        public static string Executable_ProjectW = @"ProjectW.exe";

        /// <summary>
        /// 启动一个进程
        /// </summary>
        /// <param name="executable">进程名</param>
        /// <param name="args">参数</param>
        /// <param name="errorInfo">如果返回 null, 本参数返回错误消息</param>
        /// <returns>进程对象</returns>
        public static Process InvokeExecutable(string executable, string args, out string errorInfo)
        {
            errorInfo = null;
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.FileName = executable;
                processStartInfo.Arguments = args;
                processStartInfo.UseShellExecute = true;
                Process process = new Process
                {
                    EnableRaisingEvents = true,
                    StartInfo = processStartInfo
                };
                if (!process.Start())
                    errorInfo = string.Format("Process.Start({0}) with arg:{1} failed", executable, args);
                else
                    return process;
            }
            catch (Exception ex)
            {
                errorInfo = string.Format("启动进程{0}失败，异常:{1}", executable, ex.Message);
            }
            return null;
        }

        /// <summary>
        /// 启动一个 BlemishDefectInspector.exe 为进程
        /// BlemishDefectInspector.exe -mode <batch|single> -algo <algo_name> <argument_list>
        /// BlemishDefectInspector.exe -mode single -algo <algo_name> -imageFile <image_file_path> [-<variable_name> <variable_value>]
        /// BlemishDefectInspector.exe -mode batch -algo<algo_name>[-< variable_name > < variable_value >]
        /// <algo_name> is json configuration file name without extension
        /// For example, '-algo blob' means Configuration/blob.json will be loaded
        /// .json configuration file must be under Configuration folder
        /// Variable can be used in .json configuration file and specify value in command line.
        /// For example, a variable $radius is defined in .json file, '-radius 12' will specify value of radius
        /// </summary>
        /// <param name="singleModeOrBatch">true - 分析单个文件的模式, false - 多个的模式</param>
        /// <param name="algorism">算法</param>
        /// <param name="variables">其它的参数</param>
        /// <param name="errorInfo">如果返回 null, 本参数返回错误消息</param>
        /// <returns>进程对象</returns>
        public static Process InvokeBlemishDefectInspector(
            bool singleModeOrBatch,
            string algorism,
            IEnumerable<KeyValuePair<string, string>> variables,
            out string errorInfo)
        {
            errorInfo = null;
            if (variables == null || variables.Count() <= 0)
            {
                errorInfo = @"InvokeBlemishDefectInspector: 参数错误，至少有一个除模式和算法之外的参数";
                return null;
            }
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("-mode {0} -algo {1} ", singleModeOrBatch ? "single" : "batch", algorism); // mode & algo 是两个必要的参数
            foreach (KeyValuePair<string, string> eachVariable in variables)
            { // 其它参数
                stringBuilder.AppendFormat(" -{0} {1}", eachVariable.Key, eachVariable.Value);
            }
            return InvokeExecutable(
                Executable_BlemishDefectInspector,
                stringBuilder.ToString(),
                out errorInfo);
        }

        /// <summary>
        /// 分析单个文件，即调用 BlemishDefectInspector 给与一个参数 -mode single
        /// </summary>
        /// <param name="singleImageFileName">要分析的单个图片文件名</param>
        /// <param name="maskImageFileName">掩码图片文件名</param>
        /// <param name="outputFolder">输出路径</param>
        /// <param name="algorism">算法</param>
        /// <param name="variables">其它的参数</param>
        /// <param name="errorInfo">如果返回 null, 本参数返回错误消息</param>
        /// <returns>进程对象</returns>
        public static Process BlemishDefectInspector_InvokeAsSingleMode(
            string singleImageFileName, 
            string maskImageFileName, 
            string outputFolder,
            string algorism,
            IEnumerable<KeyValuePair<string, string>> variables,
            out string errorInfo)
        {
            List<KeyValuePair<string, string>> allVariables = new List<KeyValuePair<string, string>>();
            allVariables.Add(new KeyValuePair<string, string>("imageFile", singleImageFileName));
            allVariables.Add(new KeyValuePair<string, string>("mask", maskImageFileName));
            allVariables.Add(new KeyValuePair<string, string>("source", "unused"));
            allVariables.Add(new KeyValuePair<string, string>("output_folder", outputFolder));
            if (variables != null)
                allVariables.AddRange(variables);
            return InvokeBlemishDefectInspector(
                true,
                algorism,
                allVariables,
                out errorInfo);
        }

        /// <summary>
        /// 分析一个目录下的所有文件，即调用 BlemishDefectInspector 给与一个参数 -mode batch
        /// </summary>
        /// <param name="sourceDirectory">要分析的图片文件所在的目录</param>
        /// <param name="algorism">算法</param>
        /// <param name="maskImageFileName">掩码图片文件名</param>
        /// param name="variables">其它的参数</param>
        /// <param name="errorInfo">如果返回 null, 本参数返回错误消息</param>
        /// <returns>进程对象</returns>
        public static Process BlemishDefectInspector_InvokeAsBatchMode(
            string sourceDirectory,
            string algorism,
            string maskImageFileName,
            IEnumerable<KeyValuePair<string, string>> variables,
            out string errorInfo)
        {
            List<KeyValuePair<string, string>> allVariables = new List<KeyValuePair<string, string>>();
            allVariables.Add(new KeyValuePair<string, string>("mask", maskImageFileName));
            allVariables.Add(new KeyValuePair<string, string>("source", sourceDirectory));
            if (variables != null)
                allVariables.AddRange(variables);
            return InvokeBlemishDefectInspector(
                false,
                algorism,
                allVariables,
                out errorInfo);
        }
    }
}
