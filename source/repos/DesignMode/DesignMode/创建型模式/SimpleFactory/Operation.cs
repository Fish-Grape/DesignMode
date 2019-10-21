using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.创建型模式.SimpleFactory
{
    public class Operation
    {
        private double _numberA = 0;
        private double _numberB = 0;

        public double NumberA { get => _numberA; set => _numberA = value; }
        public double NumberB { get => _numberB; set => _numberB = value; }

        public virtual double GetResult()
        {
            double result = 0;
            return result;
        }
    }
}
