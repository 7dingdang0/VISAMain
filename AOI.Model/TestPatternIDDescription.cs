/***********************************************************************************
 *              AOI (Automatic Optical Inspector) 自动光学检测系统                
 *              模型层的测试画面 ID 的描述                                 
 *              2021/3/13 (Copyright statement here 版权信息待定) Author: Patrick  
 **********************************************************************************/

namespace AOI.Model
{
    /// <summary>
    /// 测试画面 ID 的描述
    /// </summary>
    public class TestPatternIDDescription
    {
        /// <summary>
        /// 测试画面 ID
        /// </summary>
        public TestPatternID Id
        {
            get; set;
        }

        /// <summary>
        /// 中文描述
        /// </summary>
        public string ChineseDescription
        {
            get; set;
        }

        /// <summary>
        /// 英文描述
        /// </summary>
        public string EnglishDescription
        {
            get; set;
        }

        public TestPatternIDDescription()
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">测试画面 ID</param>
        /// <param name="ch">中文描述</param>
        /// <param name="en">英文描述</param>
        public TestPatternIDDescription(TestPatternID id, string ch, string en)
        {
            this.Id = id;
            this.ChineseDescription = ch;
            this.EnglishDescription = en;
        }

        /// <summary>
        /// 静态变量，预定义的全部测试画面 ID 及其描述
        /// </summary>
        public static TestPatternIDDescription[] AllTestPatternIDDescriptions = new TestPatternIDDescription[7]
            {
                new TestPatternIDDescription(TestPatternID.TD001, "白", "White"),
                new TestPatternIDDescription(TestPatternID.TD002, "红", "Red"),
                new TestPatternIDDescription(TestPatternID.TD003, "绿", "Green"),
                new TestPatternIDDescription(TestPatternID.TD004, "蓝", "Blue"),
                new TestPatternIDDescription(TestPatternID.TD005, "灰", "Grey"),
                new TestPatternIDDescription(TestPatternID.TD006, "黑", "Black"),
                new TestPatternIDDescription(TestPatternID.TD007, "除尘屏", "DUST")
            };
    }
}
