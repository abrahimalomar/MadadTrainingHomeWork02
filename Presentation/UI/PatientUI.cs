using Domain.Models;
using Infrastructure.DBInitializer;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
namespace Presentation.UI
{
   public class PatientUI
    {

        private DBInitialization _dBInitialization;
        private GenericRepository<Patient> _patientRepository;
        public  PatientUI(GenericRepository<Patient> GenericRepository,DBInitialization dBInitialization)
        {
            this._patientRepository = GenericRepository;
            this._dBInitialization = dBInitialization;
            _dBInitialization.SeedPatients();
            Console.WriteLine("Data added Patient successfully!");
        }
        public void Add(Patient patient)
        {
            try
            {
                patient.Id = _patientRepository.DB.db.Count + 1;
                _patientRepository.Add(patient);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding Patient : {ex.Message}");
            }
        }
        public void Delete(int Id)
        {
            try
            {
                Patient patient = _patientRepository.GetById(Id);

                if (patient != null)
                {
                    _patientRepository.Delete(patient);

                    Console.WriteLine($"Patient with Id {patient.Id} deleted successfully ");
                }
                else
                {
                    Console.WriteLine("Error retrieving Patient data ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting Patient : {ex.Message}");
            }
        }
        public void Update(Patient model,int Id)
        {
            try
            {
                Patient patient = _patientRepository.GetById(Id);
                if (patient != null)
                {

                    patient.Name = model.Name;
                    patient.BirthDate = model.BirthDate;
                    Console.WriteLine($"Patient with Id {patient.Id} updated successfully.");
                }
                else
                {
                    Console.WriteLine("Error retrieving Patient data ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Patient : { ex.Message}");
            }
        }
        public IEnumerable<Patient> GetAll()
        {
            try
            {
                IEnumerable<Patient> patients = _patientRepository.GetAll();
                if (patients != null)
                {
                    return patients;
                }
                else
                {
                    Console.WriteLine("Error retrieving Patient data ");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error get Patient data: {ex.Message}");
                return null;
            }
        }
        public Patient GetById(int Id)
        {
            Patient patient = _patientRepository.GetById(Id);
            if (patient != null)
            {
                Console.WriteLine($"Patient with Id {patient.Id} found");
                return patient;
            }
            else
            {
                Console.WriteLine($"Patient with Id {patient.Id} not found.");
                return null;
            }
        }
    }
}
