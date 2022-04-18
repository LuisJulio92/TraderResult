using System;
using System.Collections.Generic;
using System.Text;

namespace TraderResult.Models
{
    public class Operation
    {
        public string IdOperation { get; set; }
        public string Date { get; set; }
        public string OperationType { get; set; }
        public string Market { get; set; }
        public string Entry { get; set; }
        public string Target { get; set; }
        public string TypeResult { get; set; }
        public string Result { get; set; }
    }
}