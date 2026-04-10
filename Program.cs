using IP_Adressen_Scanner;

Console.WriteLine("IP-Adressen-Scanner");

Console.Write("Basis-IP eingeben (z.B. 192.168.1): ");
string baseIp = Console.ReadLine();

Console.Write("Start (z.B. 1): ");
int start = int.Parse(Console.ReadLine());

Console.Write("Ende (z.B. 254): ");
int end = int.Parse(Console.ReadLine());

Scanner scanner = new Scanner();
Console.WriteLine("\nScanne...\n");
var aktiveIPs = scanner.ScanRange(baseIp, start, end);

Console.WriteLine($"\nFertig! {aktiveIPs.Count} Gerät(e) gefunden.");