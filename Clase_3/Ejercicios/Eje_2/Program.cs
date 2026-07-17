Console.WriteLine("Ejercicio 2 — Intermedio: Calculadora de descuento");

Console.Write("Ingrese el precio del producto: ");
decimal precio = decimal.Parse(Console.ReadLine() ?? "0");

decimal descuento = 0;

if (precio < 50)
{
    descuento = 0;
    decimal total_a_pagar = precio - descuento;
    Console.WriteLine($"");
    Console.WriteLine($"======== Total a pagar ========");
    Console.WriteLine($"Precio original: {precio:C}");
    Console.WriteLine($"Descuento aplicado: {descuento}%");
    Console.WriteLine($"Precio final {total_a_pagar:C}");
}
if (precio >= 50 && precio < 100)
{
    descuento = 0.10m;
    decimal total_a_pagar = precio - (precio * descuento);
    Console.WriteLine($"");
    Console.WriteLine($"======== Total a pagar ========");
    Console.WriteLine($"Precio original: {precio:C}");
    Console.WriteLine($"Descuento aplicado: {descuento}%");
    Console.WriteLine($"Precio final {total_a_pagar:C}");
}
if (precio >= 100 && precio < 500)
{
    descuento = 0.20m;
    decimal total_a_pagar = precio - (precio * descuento);
    Console.WriteLine($"");
    Console.WriteLine($"======== Total a pagar ========");
    Console.WriteLine($"Precio original: {precio:C}");
    Console.WriteLine($"Descuento aplicado: {descuento}%");
    Console.WriteLine($"Precio final {total_a_pagar:C}");  
}
else
{
    descuento = 0.30m;
    decimal total_a_pagar = precio - (precio * descuento);
    Console.WriteLine($"");
    Console.WriteLine($"======== Total a pagar ========");
    Console.WriteLine($"Precio original: {precio:C}");
    Console.WriteLine($"Descuento aplicado: {descuento}%");
    Console.WriteLine($"Precio final {total_a_pagar:C}");  
}














































