using Domain.Models;
using Infrastructure.DBInitializer;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;

namespace Presentation.UI
{
  public  class MedicalServiceUI
    {
        private DBInitialization _dBInitialization;
        private GenericRepository<MedicalService> _medicalServiceRepository;
        public MedicalServiceUI(GenericRepository<MedicalService> GenericRepository,DBInitialization dBInitialization)
        {
            this._medicalServiceRepository = GenericRepository;
            this._dBInitialization = dBInitialization;
            _dBInitialization.SeedMedicalServices();
          Console.WriteLine("Data added Medical Service successfully!");
        }

        public IEnumerable<MedicalService> GetAll()
        {
            try
            {
                IEnumerable<MedicalService> medicalServices = _medicalServiceRepository.GetAll();
                if (medicalServices != null)
                {
                    return medicalServices;
                }
                else
                {
                    Console.WriteLine("Error retrieving Medical Service data ");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error get Medical Service data: {ex.Message}");
                return null;
            }
        }
        public MedicalService GetById(int Id)
        {
            MedicalService medicalService = _medicalServiceRepository.GetById(Id);

            if (medicalService != null)
            {
               Console.WriteLine($"Medical Service with Id {medicalService.Id} found");
                return medicalService;
            }
            else
            {
                Console.WriteLine($"Medical Service with Id {medicalService.Id} not found.");
                return null;
            }
        }
        public void Add(MedicalService medicalService)
        {
            try
            {
                medicalService.Id = _medicalServiceRepository.DB.db.Count + 1;
                medicalService.DeliveryDate = DateTime.Now;
                _medicalServiceRepository.Add(medicalService);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding Medical Service : {ex.Message}");
            }
        }
        public void Delete(int Id)
        {
            try
            {
                MedicalService medical = _medicalServiceRepository.GetById(Id);

                if (medical != null)
                {
                    _medicalServiceRepository.Delete(medical);

                    Console.WriteLine($"Medical Service with Id {medical.Id} deleted successfully ");
                }
                else
                {
                    Console.WriteLine("Error retrieving Medical Service data ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting Medical Service: {ex.Message}");
            }

        }
        public void Update(MedicalService medicalService, int Id)
        {
            try
            {
                MedicalService medical = _medicalServiceRepository.GetById(Id);
                if (medical != null)
                {
                    medical.DeliveryDate = medicalService.DeliveryDate;
                    medical.DoctorId = medicalService.DoctorId;
                    medical.Description = medicalService.Description;
                    medical.Price = medicalService.Price;
                    medical.Title = medicalService.Title;
                    Console.WriteLine($"Medical Service with Id {medical.Id} updated successfully.");
                }
                else
                {
                    Console.WriteLine("Error retrieving Medical Service data ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Medical Service : { ex.Message}");
            }
        }
 
    }
}
