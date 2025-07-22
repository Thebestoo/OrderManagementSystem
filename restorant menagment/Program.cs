using System;
using OrderManagementSystem.Services;
using OrderManagementSystem.Security;

class Program
{
    static string adminUsername;
    static string adminPasswordHash;

    static void Main()
    {
        var orderService = new OrderService();

        if (!LoginAdminMenu()) return;

        while (true)
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Shto porosi");
            Console.WriteLine("2. Shfaq porositë");
            Console.WriteLine("3. Llogarit të ardhurat");
            Console.WriteLine("4. Modifiko porosi");
            Console.WriteLine("5. Fshi porosi");
            Console.WriteLine("6. Kërko porosi");
            Console.WriteLine("7. Eksporto në CSV");
            Console.WriteLine("8. Fshi të gjitha");
            Console.WriteLine("9. Dil");

            Console.Write("Zgjedhja: ");
            var zgjedhja = Console.ReadLine();

            switch (zgjedhja)
            {
                case "1":
                    Console.Write("Emri klientit: ");
                    string emri = Console.ReadLine();
                    Console.Write("Ushqimi: ");
                    string ushqimi = Console.ReadLine();
                    Console.Write("Sasia: ");
                    int sasia = int.Parse(Console.ReadLine());
                    Console.Write("Cmimi: ");
                    double cmimi = double.Parse(Console.ReadLine());
                    orderService.ShtoPorosi(emri, ushqimi, sasia, cmimi);
                    break;
                case "2":
                    orderService.ShfaqPorosite();
                    break;
                case "3":
                    orderService.LlogaritTeArdhurat();
                    break;
                case "4":
                    Console.Write("ID për modifikim: ");
                    int idM = int.Parse(Console.ReadLine());
                    Console.Write("Emri ri: ");
                    string emriRi = Console.ReadLine();
                    Console.Write("Ushqimi ri: ");
                    string ushqimiRi = Console.ReadLine();
                    Console.Write("Sasia: ");
                    int sasiaM = int.Parse(Console.ReadLine());
                    Console.Write("Cmimi: ");
                    double cmimiM = double.Parse(Console.ReadLine());
                    Console.Write("Tatimi: ");
                    double tatimi = double.Parse(Console.ReadLine());
                    orderService.ModifikoPorosi(idM, emriRi, ushqimiRi, sasiaM, cmimiM, tatimi);
                    break;
                case "5":
                    Console.Write("ID për fshirje: ");
                    int idF = int.Parse(Console.ReadLine());
                    orderService.FshiPorosi(idF);
                    break;
                case "6":
                    Console.Write("Kërko: ");
                    string term = Console.ReadLine();
                    orderService.KërkoPorosi(term);
                    break;
                case "7":
                    ExportService.EksportoCSV(orderService.GetPorosite());
                    break;
                case "8":
                    orderService.FshiTeGjitha();
                    break;
                case "9":
                    return;
                default:
                    Console.WriteLine("Zgjedhje e pavlefshme.");
                    break;
            }
        }
    }

    static bool LoginAdminMenu()
    {
        if (adminUsername == null)
        {
            Console.WriteLine("Krijo admin:");
            Console.Write("Username: ");
            adminUsername = Console.ReadLine();
            Console.Write("Password: ");
            var pw = Console.ReadLine();
            adminPasswordHash = AuthService.HashPassword(pw);
        }

        Console.WriteLine("Kyçu si admin:");
        Console.Write("Username: ");
        string user = Console.ReadLine();
        Console.Write("Password: ");
        string pass = Console.ReadLine();

        return user == adminUsername && AuthService.VerifyPassword(pass, adminPasswordHash);
    }
}
