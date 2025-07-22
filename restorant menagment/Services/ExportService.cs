using System;
using System.Collections.Generic;
using System.IO;
using OrderManagementSystem.Models;

namespace OrderManagementSystem.Services
{
    public static class ExportService
    {
        public static void EksportoCSV(List<Porosia> porosite, string fileName = "porosite.csv")
        {
            var lines = new List<string> { "ID,Klienti,Ushqimi,Sasia,Cmimi,Tatimi,Totali,Data" };

            foreach (var p in porosite)
            {
                lines.Add($"{p.id},{p.EmriKlientit},{p.Ushqimi},{p.Sasia},{p.Cmimi:F2},{p.Tatimi:F2},{p.Total:F2},{p.DateCreated}");
            }

            File.WriteAllLines(fileName, lines);
            Console.WriteLine($"?? Porositë u eksportuan në {fileName}");
        }
    }
}
