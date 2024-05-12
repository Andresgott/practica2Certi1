using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPB.BusinessLogic.Models
{
    public class Patient
    {
        public string Name {  get; set; }
        public string LastName { get; set; }
        public int CI { get; set; }
        public string BloodType {  get; set; }
        public string Codigo { get; set; }

        public Patient() { }

        public Patient(string name, string lastName, int ci,string bloodType,string codigo) 
        {
            Name = name;
            LastName = lastName;
            CI = ci;    
            BloodType = bloodType;
            Codigo = codigo;
        }
    }
}
