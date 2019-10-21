using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式.StateMode
{
    class Work
    {
        private State current;

        public Work()
        {
            this.current = new ForenoonState();
        }

        private double hour;

        public double Hour { get => hour; set => hour = value; }
        public bool TaskFinished { get => finish; set => finish = value; }

        private bool finish = false;
        public void SetState(State s)
        {
            current = s;
        }

        public void WriteProgram()
        {
            current.WriteProgram(this);
        }
    }
}
