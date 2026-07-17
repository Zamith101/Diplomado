using System;
using System.Globalization;

Console.WriteLine("Ejercicio 5: Facturador de Tienda con IVA (Conversión y Estructura)");

Console.Write("Ingrese su nombre: ");
string nombre = Console.ReadLine() ?? "";

Console.Write("Ingrese la cantidad de articulos que compró : ");
string entradaCantidad = Console.ReadLine() ?? "0";

Console.Write("Ingrese el precio unitario: ");
string entradaPrecio = Console.ReadLine() ?? "0";


if (int.TryParse(entradaCantidad, out int cantidad) && 
    decimal.TryParse(entradaPrecio, CultureInfo.InvariantCulture, out decimal precio_unitario))
{
    decimal Subtotal = cantidad * precio_unitario;
    decimal IVA = Subtotal * 0.19m;
    decimal Total = Subtotal + IVA;

    Console.WriteLine("");
    Console.WriteLine("=== Resultado ===");
    Console.WriteLine($"Cliente: {nombre}");
    Console.WriteLine($"Precio unitario: {precio_unitario:C}");
    Console.WriteLine($"Cantidad: {cantidad}");
    Console.WriteLine($"Subtotal: {Subtotal:C}");
    Console.WriteLine($"IVA 19%: {IVA:C}");
    Console.WriteLine($"Total a pagar: {Total:C}");
}
else
{
    Console.WriteLine("Error: Por favor, introduce una cantidad y un precio válidos.");
}























































