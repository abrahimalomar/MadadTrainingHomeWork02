using Domain.interfaces;
using System;
namespace Domain.Models
{
    public  class Patient: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
