using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.创建型模式.PrototypeMode
{
    class Resume : ICloneable
    {
        private string name;
        private string sex ;
        private string age;
        private WorkExperience work;

        public Resume(string name)
        {
            this.name = name;
            this.work = new WorkExperience();
        }

        public Resume(WorkExperience work)
        {
            this.work = (WorkExperience)work.Clone();
        }

        public void SetPersonalInfo(string sex, string age)
        {
            this.sex = sex;
            this.age = age;
        }

        public void SetWorkExperience(string workDate,string company)
        {
            work.WorkDate = workDate;
            work.Company = company;
        }

        public void Display()
        {
            Console.WriteLine("{0} {1} {2}", name, sex, age);
            Console.WriteLine("工作经历:{0} {1}", work.WorkDate,work.Company);
        }
        public object Clone()
        {
            Resume obj = new Resume(this.work);
            obj.name = this.name;
            obj.sex = this.sex;
            obj.age = this.age;
            return obj;
        }
    }
}
