using System;
using System.Globalization;

Console.WriteLine("Ejercicio 1: Calculadora de Descuentos (Variables y Formatos)");

Console.Write("Ingresa el nombre del producto: ");
string nombre = Console.ReadLine() ?? "";

Console.Write("Ingrese el precio original: ");
decimal precio = decimal.Parse(Console.ReadLine() ?? "0", CultureInfo.InvariantCulture);

Console.Write("Ingrese el porcentaje de descuento: ");
int descuento = int.Parse(Console.ReadLine() ?? "0", CultureInfo.InvariantCulture);


decimal Total = precio - (precio * (descuento / 100m));


Console.WriteLine("");
Console.WriteLine("=== Resultado ===");
Console.WriteLine($"Nombre: {nombre}");
Console.WriteLine($"Precio base: {precio:C}");
Console.WriteLine($"Descuento aplicado: {descuento}%");
Console.WriteLine($"Total a pagar: {Total:C}");
































































