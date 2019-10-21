using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.结构型模式.CompositeMode
{
    class HRDepartment : Company
    {
        public HRDepartment(string name) : base(name)
        {
        }

        public override void Add(Company c)
        {
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string("-" + depth) + name);
        }

        public override void LineOfDuty()
        {
            Console.WriteLine("{0} 员工招聘培训管理" , name);
        }

        public override void Remove(Company c)
        {
        }
    }
}
