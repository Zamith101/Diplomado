string nombre = "Ana";
int edad = 25;
double saldo = 1234.5678;


Console.WriteLine($"Hola, {nombre}");


Console.WriteLine($"Saldo: {saldo:C}");         // Moneda: $1,234.57
Console.WriteLine($"Saldo: {saldo:F2}");         // 2 decimales: 1234.57
Console.WriteLine($"Saldo: {saldo:N0}");         // Sin decimales con comas: 1,235


Console.WriteLine($"|{"Nombre",-10}|{"Edad",5}|");
Console.WriteLine($"|{nombre,-10}|{edad,5}|");


















