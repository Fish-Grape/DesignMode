using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式.TemplateMethod
{
    class TestPaper
    {
        public void TestQuestion1()
        {
            Console.WriteLine("杨过得到，后来给了郭靖，炼成倚天剑、屠龙刀的玄铁可能是[],a.球棒铸铁 b.马口铁 c.告诉合金钢 d.碳素纤维 ");
            Console.WriteLine("答案：" + Answer1());
        }

        protected virtual string Answer1()
        {
            return "";
        }
    }
}
