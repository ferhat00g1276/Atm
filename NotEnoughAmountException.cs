using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atmOOP
{
    public class NotEnoughAmountException:Exception
    {
        public NotEnoughAmountException(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
