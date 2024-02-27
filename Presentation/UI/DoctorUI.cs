using Domain.Models;
using System.Collections.Generic;
using System;
using System.Linq;
using Infrastructure.Repository;
using Infrastructure.DBInitializer;

namespace Presentation.UI
{
  public  class DoctorUI
    {
        private GenericRepository<Doctor> _doctorRepository;
        private DBInitialization _dBInitialization;
        public DoctorUI(GenericRepository<Doctor> _doctorRepository, DBInitialization dBInitialization)
        {
            this._doctorRepository = _doctorRepository;
            this._dBInitialization = dBInitialization;
            _dBInitialization.SeedDoctors();
           Console.WriteLine("Data added Doctor successfully!");
        }
        public IEnumerable<Doctor> GetAll()
        {
            try
            {
                IEnumerable<Doctor> doctors = _doctorRepository.GetAll();
                if (doctors != null)
                {
                    return doctors;
                }
                else
                {
                    Console.WriteLine("Error retrieving doctor data ");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error get doctors data: {ex.Message}");
                return null;
            }

        }
        public Doctor GetById(int Id)
        {
            Doctor doctor = _doctorRepository.GetById(Id);

            if (doctor != null)
            {
                Console.WriteLine($"doctor with Id {doctor.Id} found");
                return doctor;
            }
            else
            {
                Console.WriteLine($"doctor with Id {doctor.Id} not found.");
                return null;
            }

        }
        public void Add(Doctor doctor)
        {
            try
            {
                doctor.Id = _doctorRepository.DB.db.Count + 1;
                _doctorRepository.Add(doctor);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding doctor : {ex.Message}");
            }
        }
        public void Delete(int Id)
        {
            try
            {
                Doctor doctor = _doctorRepository.GetById(Id);

                if (doctor != null)
                {
                    _doctorRepository.Delete(doctor);
                   
                    Console.WriteLine($"doctor with Id {doctor.Id} deleted successfully ");

                }
                else
                {
                    Console.WriteLine("Error retrieving doctor data ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting doctor: {ex.Message}");
            }
        }
        public void Update(Doctor model, int Id)
        {
            try
            {
                Doctor doctor = _doctorRepository.GetById(Id);
                if (doctor != null)
                {
                    doctor.Name = model.Name;
                    doctor.specialization = model.specialization;
                    doctor.BirthDate = model.BirthDate;

                    doctor.Name = model.Name;

                    Console.WriteLine($"doctor with Id {doctor.Id} updated successfully.");
                }
                else
                {
                    Console.WriteLine("Error retrieving doctor data ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating doctor : { ex.Message}");
            } 
        }
   
        public decimal GetSalary(int doctorId, GenericRepository<MedicalService> db)
        {
            decimal totalSalary = db.GetAll()
                .Where(service => service.DoctorId == doctorId)
                .Sum(service => service.Price);

            return totalSalary;
        }


    }
}


