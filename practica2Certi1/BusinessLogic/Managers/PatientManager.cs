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
        private List<Patient> _patients;
        public PatientManager() 
        {
            _patients = new List<Patient>();

            readPatientsToList();
        }

        public Patient CreatePatient(Patient patient)
        {
            Patient createdPatient;
            createdPatient = new Patient(patient.Name, patient.LastName,patient.CI,randomBloodType());
            _patients.Add(createdPatient);
            writeListToFile();
            return createdPatient;

        }

        public Patient UpdatePatient(int ci, Patient updatedPatient) 
        {
            Patient patientToUpdate = _patients.Find(x => x.CI == ci);

            if (patientToUpdate == null) 
            {
                throw new NotImplementedException();
            }
            patientToUpdate.Name = updatedPatient.Name;
            patientToUpdate.LastName = updatedPatient.LastName;
            patientToUpdate.BloodType = updatedPatient.BloodType;
            writeListToFile();
            return patientToUpdate;
        }

        public List<Patient> GetPatients() 
        {
            return _patients;
        }
        public Patient GetPatientByCI(int ci) 
        {
            Patient patientToFind = _patients.Find(x =>x.CI == ci);
            if (patientToFind == null) 
            {
                throw new NotImplementedException();
            }
            return patientToFind;

        }

        public List<Patient> Delete(int ci) 
        {
            Patient patientToRemove = _patients.Find(x => x.CI == ci);
            if (patientToRemove == null)
            {
                throw new NotImplementedException();
            }
            _patients.Remove(patientToRemove);
            writeListToFile();
            return _patients;
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

        private void readPatientsToList() 
        {
            StreamReader reader = new StreamReader("C:\\Users\\andre\\practica2Certi1\\practica2Certi1\\Patients.txt");

            _patients.Clear();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] patientInfo = line.Split(",");
                Patient newPatient = new Patient()
                {
                    Name = patientInfo[0],
                    LastName = patientInfo[1],
                    CI = int.Parse(patientInfo[2]),
                    BloodType = patientInfo[3]
                };
                _patients.Add(newPatient);

            }
            reader.Close();
        }

        private void writeListToFile() 
        {
            StreamWriter writer = new StreamWriter("C:\\Users\\andre\\practica2Certi1\\practica2Certi1\\Patients.txt");

            foreach(var patient in _patients) 
            {
                string[] patientInfo = new string[] { patient.Name,patient.LastName,$"{patient.CI}",patient.BloodType};
                writer.WriteLine(string.Join(",",patientInfo));
            }

            writer.Close();
        }

    }
}
