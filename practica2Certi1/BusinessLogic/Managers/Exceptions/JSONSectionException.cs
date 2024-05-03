using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPB.BusinessLogic.Managers.Exceptions
{
    internal class JSONSectionException:Exception
    {
        private const string mensaje = "JSON Section not found in the enviroment config file";
        public JSONSectionException() :base(mensaje) { }

        public string GetErrorType()
        {
            return Message;
        }
    }
}
