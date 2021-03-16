/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              模型层的产品信息的结构                                
 *              2021/3/14 (Copyright statement here 版权信息待定) Author: Patrick  
 **********************************************************************************/
using System.Drawing;
using System.ComponentModel;

namespace AOI.Model
{
    /// <summary>
    /// 产品信息的结构
    /// </summary>
    public class ProductInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int id;

        /// <summary>
        /// 产品唯一的 ID
        /// 暂时没有看出实际的用处，可以在初始化的时候让它自动加一，从 1 开始
        /// </summary>
        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
                this.OnPropertyChanged("ID");
            }
        }

        private string name;

        /// <summary>
        /// 产品的名称
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.OnPropertyChanged("Name");
            }
        }

        private string model;

        /// <summary>
        /// 产品的规格
        /// </summary>
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
                this.OnPropertyChanged("Model");
            }
        }

        private Rectangle rect;

        /// <summary>
        /// 屏幕的尺寸
        /// 未来如果有小数，可以把数据类型更改为 RectangleF
        /// </summary>
        public Rectangle ScreenRect
        {
            get
            {
                return this.rect;
            }
            set
            {
                this.rect = value;
                this.OnPropertyChanged("ScreenRect");
            }
        }

        private int resolution;

        /// <summary>
        /// 分辨率
        /// </summary>
        public int Resolution
        {
            get
            {
                return this.resolution;
            }
            set
            {
                this.resolution = value;
                this.OnPropertyChanged("Resolution");
            }
        }

        private TestPatternID patternID;

        /// <summary>
        /// 测试画面
        /// 如果值为 TestPatternID.Unknown，则未选中任何测试画面
        /// </summary>
        public TestPatternID PatternID
        {
            get
            {
                return this.patternID;
            }
            set
            {
                this.patternID = value;
                this.OnPropertyChanged("PatternID");
            }
        }

        private CameraID camera;

        /// <summary>
        /// 所选相机
        /// 如果值为 CameraID.Unknown，则未选中任何相机
        /// </summary>
        public CameraID Camera
        {
            get
            {
                return this.camera;
            }
            set
            {
                this.camera = value;
                this.OnPropertyChanged("Camera");
            }
        }

        private string algorism;

        /// <summary>
        /// 算法
        /// 不能为空吧？
        /// </summary>
        public string Algorism
        {
            get
            {
                return this.algorism;
            }
            set
            {
                this.algorism = value;
                this.OnPropertyChanged("Algorism");
            }
        }
    }
}
