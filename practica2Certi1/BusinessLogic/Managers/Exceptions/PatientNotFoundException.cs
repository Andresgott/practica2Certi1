using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPB.BusinessLogic.Managers.Exceptions
{
    public class PatientNotFoundException:Exception
    {
        private const string mensaje = "The patient you requested was not found, it doesn't exist in the database";
        public PatientNotFoundException() : base(mensaje) { }
       
        public string GetErrorType() 
        {
            return Message;
        }
    }
}
