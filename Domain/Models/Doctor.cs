using Domain.Constants;
using Domain.interfaces;
using System;
namespace Domain.Models
{
    public class Doctor: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Specialization specialization { get; set; }
        public DateTime BirthDate { get; set; }
        
    }
}
