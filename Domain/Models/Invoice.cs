using Domain.Constants;
using Domain.interfaces;
using System;
using System.Collections.Generic;

namespace Domain.Models
{

    public class Invoice: IEntity
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public PatientStatus patientStatus { get; set; }
        public DateTime CreationDate { get; set; }

        public List<MedicalService> medicalServices { get; set; } = new List<MedicalService>();
    }
}
