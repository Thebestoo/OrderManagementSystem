using System;

namespace OrderManagementSystem.Models
{
    public class Porosia
    {
        public int id { get; set; }
        public string EmriKlientit { get; set; }
        public string Ushqimi { get; set; }
        public int Sasia { get; set; }
        public double Cmimi { get; set; }
        public double Tatimi { get; set; }
        public DateTime DateCreated { get; set; }

        public double Total => (Sasia * Cmimi) + Tatimi;

        public override string ToString()
        {
            return $"ID: {id}, Klienti: {EmriKlientit}, Ushqimi: {Ushqimi}, Sasia: {Sasia}, Cmimi: {Cmimi:F2}, Tatimi: {Tatimi:F2}, Totali: {Total:F2}, Data: {DateCreated}";
        }
    }
}
