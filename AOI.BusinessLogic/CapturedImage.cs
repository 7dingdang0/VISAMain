/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              业务逻辑层的捕捉到的图像的类                                          
 *              2021/3/13 (Copyright statement here 版权信息待定) Author: Patrick  
 **********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AOI.Model;

namespace AOI.BusinessLogic
{
    /// <summary>
    /// 捕捉到的图像的类
    /// </summary>
    public class CapturedImage
    {
        /// <summary>
        /// 根据参数确定图片的名称
        /// </summary>
        /// <param name="barcode">条码</param>
        /// <param name="dateTime">日期时间</param>
        /// <param name="testId">测试号</param>
        /// <param name="stationId">机台号</param>
        /// <param name="testPatternID">测试画面 ID</param>
        /// <param name="cameraID">相机 ID</param>
        /// <param name="shotTimes">拍摄次数</param>
        /// <returns>图片名称</returns>
        public static string ComposeImageFile(
            string barcode, 
            DateTime dateTime,
            int testId,
            int stationId,
            TestPatternID testPatternID, 
            CameraID cameraID,
            int shotTimes)
        {
            return null;
        }

        /// <summary>
        /// 根据图片的名称解码得到参数们
        /// </summary>
        /// <param name="fileName">图片文件名</param>
        /// <param name="barcode">条码</param>
        /// <param name="dateTime">日期时间</param>
        /// <param name="testId">测试号</param>
        /// <param name="stationId">机台号</param>
        /// <param name="testPatternId">测试画面 ID</param>
        /// <param name="cameraId">相机 ID</param>
        /// <param name="shotTimes">拍摄次数</param>
        /// <returns>成功解码了吗？</returns>
        public static bool DecodeFromImageFileName(
            string fileName,
            out string barcode,
            out DateTime dateTime,
            out int testId,
            out int stationId,
            out TestPatternID testPatternId,
            out CameraID cameraId,
            out int shotTimes)
        {
            barcode = null;
            dateTime = DateTime.MinValue;
            testId = -1;
            stationId = -1;
            testPatternId = TestPatternID.Unknown;
            cameraId = CameraID.Unknown;
            shotTimes = -1;
            return false;
        }

    }
}
