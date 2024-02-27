using Domain.Constants;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.DBInitializer;
using Infrastructure.Repository;
using Presentation.UI;
using System;

namespace Presentation
{
    class Program
    {
        static void Main(string[] args)
            {

           
            var patientRepository = new GenericRepository<Patient>(new DB<Patient>());
            var doctorRepository = new GenericRepository<Doctor>(new DB<Doctor>());
            var medicalRepository = new GenericRepository<MedicalService>(new DB<MedicalService>());
            var invoiceRepository = new GenericRepository<Invoice>(new DB<Invoice>());

            var dbInitializer = new DBInitialization(patientRepository, doctorRepository, medicalRepository, invoiceRepository);


            PatientUI patientUI = new PatientUI(patientRepository, dbInitializer);
            DoctorUI doctorUI = new DoctorUI(doctorRepository, dbInitializer);
            MedicalServiceUI medicalServiceUI = new MedicalServiceUI(medicalRepository, dbInitializer);
            InvoiceUI invoiceUI = new InvoiceUI(invoiceRepository, dbInitializer, patientRepository);
            




            Console.WriteLine("\n\n");
                Console.WriteLine("Testing Patine ..........\n");

                Console.WriteLine("All Patients: \n");
                var patients = patientUI.GetAll();
                foreach (var patient in patients)
                {
                    Console.WriteLine($"Id: {patient.Id}, Name: {patient.Name}");
                }

                patientUI.Delete(1);

                Console.WriteLine("Update: ");
                patientUI.Update(new Patient { Name = "Updated Name" }, 2);

                Patient updatedPatient = patientUI.GetById(2);
                Console.WriteLine($"Id: {updatedPatient.Id}, Name: {updatedPatient.Name} ");
            


            
            /*
            // Test doctors
            Console.WriteLine("\n\n");
            Console.WriteLine("Testing doctors  ..........\n");

            Console.WriteLine("All Doctors: \n");
            var doctors = doctorUI.GetAll();
            foreach (var doctor in doctors)
            {
                Console.WriteLine($"Id: {doctor.Id}, Doctor Name: {doctor.Name}, Specialization {doctor.specialization}");
            }

            doctorUI.Delete(1);
            Console.WriteLine("------------");

            doctorUI.Update(new Doctor { Name = "Updated Doctor Name",specialization=Specialization.Prediatrics }, 2);
            Doctor updatedDoctor = doctorUI.GetById(2);
            Console.WriteLine("Updated Doctor: ");
            Console.WriteLine($"Id: {updatedDoctor.Id}, Doctor Name: {updatedDoctor.Name}, Specialization: {updatedDoctor.specialization}");

            Console.WriteLine($"Doctor Salary: {doctorUI.GetSalary(2, medicalRepository)}");
            */

            /*
            // Test services
            Console.WriteLine("\n");
            Console.WriteLine("Testing services  ..........\n");

            Console.WriteLine("All Services: \n");

            var services = medicalServiceUI.GetAll();
            foreach (MedicalService service in services)
            {
                Console.WriteLine($"Service Id: {service.Id}, Doctor Id: {service.DoctorId}, Title: {service.Title}, " +
                                   $"Price: {service.Price}, Delivery Date: {service.DeliveryDate:MM/dd/yyyy}");
            }

            medicalServiceUI.Delete(1);
            medicalServiceUI.Update(new MedicalService { Title = MedicalServiceTitle.DermatologicalTreatment }, 2);
            MedicalService updatedService = medicalServiceUI.GetById(2);

            Console.WriteLine("Update ----------------------- ");
            Console.WriteLine($"Id: {updatedService.Id}, Title: {updatedService.Title}, Price: {updatedService.Price}");
            */
       
            /*
            
            MedicalService service1 = medicalServiceUI.GetById(1);
            MedicalService service2 = medicalServiceUI.GetById(2);
            Doctor doctor = doctorUI.GetById(1);
            Invoice invoice1 = invoiceUI.GetById(1);

            invoiceUI.AddMS(invoice1.Id, service1.Id, doctor.Id, medicalRepository);
            invoiceUI.AddMS(invoice1.Id, service2.Id, doctor.Id, medicalRepository);

            Console.WriteLine("All Invoices:\n");

            var invoices = invoiceUI.GetAll();

            foreach (Invoice invoice in invoices)
            {
                Console.WriteLine($"Invoice ID: {invoice.Id}");
                Console.WriteLine($"Creation Date: {invoice.CreationDate}");
                Console.WriteLine($"Patient Status: {invoice.patientStatus}");
                Console.WriteLine($"Patient ID: {invoice.PatientId}");

                Console.WriteLine("Services:");
                foreach (MedicalService service in invoice.medicalServices)
                {
                    Console.WriteLine($"--Service ID: {service.Id}");
                    Console.WriteLine($"  Doctor ID: {service.DoctorId}");
                    Console.WriteLine($"  Title: {service.Title}");
                    Console.WriteLine($"  Price: {service.Price}");
                    Console.WriteLine($"  Delivery Date: {service.DeliveryDate:MM/dd/yyyy}");
                }

                Console.WriteLine();
            }


            Console.WriteLine("\nInvoice Details by Patient ID:");

            Invoice invoiceByPatientId = invoiceUI.GetByPatientId(1);

            Console.WriteLine($"Invoice ID: {invoiceByPatientId.Id}, Creation Date: {invoiceByPatientId.CreationDate}, Patient Status: {invoiceByPatientId.patientStatus}, Patient ID: {invoiceByPatientId.PatientId}");

            Console.WriteLine("--------------------------------");

            invoiceUI.Delete(1);

            invoiceUI.Update(new Invoice
            {
                patientStatus = PatientStatus.dead
            }, 2);

            Invoice updatedInvoice = invoiceUI.GetById(2);

            Console.WriteLine("\nInvoice Details after Update:");

            Console.WriteLine($"Invoice ID: {updatedInvoice.Id}, Creation Date: {updatedInvoice.CreationDate}, Patient Status: {updatedInvoice.patientStatus}, Patient ID: {updatedInvoice.PatientId}");

            Console.WriteLine("After Update:");

            Console.WriteLine($"{updatedInvoice.patientStatus}");

            Console.WriteLine("--------------------------------");

         
          
            Console.WriteLine("--------------------------------");

            invoiceUI.DeleteMS(updatedInvoice.Id, service1.Id,medicalRepository);


            */
            




        }
      
    }
}
