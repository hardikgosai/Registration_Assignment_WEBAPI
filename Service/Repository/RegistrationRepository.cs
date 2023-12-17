using DAL.EntityFramework;
using Domain.Models;

namespace Service.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly ApplicationDbContext dbContext;

        public RegistrationRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public RegistrationModel CreateRegistration(RegistrationModel registrationModel)
        {
            dbContext.Registrations.Add(registrationModel);
            dbContext.SaveChanges();
            return registrationModel;
        }

        public int DeleteRegistration(int id)
        {
            RegistrationModel registrationModel = dbContext.Registrations.Find(id);
            if (registrationModel != null)
            { 
                dbContext.Registrations.Remove(registrationModel);
                dbContext.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public List<RegistrationModel> GetAllRegistrations()
        {
            return dbContext.Registrations.ToList();
        }

        public RegistrationModel GetRegistrationById(int id)
        {
            return dbContext.Registrations.Find(id);
        }

        public RegistrationModel UpdateRegistration(int id, RegistrationModel registrationModel)
        {
            RegistrationModel registration = dbContext.Registrations.Find(id);
            if (registration != null)
            {
                registration.Name = registrationModel.Name;
                registration.Age = registrationModel.Age;
                registration.Qualification = registrationModel.Qualification;
                registration.Address = registrationModel.Address;
                registration.Description = registrationModel.Description;
                registration.Image = registrationModel.Image;
                dbContext.SaveChanges();
                return registration;
            }
            else
            {
                return null;
            }
        }
    }
}
