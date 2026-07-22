Console.WriteLine("Ejercicio 3 — Reto: Dibujar figuras con asteriscos");

bool salir = false;

while (!salir)
{
    Console.WriteLine("=== Menú de Figuras Geométricas ===");
    Console.WriteLine("1. Cuadrado (n x n)");
    Console.WriteLine("2. Triángulo rectángulo");
    Console.WriteLine("3. Triángulo invertido");
    Console.WriteLine("4. Salir");
    Console.Write("Selecciona una opción (1-4): ");

    string opcion = Console.ReadLine() ?? "";

    if (opcion == "4")
    {
        salir = true;
        Console.WriteLine("Hasta luego.");
        continue;
    }


    if (opcion == "1" || opcion == "2" || opcion == "3")
    {
        Console.Write("Ingresa el tamaño (n): ");
        
        if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
        {
            Console.WriteLine();

            switch (opcion)
            {
                case "1":
                    for (int fila = 1; fila <= n; fila++)
                    {
                        for (int columna = 1; columna <= n; columna++)
                        {
                            Console.Write("*");
                        }
                        Console.WriteLine();
                    }
                    break;

                case "2":
                    for (int fila = 1; fila <= n; fila++)
                    {
                        for (int columna = 1; columna <= fila; columna++)
                        {
                            Console.Write("*");
                        }
                        Console.WriteLine();
                    }
                    break;

                case "3":

                    for (int fila = n; fila >= 1; fila--)
                    {
                        for (int columna = 1; columna <= fila; columna++)
                        {
                            Console.Write("*");
                        }
                        Console.WriteLine();
                    }
                    break;
            }

            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("Error: El tamaño debe ser un número entero positivo mayor a 0.");
        }
    }
    else
    {
        Console.WriteLine("Error: Opción no válida. Por favor elige entre 1 y 4.");
    }
}











