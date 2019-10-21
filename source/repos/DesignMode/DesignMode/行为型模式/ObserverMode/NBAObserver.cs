using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式.ObserverMode
{
    class NBAObserver 
    {
        private string name;
        private Subject sub;

        public NBAObserver(string name, Subject sub)
        {
            this.name = name;
            this.sub = sub;
        }

        public void CloseNBADirectSeeding()
        {
            Console.WriteLine("{0} {1} 关闭NBA，继续工作", sub.SubjectState, name);
        }
    }
}
