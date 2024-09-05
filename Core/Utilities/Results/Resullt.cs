using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Resullt : IResult
    {
        public Resullt(bool success, string message):this(success)
        {
            Message = message;
        }
        public Resullt(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message {  get; }
    }
}
