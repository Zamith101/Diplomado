using System;

Console.WriteLine("=== Ejercicio 3 — Reto: Conversor de unidades ===");
Console.WriteLine("1. Metros a kilómetros");
Console.WriteLine("2. Kilómetros a metros");
Console.WriteLine("3. Celsius a Fahrenheit");
Console.WriteLine("4. Fahrenheit a Celsius");
Console.WriteLine("5. Salir");
Console.Write("Selecciona una opción: ");

decimal metros = 0;
decimal kilometros = 0;
decimal celsius = 0;
decimal farenheit = 0;

if (int.TryParse(Console.ReadLine(), out int opcion))
{
    Console.WriteLine("");
    
    switch (opcion)
    {
        case 1:
            Console.Write("Ingrese el valor en metros: ");
            decimal valor_k = decimal.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("");
            Console.WriteLine("=== Conversión ===");
            
            kilometros = valor_k / 1000;
            Console.WriteLine($"{valor_k} metros equivalen a {kilometros:F2} kilómetros.");

            break;
            
        case 2:
            Console.Write("Ingrese el valor en kilómetros: ");
            decimal valor_m = decimal.Parse(Console.ReadLine() ?? "0");
            
            
            Console.WriteLine("");
            Console.WriteLine("=== Conversión ===");

            metros = valor_m * 1000;
            Console.WriteLine($"{valor_m} kilómetros equivalen a {metros:F2} metros.");

            break;
            
        case 3:
            Console.Write("Ingrese el valor en grados Celsius: ");
            decimal valor_c = decimal.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("");
            Console.WriteLine("=== Conversión ===");

            farenheit = (valor_c * 9m/5m) + 32;
            Console.WriteLine($"{valor_c}°C equivalen a {farenheit:F2}°F");
            break;
            
        case 4:
            Console.Write("Ingrese el valor en grados Farenheit: ");
            decimal valor_f = decimal.Parse(Console.ReadLine() ?? "0");

            Console.WriteLine("");
            Console.WriteLine("=== Conversión ===");
            
            celsius = (valor_f - 32 ) * 5m/9m;
            Console.WriteLine($"{valor_f}°F equivalen a {celsius:F2}°C");
            break;

        case 5:
            Console.WriteLine("Gracias por usar nuestro servicio. ¡Adiós!");
            break;
        default:
            Console.WriteLine("Opción inválida. Por favor, elige del 1 al 5.");
            break;
    }
}
else
{
    Console.WriteLine("Error: Debes introducir un número entero.");
}