Console.WriteLine("Ejercicio 2 — Intermedio: Conversor de temperaturas\n");

bool salir = false;

double CelsiusAFahrenheit(double c) => c * 9/5 + 32;
double CelsiusAKelvin(double c)	=> c + 273.15;
double FahrenheitACelsius(double f)	=> (f - 32) * 5/9;
double FahrenheitAKelvin(double f) => (f - 32) * 5/9 + 273.15;
double KelvinACelsius(double k)	=> k - 273.15;
double KelvinAFahrenheit(double k) => (k - 273.15) * 9/5 + 32;

while (!salir)
{
    Console.WriteLine("1. Celsius a Farenheit");
    Console.WriteLine("2. Farenheit a Celsius");
    Console.WriteLine("3. Celsius a Kelvin");
    Console.WriteLine("4. Kelvin a Celsius");
    Console.WriteLine("5. Farenheit a Kelvin");
    Console.WriteLine("6. Kelvin a Farenheit");
    Console.WriteLine("7. Salir");
    Console.Write("Selecciona una opción (1-7): ");

    string opcion = Console.ReadLine() ?? "";

    if (opcion == "7")
    {
        salir = true;
        Console.WriteLine("¡Hasta luego!");
        continue;
    }

    if (opcion == "1" || opcion == "2" || opcion == "3" || opcion == "4" || opcion == "5" || opcion == "6")
    {

        Console.Write("Ingresa cuantos grados quieres convertir: \n");
        double.TryParse(Console.ReadLine(), out double grados);

        double resultado = 0;
        string nombreOperacion = "";

        switch (opcion)
        {
            case "1":
                resultado = CelsiusAFahrenheit(grados);
                nombreOperacion = "Conversión de Celsius a Farenheit";
                Console.WriteLine($"Resultados: La {nombreOperacion} de {grados}°C son: {resultado:F2}°F\n");
                break;

            case "2":
                resultado = FahrenheitACelsius(grados);
                nombreOperacion = "Conversión de Farenheit a Celsius";
                Console.WriteLine($"Resultados: La {nombreOperacion} de {grados}°F son: {resultado:F2}°C\n");
                break;

            case "3":
                resultado = CelsiusAKelvin(grados);
                nombreOperacion = "Conversión de Celsius a Kelvin";
                Console.WriteLine($"Resultados: La {nombreOperacion} de {grados}°C son: {resultado:F2}°K\n");
                break;
            case "4":
                resultado = KelvinACelsius(grados);
                nombreOperacion = "Conversión de Kelvin a Celsius";
                Console.WriteLine($"Resultados: La {nombreOperacion} de {grados}°K son: {resultado:F2}°C\n");
                break;
            case "5":
                resultado = FahrenheitAKelvin(grados);
                nombreOperacion = "Conversión de Farenheit a Kelvin";
                Console.WriteLine($"Resultados: La {nombreOperacion} de {grados}°F son: {resultado:F2}°K\n");
                break;

            case "6":
                resultado = KelvinAFahrenheit(grados);
                nombreOperacion = "Conversión de Kelvin a Farenheit";
                Console.WriteLine($"Resultados: La {nombreOperacion} de {grados}°K son: {resultado:F2}°F\n");
                break;
        }
    }
    else
    {
        Console.WriteLine(" Error: Opción no válida. Por favor elige entre 1 y 7.");
    }
}