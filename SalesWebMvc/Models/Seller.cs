using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;                 //para não aparecer os nomes grudados na tela de view
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]   //anotation para transformar um texto em um link de e-mail
        public string Email { get; set; }

        [Display(Name = "Birth Date")]      //anotation para não aparecer os nomes grudados na tela de view
        [DataType(DataType.Date)]           // para a data não aparecer com as horas sendo exigidas        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]   //anotation para definir como quero mostrar a data na tela do view, 0 representa o valor do atributo, e o restante a forma que quero apresentar a data
        public DateTime BirthDate { get; set; }

        [Display(Name = "Base Salary")]    //para não aparecer os nomes grudados na tela de view
        [DisplayFormat(DataFormatString ="{0:F2}")]  //anotation para mostrar na tela de view os numeros com 2 casas decimais//{0:F2}: o 0 é o valor do atributo, e o F2 o numero de casas decimais
        public double BaseSalary { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
