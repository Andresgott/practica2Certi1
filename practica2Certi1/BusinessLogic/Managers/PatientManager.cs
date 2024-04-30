using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPB.BusinessLogic.Models;

namespace UPB.BusinessLogic.Managers
{
    public class PatientManager
    {
        public PatientManager() { }

        public Patient CreatePatient(string name,string lastName,int ci)
        {
            Patient patient;
            patient = new Patient(name, lastName,ci,randomBloodType());

            return patient;

        }

        private string randomBloodType() 
        {
            string bloodType;
            int rand = new Random().Next(0,81);
            if(rand < 10) 
            {
                bloodType = "A+";
            }
            else if(rand < 20) 
            {
                bloodType = "A-";
            }
            else if(rand < 30) 
            {
                bloodType = "B+";
            }
            else if (rand < 40)
            {
                bloodType = "B-";
            }
            else if(rand < 50) 
            {
                bloodType = "AB+";
            }
            else if (rand < 60)
            {
                bloodType = "AB-";
            }
            else if (rand < 70)
            {
                bloodType = "O+";
            }
            else 
            {
                bloodType = "O-";
            }
            return bloodType;
        }
    }
}
