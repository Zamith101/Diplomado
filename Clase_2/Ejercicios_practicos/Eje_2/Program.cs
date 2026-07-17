using System;
using System.Globalization;

Console.WriteLine("Ejercicio 2: Conversor de Temperatura (División Entera vs. Decimal)");

Console.Write("Ingresa la temperatura en grados Farenheit: ");
decimal gradosf = decimal.Parse(Console.ReadLine() ?? "0", CultureInfo.InvariantCulture);

decimal celsius = (gradosf - 32) * 5m/9m;


Console.WriteLine("");
Console.WriteLine("=== Resultado ===");
Console.WriteLine($"Grados celsius: {celsius:F2}");
















































