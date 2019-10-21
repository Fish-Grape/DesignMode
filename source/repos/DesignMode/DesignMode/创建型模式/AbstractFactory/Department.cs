using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.创建型模式.AbstractFactory
{
    class Department
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name { get => _name; set => _name = value; }

        private string _name;
    }
}
