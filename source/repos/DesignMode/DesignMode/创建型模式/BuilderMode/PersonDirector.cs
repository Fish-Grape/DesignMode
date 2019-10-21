using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.创建型模式.BuilderMode
{
    class PersonDirector
    {
        private PersonBuilder pb;

        public PersonDirector(PersonBuilder pb)
        {
            this.pb = pb;
        }

        public void CreatePerson()
        {
            pb.BuildHead();
            pb.BuildBody();
            pb.BuildArmLeft();
            pb.BuildArmRight();
            pb.BuildLegLeft();
            pb.BuildLegRight();
        }
    }
}
