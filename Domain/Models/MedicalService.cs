using Domain.Constants;
using Domain.interfaces;
using System;


namespace Domain.Models
{
  public  class MedicalService: IEntity
    {
        public int Id { get; set; }
        public DateTime  DeliveryDate { get; set; }
        public int DoctorId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public MedicalServiceTitle Title { get; set; }
    }
}
