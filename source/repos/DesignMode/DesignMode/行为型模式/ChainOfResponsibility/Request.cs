using System;
using System.Collections.Generic;
using System.Text;

namespace DesignMode.行为型模式.ChainOfResponsibility
{
    public class Request
    {
        private string requestType;
        private string requestContent;
        private int number;

        public string RequestType { get => requestType; set => requestType = value; }
        public string RequestContent { get => requestContent; set => requestContent = value; }
        public int Number { get => number; set => number = value; }
    }
}
