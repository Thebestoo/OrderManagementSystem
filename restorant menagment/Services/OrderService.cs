using System;
using System.Collections.Generic;
using System.Linq;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services
{
    public class OrderService
    {
        private readonly List<Porosia> porosite = new();
        private int idGjenerator = 1;

        public void ShtoPorosi(string emri, string ushqimi, int sasia, double cmimi)
        {
            double tatimi = sasia * cmimi * 0.18;

            var porosia = new Porosia
            {
                id = idGjenerator++,
                EmriKlientit = emri,
                Ushqimi = ushqimi,
                Sasia = sasia,
                Cmimi = cmimi,
                Tatimi = tatimi,
                DateCreated = DateTime.Now
            };

            porosite.Add(porosia);
            Console.WriteLine("✅ Porosia u shtua me sukses!");
        }

        public void ShfaqPorosite()
        {
            if (!porosite.Any())
            {
                Console.WriteLine("⚠️ Nuk ka porosi.");
                return;
            }

            var sorted = porosite.OrderByDescending(p => p.Total);
            foreach (var p in sorted)
                Console.WriteLine(p);
        }

        public void LlogaritTeArdhurat()
        {
            double total = porosite.Sum(p => p.Total);
            Console.WriteLine($"💰 Totali i të ardhurave: {total:F2}");
        }

        public void KërkoPorosi(string searchTerm)
        {
            var results = porosite.Where(p =>
                p.EmriKlientit.ToLower().Contains(searchTerm.ToLower()) ||
                p.Ushqimi.ToLower().Contains(searchTerm.ToLower()));

            if (!results.Any())
            {
                Console.WriteLine("🔍 Nuk u gjetën rezultate.");
                return;
            }

            foreach (var p in results)
                Console.WriteLine(p);
        }

        public void FshiPorosi(int id)
        {
            var porosia = porosite.FirstOrDefault(p => p.id == id);
            if (porosia == null)
            {
                Console.WriteLine("⚠️ Porosia nuk ekziston!");
                return;
            }

            porosite.Remove(porosia);
            Console.WriteLine("🗑️ Porosia u fshi me sukses.");
        }

        public void ModifikoPorosi(int id, string emri, string ushqimi, int sasia, double cmimi, double tatimi)
        {
            var porosia = porosite.FirstOrDefault(p => p.id == id);
            if (porosia == null)
            {
                Console.WriteLine("❌ Porosia nuk u gjet!");
                return;
            }

            porosia.EmriKlientit = emri;
            porosia.Ushqimi = ushqimi;
            porosia.Sasia = sasia;
            porosia.Cmimi = cmimi;
            porosia.Tatimi = tatimi;

            Console.WriteLine("✏️ Porosia u modifikua me sukses.");
        }

        public void FshiTeGjitha()
        {
            porosite.Clear();
            Console.WriteLine("🧹 Të gjitha porositë u fshinë.");
        }

        public List<Porosia> GetPorosite() => porosite;
    }
}
