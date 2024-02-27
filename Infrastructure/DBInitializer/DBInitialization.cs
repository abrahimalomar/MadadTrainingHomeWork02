using Domain.Constants;
using Domain.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;

namespace Infrastructure.DBInitializer
{
    public class DBInitialization
    {
        internal Doctor doctor1;
        internal Doctor doctor2;
        internal Patient patient1;
        internal Patient patient2;

    

        private GenericRepository<Doctor> _doctorRepository;
        private GenericRepository<Patient> _patientRepository;
        private GenericRepository<MedicalService> _medicalRepository;
        private GenericRepository<Invoice> _invoiceRepository;

        public DBInitialization(GenericRepository<Patient> patientRepository,
            GenericRepository<Doctor> doctorRepository,
            GenericRepository<MedicalService> medicalRepository,
            GenericRepository<Invoice> invoiceRepository)
        {
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            _medicalRepository = medicalRepository;
            _invoiceRepository = invoiceRepository;
        }

        public void SeedDoctors()
        {
            doctor1 = new Doctor
            {
                Name = "Dr. Ahmad",
                specialization = Specialization.Ophthalmology,
                BirthDate = new DateTime(1980, 1, 1)
            };
             doctor2 = new Doctor
            {
                Name = "Dr. Ali",
                specialization = Specialization.GeneralMedicine,
                BirthDate = new DateTime(1990, 1, 1)
            };
            var initialDoctors = new List<Doctor>
            {
              doctor1,doctor2
            };

            foreach (var doctor in initialDoctors)
            {
                doctor.Id = _doctorRepository.DB.db.Count + 1;
                _doctorRepository.Add(doctor);
            }
        }

        public void SeedPatients()
        {
            patient1 = new Patient
            {
                Name = "Ahmad",
                BirthDate = new DateTime(1990, 5, 20)
            };
            patient2 = new Patient
            {
                Name = "Ali",
                BirthDate = new DateTime(1985, 3, 10)
            };
            var initialPatients = new List<Patient>
            {
               patient2,patient1
            };

            foreach (var patient in initialPatients)
            {
                patient.Id = _patientRepository.DB.db.Count + 1;
                _patientRepository.Add(patient);
            }
        }

        public void SeedMedicalServices()
        {
            var initialMedicalServices = new List<MedicalService>
            {
                new MedicalService { Title =MedicalServiceTitle.CosmeticSurgery,
                    Description = " health checkup 1 ",
                    Price = 100,
                    DoctorId = doctor2.Id },
                  new MedicalService { Title =MedicalServiceTitle.DentalTreatmentAndOrthodontics,
                    Description = " health checkup 3 ",
                    Price = 300,
                    DoctorId = doctor2.Id },
                new MedicalService { Title = MedicalServiceTitle.DermatologicalTreatment,
                    Description = "health checkup 2 ",
                    Price = 200,
                    DoctorId = doctor1.Id }
            };

            foreach (var service in initialMedicalServices)
            {
                service.Id = _medicalRepository.DB.db.Count + 1;
                _medicalRepository.Add(service);
            }
        }

        public void SeedInvoices()
        {
            var initialInvoices = new List<Invoice>
            {
                new Invoice { PatientId = patient1.Id, 
                    patientStatus = PatientStatus.ImWaiting,
                    
                    medicalServices = new List<MedicalService>() },
                new Invoice { PatientId = patient2.Id,
                    patientStatus = PatientStatus.Inprocess,
                   // CreationDate = DateTime.Now,
                    medicalServices = new List<MedicalService> () }
            };

            foreach (var invoice in initialInvoices)
            {
                invoice.Id = _invoiceRepository.DB.db.Count + 1;
                _invoiceRepository.Add(invoice);
            }
        }
    }
}
