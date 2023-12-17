using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Registration_Assignment_WBIAPI.DTO;
using Service.Repository;

namespace Registration_Assignment_WBIAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationRepository registrationRepository;

        public RegistrationController(IRegistrationRepository _registrationRepository)
        {
            registrationRepository = _registrationRepository;
        }

        [HttpGet]
        public IActionResult GetAllRegistrations()
        {
            return Ok(registrationRepository.GetAllRegistrations());
        }

        [HttpGet("{id}")]
        public IActionResult GetRegistrationById(int id)
        {
            return Ok(registrationRepository.GetRegistrationById(id));
        }

        [HttpPost("NewRegistration")]
        public IActionResult CreateRegistration([FromBody]CreateRegistration createRegistration)
        {
            var registration = new RegistrationModel()
            {
                Name = createRegistration.Name,
                Age = createRegistration.Age,
                Qualification = createRegistration.Qualification,
                Address = createRegistration.Address,
                Description = createRegistration.Description,
                Image = System.IO.File.ReadAllBytes(createRegistration.Image)
            };
            registrationRepository.CreateRegistration(registration);
            return Ok("Registration Created Successfully");
        }

        [HttpPut("UpdateRegistration")]
        public IActionResult UpdateRegistration([FromBody]UpdateRegistration updateRegistration)
        {
            var registration = new RegistrationModel()
            {
                Id = updateRegistration.Id,
                Name = updateRegistration.Name,
                Age = updateRegistration.Age,
                Qualification = updateRegistration.Qualification,
                Address = updateRegistration.Address,
                Description = updateRegistration.Description,
                Image = System.IO.File.ReadAllBytes(updateRegistration.Image)
            };
            registrationRepository.UpdateRegistration(registration.Id, registration);
            return Ok("Registration Updated Successfully");
        }

        [HttpDelete("DeleteRegistration")]
        public IActionResult DeleteRegistration(int id)
        {
            registrationRepository.DeleteRegistration(id);
            return Ok("Registration Deleted Successfully");
        }
    }
}
