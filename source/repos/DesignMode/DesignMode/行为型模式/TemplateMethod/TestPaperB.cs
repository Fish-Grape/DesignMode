using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式.TemplateMethod
{
    class TestPaperB : TestPaper
    {
        protected override string Answer1()
        {
            return "c";
        }
    }
}
