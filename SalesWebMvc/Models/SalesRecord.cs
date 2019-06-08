using SalesWebMvc.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;  //usado para anotar o formato de data e valor

namespace SalesWebMvc.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]   //anotação de formatação de data
        public DateTime Date { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]          //anotação de formatação de valor
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }
        public Seller Seller { get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
