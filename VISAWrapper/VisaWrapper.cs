/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              NI VISA 通讯的包装类                                  
 *              2021/3/15 (Copyright statement here 版权信息待定) Author: Patrick  
 **********************************************************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VISAWrapper
{
    /// <summary>
    /// NI VISA 通讯的包装类
    /// </summary>
    public class VisaWrapper
    {
        /// <summary>
        /// 当 VISA 接收到远程设备的数据之后的委托方法
        /// </summary>
        /// <param name="firstByteData">第一个字节的数据，其余数据由调用者继续调用 Read 方法读取</param>
        public delegate void DataReceivedHandler(byte firstByteData);

        /// <summary>
        /// 委托
        /// </summary>
        private DataReceivedHandler OnDataReceived
        {
            get;
            set;
        }

        /// <summary>
        /// NI VISA 的资源管理器
        /// </summary>
        private int DefaultResourceManager
        {
            get;
            set;
        }

        /// <summary>
        /// 会话，相当于 Windows 里的句柄，对应于该 VISA 资源
        /// </summary>
        public int Session
        {
            get;
            private set;
        }

        /// <summary>
        ///  VISA 资源的名称
        /// </summary>
        public string ResourceName
        {
            get;
            private set;
        }

        /// <summary>
        /// 设备已经连接上了吗？
        /// </summary>
        public bool Connected
        {
            get;
            private set;
        }

        /// <summary>
        /// 构造函数，默认没有连接上
        /// </summary>
        public VisaWrapper()
        {
            this.Connected = false;
            this.DefaultResourceManager = -1;
            this.Session = -1;
        }

        /// <summary>
        /// 打开一个 VISA 资源
        /// </summary>
        /// <param name="visaResourceName">VISA 资源名</param>
        /// <param name="errorInfo">如果打开失败，返回错误信息</param>
        /// <returns>成功打开了吗?</returns>
        public bool Open(string visaResourceName, out string errorInfo)
        {
            errorInfo = null;
            if (this.Connected)
                return true;
            int defaultRM;
            int errorCode = visa32.viOpenDefaultRM(out defaultRM);
            if (errorCode != visa32.VI_SUCCESS)
            {
                switch  (errorCode)
                {
                    case visa32.VI_ERROR_SYSTEM_ERROR:
                        errorInfo = @"The VISA system failed to initialize";
                        break;
                    case visa32.VI_ERROR_ALLOC:
                        errorInfo = @"Insufficient system resources to create a session to the Default Resource Manager resource";
                        break;
                    case visa32.VI_ERROR_INV_SETUP:
                        errorInfo = @"Some implementation-specific configuration file is corrupt or does not exist";
                        break;
                    case visa32.VI_ERROR_LIBRARY_NFOUND:
                        errorInfo = @"A code library required by VISA could not be located or loaded";
                        break;
                    default:
                        errorInfo = string.Format("调用viOpenDefaultRM返回{0}", errorCode);
                        break;
                }    
                return false;
            }
            this.DefaultResourceManager = defaultRM;

            int session;
            errorCode = visa32.viOpen(this.DefaultResourceManager, visaResourceName, visa32.VI_NO_LOCK, visa32.VI_TMO_IMMEDIATE, out session);
            if (errorCode != visa32.VI_SUCCESS)
            {
                errorInfo = string.Format("调用viOpen返回{0}", errorCode);
                return false;
            }
            this.Session = session;
            this.Connected = true;
            this.ResourceName = visaResourceName;
            { // 上面打开 VISA，下面做一点清理工作，即便失败也没关系了
                visa32.viClear(this.Session);
                errorCode = visa32.viPrintf(this.Session, "*CLS\n");
                Debug.Print("调用viPrintf清除状态返回{0}", errorCode); 
            }
            return true;
        }

        /// <summary>
        /// 关闭掉当前的 VISA 资源，并释放所有的 VISA
        /// </summary>
        /// <returns>成功与否</returns>
        public bool Close()
        {
            int errorCode = 0;
            if (this.Session > 0)
            {
                errorCode = visa32.viClose(this.Session);
                Debug.Print("调用viClose返回{0}", errorCode);
                this.Session = -1;
            }

            if (this.DefaultResourceManager > 0)
            {
                errorCode = visa32.viClose(this.DefaultResourceManager);
                Debug.Print("调用viClose返回{0}", errorCode);
                this.DefaultResourceManager = -1;
            }
            this.Connected = false;
            return true;
        }

        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="attr">属性名</param>
        /// <param name="attrValue">属性值</param>
        /// <param name="errorInfo">如果返回 false,此参数返回错误信息</param>
        /// <returns>成功与否</returns>
        public bool SetAttribute(VisaAttribute attr, byte attrValue, out string errorInfo)
        {
            errorInfo = null;
            if (!this.Connected || this.Session <= 0)
            {
                errorInfo = @"请先确保已经调用 Open 并返回成功(true)";
                return false;
            }
            int errorCode = visa32.viSetAttribute(this.Session, (int)attr, attrValue);
            if (errorCode == visa32.VI_SUCCESS)
                return true;
            errorInfo = string.Format("调用viSetAttribute设置属性{0}值为{1}时返回错误代码{2}", attr.ToString(), attrValue, errorCode);
            return false;
        }

        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="attr">属性名</param>
        /// <param name="attrValue">属性值</param>
        /// <param name="errorInfo">如果返回 false,此参数返回错误信息</param>
        /// <returns>成功与否</returns>
        public bool SetAttribute(VisaAttribute attr, short attrValue, out string errorInfo)
        {
            errorInfo = null;
            if (!this.Connected || this.Session <= 0)
            {
                errorInfo = @"请先确保已经调用 Open 并返回成功(true)";
                return false;
            }
            int errorCode = visa32.viSetAttribute(this.Session, (int)attr, attrValue);
            if (errorCode == visa32.VI_SUCCESS)
                return true;
            errorInfo = string.Format("调用viSetAttribute设置属性{0}值为{1}时返回错误代码{2}", attr.ToString(), attrValue, errorCode);
            return false;
        }

        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="attr">属性名</param>
        /// <param name="attrValue">属性值</param>
        /// <param name="errorInfo">如果返回 false,此参数返回错误信息</param>
        /// <returns>成功与否</returns>
        public bool SetAttribute(VisaAttribute attr, int attrValue, out string errorInfo)
        {
            errorInfo = null;
            if (!this.Connected || this.Session <= 0)
            {
                errorInfo = @"请先确保已经调用 Open 并返回成功(true)";
                return false;
            }
            int errorCode = visa32.viSetAttribute(this.Session, (int)attr, attrValue);
            if (errorCode == visa32.VI_SUCCESS)
                return true;
            errorInfo = string.Format("调用viSetAttribute设置属性{0}值为{1}时返回错误代码{2}", attr.ToString(), attrValue, errorCode);
            return false;
        }

        /// <summary>
        /// 得到属性
        /// </summary>
        /// <param name="attr">属性名</param>
        /// <param name="attrValue">属性值</param>
        /// <param name="errorInfo">如果返回 false,此参数返回错误信息</param>
        /// <returns>成功与否</returns>
        public bool GetAttribute(VisaAttribute attr, out byte attrValue, out string errorInfo)
        {
            attrValue = 0;
            errorInfo = null;
            if (!this.Connected || this.Session <= 0)
            {
                errorInfo = @"请先确保已经调用 Open 并返回成功(true)";
                return false;
            }
            int errorCode = visa32.viGetAttribute(this.Session, (int)attr, out attrValue);
            if (errorCode == visa32.VI_SUCCESS)
                return true;
            errorInfo = string.Format("viGetAttribute得到属性{0}值时返回错误代码{1}", attr.ToString(), errorCode);
            return false;
        }

        /// <summary>
        /// 得到属性
        /// </summary>
        /// <param name="attr">属性名</param>
        /// <param name="attrValue">属性值</param>
        /// <param name="errorInfo">如果返回 false,此参数返回错误信息</param>
        /// <returns>成功与否</returns>
        public bool GetAttribute(VisaAttribute attr, out short attrValue, out string errorInfo)
        {
            attrValue = 0;
            errorInfo = null;
            if (!this.Connected || this.Session <= 0)
            {
                errorInfo = @"请先确保已经调用 Open 并返回成功(true)";
                return false;
            }
            int errorCode = visa32.viGetAttribute(this.Session, (int)attr, out attrValue);
            if (errorCode == visa32.VI_SUCCESS)
                return true;
            errorInfo = string.Format("viGetAttribute得到属性{0}值时返回错误代码{1}", attr.ToString(), errorCode);
            return false;
        }

        /// <summary>
        /// 得到属性
        /// </summary>
        /// <param name="attr">属性名</param>
        /// <param name="attrValue">属性值</param>
        /// <param name="errorInfo">如果返回 false,此参数返回错误信息</param>
        /// <returns>成功与否</returns>
        public bool GetAttribute(VisaAttribute attr, out int attrValue, out string errorInfo)
        {
            attrValue = 0;
            errorInfo = null;
            if (!this.Connected || this.Session <= 0)
            {
                errorInfo = @"请先确保已经调用 Open 并返回成功(true)";
                return false;
            }
            int errorCode = visa32.viGetAttribute(this.Session, (int)attr, out attrValue);
            if (errorCode == visa32.VI_SUCCESS)
                return true;
            errorInfo = string.Format("viGetAttribute得到属性{0}值时返回错误代码{1}", attr.ToString(), errorCode);
            return false;
        }

        /// <summary>
        /// 得到属性
        /// </summary>
        /// <param name="attr">属性名</param>
        /// <param name="attrValue">属性值</param>
        /// <param name="errorInfo">如果返回 false,此参数返回错误信息</param>
        /// <returns>成功与否</returns>
        public bool GetAttribute(VisaAttribute attr, out string attrValue, out string errorInfo)
        {
            attrValue = null;
            errorInfo = null;
            if (!this.Connected || this.Session <= 0)
            {
                errorInfo = @"请先确保已经调用 Open 并返回成功(true)";
                return false;
            }
            StringBuilder v = new StringBuilder();
            int errorCode = visa32.viGetAttribute(this.Session, (int)attr, v);
            if (errorCode == visa32.VI_SUCCESS)
            {
                attrValue = v.ToString();
                return true;
            }
            errorInfo = string.Format("viGetAttribute得到属性{0}值时返回错误代码{1}", attr.ToString(), errorCode);
            return false;
        }

        /// <summary>
        /// 清除 VISA 上的信息
        /// </summary>
        /// <param name="errorInfo">如果返回 false,此参数返回错误信息</param>
        /// <returns>成功与否</returns>
        public bool Clear(out string errorInfo)
        {
            errorInfo = null;
            if (!this.Connected || this.Session <= 0)
            {
                errorInfo = @"请先确保已经调用 Open 并返回成功(true)";
                return false;
            }
            int errorCode = visa32.viClear(this.Session);
            if (errorCode == visa32.VI_SUCCESS)
            {
                return true;
            }
            errorInfo = string.Format("viClear清除VISA状态时返回错误代码{1}", errorCode);
            return false;
        }

        /// <summary>
        /// 把未完成的数据都处理掉，一般使用 mask = 2
        /// </summary>
        /// <param name="mask">掩码，VI_READ_BUF (1)，VI_READ_BUF_DISCARD (4)，VI_WRITE_BUF (2)，VI_WRITE_BUF_DISCARD (8)，VI_IO_IN_BUF (16)，VI_IO_IN_BUF_DISCARD (64)，VI_IO_OUT_BUF (32)，VI_IO_OUT_BUF_DISCARD (128)</param>
        /// <param name="errorInfo">如果返回 false,此参数返回错误信息</param>
        /// <returns>成功与否</returns>
        public bool Flush(short mask, out string errorInfo)
        {
            errorInfo = null;
            if (!this.Connected || this.Session <= 0)
            {
                errorInfo = @"请先确保已经调用 Open 并返回成功(true)";
                return false;
            }
            int errorCode = visa32.viFlush(this.Session, mask);
            if (errorCode == visa32.VI_SUCCESS)
            {
                return true;
            }
            errorInfo = string.Format("viFlush处理未完成的数据时返回错误代码{1}", errorCode);
            return false;
        }

        /// <summary>
        /// 读一些字节出来
        /// </summary>
        /// <param name="buffer">读到本缓冲区</param>
        /// <param name="count">要读的字节数</param>
        /// <param name="countActuallyRead">实际读的数量</param>
        /// <param name="errorInfo">如果返回 false,此参数返回错误信息</param>
        /// <returns>成功与否</returns>
        public bool Read(byte[] buffer, int count, out int countActuallyRead, out string errorInfo)
        {
            countActuallyRead = 0;
            errorInfo = null;
            if (!this.Connected || this.Session <= 0)
            {
                errorInfo = @"请先确保已经调用 Open 并返回成功(true)";
                return false;
            }
            int errorCode = visa32.viRead(this.Session, buffer, count, out countActuallyRead);
            if (errorCode == visa32.VI_SUCCESS)
            {
                return true;
            }
            errorInfo = string.Format("viRead读{0}个字节时返回错误代码{1}", count, errorCode);
            return false;
        }

        /// <summary>
        /// 用异步的方式读一些字节出来
        /// </summary>
        /// <param name="buffer">读到本缓冲区</param>
        /// <param name="count">要读的字节数</param>
        /// <param name="jobId">创建的任务 ID</param>
        /// <param name="errorInfo">如果返回 false,此参数返回错误信息</param>
        /// <returns>成功与否</returns>
        public bool ReadAsync(byte[] buffer, int count, out int jobId, out string errorInfo)
        {
            jobId = -1;
            errorInfo = null;
            if (!this.Connected || this.Session <= 0)
            {
                errorInfo = @"请先确保已经调用 Open 并返回成功(true)";
                return false;
            }
            int errorCode = visa32.viReadAsync(this.Session, buffer, count, out jobId);
            if (errorCode == visa32.VI_SUCCESS)
            {
                return true;
            }
            errorInfo = string.Format("viReadAsync读{0}个字节时返回错误代码{1}", count, errorCode);
            return false;
        }

        /// <summary>
        /// 用异步的方式读一些字节出来
        /// </summary>
        /// <param name="buffer">读到本缓冲区</param>
        /// <param name="count">要读的字节数</param>
        /// <param name="jobId">创建的任务 ID</param>
        /// <param name="errorInfo">如果返回 false,此参数返回错误信息</param>
        /// <returns>成功与否</returns>
        public bool ReadToFile(string fileName, int count, ref int countActuallyRead, out string errorInfo)
        {
            errorInfo = null;
            if (!this.Connected || this.Session <= 0)
            {
                errorInfo = @"请先确保已经调用 Open 并返回成功(true)";
                return false;
            }
            int errorCode = visa32.viReadToFile(this.Session, fileName, count, ref countActuallyRead);
            if (errorCode == visa32.VI_SUCCESS)
            {
                return true;
            }
            errorInfo = string.Format("viReadToFile读{0}个字节到文件{1}时返回错误代码{2}", count, fileName, errorCode);
            return false;
        }

        /// <summary>
        /// 写一些字节到 VISA 设备里
        /// </summary>
        /// <param name="buffer">要写的本缓冲区</param>
        /// <param name="count">要写的字节数</param>
        /// <param name="countActuallyWritten">实际写的数量</param>
        /// <param name="errorInfo">如果返回 false,此参数返回错误信息</param>
        /// <returns>成功与否</returns>
        public bool Write(byte[] buffer, int count, out int countActuallyWritten, out string errorInfo)
        {
            countActuallyWritten = 0;
            errorInfo = null;
            if (!this.Connected || this.Session <= 0)
            {
                errorInfo = @"请先确保已经调用 Open 并返回成功(true)";
                return false;
            }
            int errorCode = visa32.viWrite(this.Session, buffer, count, out countActuallyWritten);
            if (errorCode == visa32.VI_SUCCESS)
            {
                return true;
            }
            errorInfo = string.Format("viWrite写{0}个字节时返回错误代码{1}", count, errorCode);
            return false;
        }

        /// <summary>
        /// 用异步的方式写一些字节到 VISA 设备
        /// </summary>
        /// <param name="buffer">要写的本缓冲区</param>
        /// <param name="count">要写的字节数</param>
        /// <param name="jobId">创建的任务 ID</param>
        /// <param name="errorInfo">如果返回 false,此参数返回错误信息</param>
        /// <returns>成功与否</returns>
        public bool WriteAsync(byte[] buffer, int count, out int jobId, out string errorInfo)
        {
            jobId = -1;
            errorInfo = null;
            if (!this.Connected || this.Session <= 0)
            {
                errorInfo = @"请先确保已经调用 Open 并返回成功(true)";
                return false;
            }
            int errorCode = visa32.viWriteAsync(this.Session, buffer, count, out jobId);
            if (errorCode == visa32.VI_SUCCESS)
            {
                return true;
            }
            errorInfo = string.Format("viWriteAsync写{0}个字节时返回错误代码{1}", count, errorCode);
            return false;
        }

        /// <summary>
        /// 用异步的方式读一些字节到 VISA 设备
        /// </summary>
        /// <param name="fileName">从本文件里读取数据写到 VISA 设备</param>
        /// <param name="count">要写的字节数</param>
        /// <param name="countActuallyWritten">实际写的数量</param>
        /// <param name="errorInfo">如果返回 false,此参数返回错误信息</param>
        /// <returns>成功与否</returns>
        public bool WriteFromFile(string fileName, int count, ref int countActuallyWritten, out string errorInfo)
        {
            errorInfo = null;
            if (!this.Connected || this.Session <= 0)
            {
                errorInfo = @"请先确保已经调用 Open 并返回成功(true)";
                return false;
            }
            int errorCode = visa32.viWriteFromFile(this.Session, fileName, count, ref countActuallyWritten);
            if (errorCode == visa32.VI_SUCCESS)
            {
                return true;
            }
            errorInfo = string.Format("viWriteFromFile从{0}文件读取{1}个字节写到VISA设备时返回错误代码{2}", fileName, count, errorCode);
            return false;
        }

        /// <summary>
        /// 暂时不知道如何设置回调方法，自行创建：基本原理是当读到至少一个字节的数据后立即调用用户的方法
        /// </summary>
        /// <param name="callback">回调方法，即用户定义的委托函数</param>
        /// <param name="millisecondsTimeout">多少毫秒后超时</param>
        public void SetDataReceivedDelegate(DataReceivedHandler callback, int millisecondsTimeout)
        {
            this.OnDataReceived = callback;

            Task.Factory.StartNew(() =>
            {
                byte[] buffer = new byte[1];
                int actuallReadCount = 0;
                string errorInfo = null;
                DateTime start = DateTime.Now;
                while (true)
                {
                    TimeSpan span = DateTime.Now - start;
                    if (this.Read(buffer, 1, out actuallReadCount, out errorInfo))
                    {
                        if (actuallReadCount == 1)
                        {
                            Debug.Print("SetDataReceivedDelegate:过了{0}毫秒，读取到了一个字节{1}，调用者应该继续自己的业务逻辑", span.TotalMilliseconds, (int)buffer[0]);
                            callback?.Invoke(buffer[0]);
                            break;
                        }
                    }
                    else
                    {
                        Debug.Print("SetDataReceivedDelegate:读取一个字符失败：{0}", errorInfo);
                    }
                    
                    if (span.TotalMilliseconds >= millisecondsTimeout)
                    {
                        Debug.Print("SetDataReceivedDelegate:已经过去了{0}毫秒，依然没有读到一个字节，超时退出", span.TotalMilliseconds);
                        break;
                    }
                }
            });
        }
    }
}
