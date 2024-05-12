using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPB.BusinessLogic.Models;
using UPB.BusinessLogic.Managers.Exceptions;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;

namespace UPB.BusinessLogic.Managers
{
    public class PatientManager
    {
        private List<Patient> _patients;
        private IConfiguration _configuration;
        private HttpClient _httpClient;
        public PatientManager(IConfiguration configuration) 
        {
            _patients = new List<Patient>();
            _configuration = configuration;
            _httpClient = new HttpClient();

            readPatientsToList();
        }

        public Patient CreatePatient(Patient patient)
        {
            Task<string> result = GetPatientCode(patient);

            Patient createdPatient = new Patient()
            {
                Name = patient.Name,
                LastName = patient.LastName,
                CI = patient.CI,
                BloodType = randomBloodType(),
                Codigo = result.Result
            };
            _patients.Add(createdPatient);
            writeListToFile();
            return createdPatient;

        }

        public Patient UpdatePatient(int ci, Patient updatedPatient) 
        {
            Patient patientToUpdate = _patients.Find(x => x.CI == ci);

            if (patientToUpdate == null) 
            {
                throw new PatientNotFoundException();
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
                throw new PatientNotFoundException();
            }
            return patientToFind;

        }

        public List<Patient> Delete(int ci) 
        {
            Patient patientToRemove = _patients.Find(x => x.CI == ci);
            if (patientToRemove == null)
            {
                throw new PatientNotFoundException();
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
            string? patientsFile = _configuration.GetSection("FilePaths").GetSection("PatientsFile").Value;
            if(patientsFile == null) 
            {
                throw new JSONSectionException();
            }
            StreamReader reader = new StreamReader(patientsFile);

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
                    BloodType = patientInfo[3],
                    Codigo = patientInfo[4]
                };
                _patients.Add(newPatient);

            }
            reader.Close();
        }

        private void writeListToFile() 
        {
            string? patientsFile = _configuration.GetSection("FilePaths").GetSection("PatientsFile").Value;
            if (patientsFile == null)
            {
                throw new JSONSectionException();
            }
            StreamWriter writer = new StreamWriter(patientsFile);
                                                               
                                                                                                                     


            foreach(var patient in _patients) 
            {
                string[] patientInfo = new string[] { patient.Name,patient.LastName,$"{patient.CI}",patient.BloodType,patient.Codigo};
                writer.WriteLine(string.Join(",",patientInfo));
            }

            writer.Close();
        }
        private async Task<string> GetPatientCode(Patient patient)
        {
            var patientInfo = new
            {
                Name = patient.Name,
                LastName = patient.LastName,
                CI = patient.CI,
                Code = patient.Codigo
            };

            var postResult = await _httpClient.PostAsJsonAsync("http://localhost:5217/api/PatientCode", patientInfo);
            return await postResult.Content.ReadAsStringAsync();

        }
    }
}
