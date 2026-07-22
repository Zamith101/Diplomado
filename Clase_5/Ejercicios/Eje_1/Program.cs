Console.WriteLine("Ejercicio 1 — Básico: Calculadora con métodos\n");

bool salir = false;

double Sumar(double a, double b) => a + b;
double Restar(double a, double b) => a - b;
double Multiplicar(double a, double b) => a * b;
double Dividir(double a, double b) => a / b;

while (!salir)
{
    Console.WriteLine("1. Sumar");
    Console.WriteLine("2. Restar");
    Console.WriteLine("3. Multiplicar");
    Console.WriteLine("4. Dividir");
    Console.WriteLine("5. Salir");
    Console.Write("Selecciona una opción (1-5): ");

    string opcion = Console.ReadLine() ?? "";

    if (opcion == "5")
    {
        salir = true;
        Console.WriteLine("¡Hasta luego!");
        continue;
    }

    if (opcion == "1" || opcion == "2" || opcion == "3" || opcion == "4")
    {

        Console.Write("Ingresa el primer número (a): ");
        double.TryParse(Console.ReadLine(), out double a);

        Console.Write("Ingresa el segundo número (b): ");
        double.TryParse(Console.ReadLine(), out double b);

        double resultado = 0;
        string nombreOperacion = "";

        switch (opcion)
        {
            case "1":
                resultado = Sumar(a, b);
                nombreOperacion = "suma";
                break;

            case "2":
                resultado = Restar(a, b);
                nombreOperacion = "resta";
                break;

            case "3":
                resultado = Multiplicar(a, b);
                nombreOperacion = "multiplicación";
                break;

            case "4":
                if (b == 0)
                {
                    Console.WriteLine("Error: No se puede dividir entre cero.");
                    nombreOperacion = "";
                }
                else
                {
                    resultado = Dividir(a, b);
                    nombreOperacion = "división";
                }
                break;
        }


        if (opcion != "4" || b != 0)
        {
            Console.WriteLine($"Resultados: La {nombreOperacion} de {a} y {b} es: {resultado}");
        }

        Console.WriteLine();
    }
    else
    {
        Console.WriteLine(" Error: Opción no válida. Por favor elige entre 1 y 5.");
    }
}