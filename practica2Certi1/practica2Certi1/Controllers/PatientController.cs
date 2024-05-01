using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UPB.BusinessLogic.Managers;
using UPB.BusinessLogic.Models;

namespace UPB.practica2Certi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        public readonly PatientManager _patientManager;

        public PatientController()
        {
            _patientManager = new PatientManager();
        }

        [HttpGet]
        public List<Patient> GET()
        {
            return _patientManager.GetPatients();
        }

        [HttpGet]
        [Route("{ci}")]
        public Patient Get(int ci)
        {
            return _patientManager.GetPatientByCI(ci);
        }

        [HttpPost]
        public void Post([FromBody] Patient value)
        {
            _patientManager.CreatePatient(value);
        }

        [HttpPut("{ci}")]
        public void Update(int ci, [FromBody] Patient value)
        {
            _patientManager.UpdatePatient(ci, value);
        }

        [HttpDelete("{ci}")]
        public void Delete(int ci) 
        {
            _patientManager.Delete(ci);
        }

       
    }
}
