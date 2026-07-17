using System;
using System.Globalization;

Console.WriteLine("=== Intermedio: Área y perímetro del rectángulo ===");

Console.Write("Ingresa la base: ");
double Base = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

Console.Write("Ingresa la altura: ");
double Altura = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

double Area = Base * Altura;
double Perimetro = 2 * (Base + Altura);

Console.WriteLine("");
Console.WriteLine("=== Resultado ===");
Console.WriteLine($"Área: {Area:F2}");
Console.WriteLine($"Perímetro: {Perimetro:F2}");



/* Usa double.TryParse() para interactuar con el usuario: Consolas, formularios web, cajas de texto. 
Es la única forma 100% segura de validar la entrada del usuario sin que la app se rompa.

Usa Convert.ToDouble() para integrar sistemas o bases de datos: Por ejemplo, 
al extraer datos de una base de datos o de un archivo Excel donde la existencia de celdas vacías(null) 
se deba traducir por diseño directamente a un 0.

Usa double.Parse() si la ausencia de un dato es un error crítico: 
Si el programa obligatoriamente necesita recibir un decimal para poder continuar y 
un valor nulo significa que hay un fallo mayor que debe detener el proceso.*/

















