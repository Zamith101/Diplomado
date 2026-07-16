Console.WriteLine("=== CALCULADORA DE IMC ===");

Console.Write("Ingresa tu nombre: ");
string nombre = Console.ReadLine();

Console.Write("Ingresa tu peso (kg): ");
double peso = double.Parse(Console.ReadLine());

Console.Write("Ingresa tu altura (m): ");
double altura = double.Parse(Console.ReadLine());

double imc = peso / (altura * altura);

Console.WriteLine("");
Console.WriteLine("===========================");
Console.WriteLine($"Resultados para {nombre}:");
Console.WriteLine($"Peso: {peso:F1} kg");
Console.WriteLine($"Altura: {altura:F2} m");
Console.WriteLine($"IMC: {imc:F2}");

string clasificacion = imc < 18.5 ? "Bajo peso" :
                    imc < 25 ? "Normal" :
                    imc < 30 ? "Sobrepeso" : "Obesidad";
Console.WriteLine($"Clasificación: {clasificacion}");

























































