using Domain.Models;

namespace Service.Repository
{
    public interface IRegistrationRepository
    {
        List<RegistrationModel> GetAllRegistrations();
        RegistrationModel GetRegistrationById(int id);
        RegistrationModel CreateRegistration(RegistrationModel registrationModel);
        RegistrationModel UpdateRegistration(int id, RegistrationModel registrationModel);
        int DeleteRegistration(int id);
    }
}
