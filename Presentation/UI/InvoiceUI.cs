using Domain.Models;
using Infrastructure.DBInitializer;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;

namespace Presentation.UI
{
   public  class InvoiceUI
    {
        private GenericRepository<Invoice> _invoiceRepository;
        private GenericRepository<Patient> _patientRepository;
        private DBInitialization _dBInitialization;
        public InvoiceUI(GenericRepository<Invoice> GenericRepository,
            DBInitialization dBInitialization, GenericRepository<Patient> patientRepository)
        {
            this._invoiceRepository = GenericRepository;
            this._dBInitialization = dBInitialization;
            this._patientRepository = patientRepository;
            _dBInitialization.SeedInvoices();
            Console.WriteLine("Data added Invoice successfully!");
        
        }

        public IEnumerable<Invoice> GetAll()
        {
            try
            {
                IEnumerable<Invoice> doctors = _invoiceRepository.GetAll();
                if (doctors != null)
                {
                    return doctors;
                }
                else
                {
                    Console.WriteLine("Error retrieving Invoice data ");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error get Invoice data: {ex.Message}");
                return null;
            }
        }
        public Invoice GetById(int Id)
        {
            Invoice invoice = _invoiceRepository.GetById(Id);

            if (invoice != null)
            {
                Console.WriteLine($"Invoice with Id {invoice.Id} found");
                return invoice;
            }
            else
            {
                Console.WriteLine($"Invoice with Id {invoice.Id} not found.");
                return null;
            }
        }
        public void Add(int patientId, Invoice invoice)
        {
            try
            {
                var patient = _patientRepository.GetById(patientId);
                if (patient == null)
                {
                    Console.WriteLine("Cannot add invoice. Patient not found.");
                    return; 
                }
                invoice.Id = _invoiceRepository.DB.db.Count + 1;
                invoice.CreationDate = DateTime.Now;
                invoice.PatientId = patientId;
                _invoiceRepository.Add(invoice);
                Console.WriteLine("Invoice added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding Invoice : {ex.Message}");
            }
        }
        public void Update(Invoice model, int Id)
        {
            try
            {
                Invoice invoice = _invoiceRepository.GetById(Id);
                if (invoice != null)
                {
                    invoice.patientStatus = model.patientStatus;
                    invoice.CreationDate = model.CreationDate;
                    invoice.PatientId = model.PatientId;
                    Console.WriteLine($"Invoice with Id {invoice.Id} updated successfully.");

                }
                else
                {
                    Console.WriteLine("Error retrieving Invoice data ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating Invoice : { ex.Message}");
            }
        }
        public void Delete(int Id)
        {
            try
            {
                Invoice invoice = _invoiceRepository.GetById(Id);

                if (invoice != null)
                {
                    _invoiceRepository.Delete(invoice);

                    Console.WriteLine($"Invoice with Id {invoice.Id} deleted successfully ");
                }
                else
                {
                    Console.WriteLine("Error retrieving Invoice data ");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting Invoice: {ex.Message}");
            }
        }
        
        public Invoice GetByPatientId(int patientId)
        {
            try
            {
                Invoice invoice = _invoiceRepository
                    .RetrieveById(inv => inv.PatientId == patientId);

                if (invoice == null)
                {
                    throw new Exception("Invoice not found");
                }

                return invoice;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
      

        public void AddMS(int invoiceId, int msid,int doctorId, GenericRepository<MedicalService> medicalServiceRepo)
        {
            try
            {
            
                Invoice invoice = _invoiceRepository.GetById(invoiceId);
               MedicalService medicalService= GetMedicalServiceById(msid,medicalServiceRepo);
                if (invoice != null && medicalService!=null)
                {
                        medicalService.DoctorId = doctorId;
                         invoice.medicalServices.Add(medicalService);
                        Console.WriteLine("Medical service added to the invoice successfully.");
                    
                }
                else
                {
                    Console.WriteLine("Invoice not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding medical service to invoice : {ex.Message}");
            }
        }
        public void DeleteMS(int invoiceId,int msId, GenericRepository<MedicalService> medicalServiceRepo)
        {
            MedicalService medicalService = GetMedicalServiceById(msId, medicalServiceRepo);
            Invoice invoice = _invoiceRepository.GetById(invoiceId);

           invoice.medicalServices.Remove(medicalService);
            Console.WriteLine("Medical service delete to the invoice successfully.");
        }
        private MedicalService GetMedicalServiceById(int msId, GenericRepository<MedicalService> medicalServiceRepo)
        {
            try
            {
                MedicalService medicalService = medicalServiceRepo.GetById(msId);
                return medicalService;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving  service: {ex.Message}");
                return null;
            }
        }

    }

}
