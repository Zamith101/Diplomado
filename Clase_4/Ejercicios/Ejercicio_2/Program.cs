Console.WriteLine("Ejercicio 2 — Intermedio: Adivina el número");

int numeroAleatorio = Random.Shared.Next(1, 101);
int numero = 0;
int contador = 0;


while (numero != numeroAleatorio)
{
    Console.Write("Adivina el número (1-100): ");
    string entrada = Console.ReadLine() ?? "";

    if (int.TryParse(entrada, out numero))
    {
        contador++;

        if (numero > numeroAleatorio)
        {
            Console.WriteLine("El número es menor.\n");
        }
        else if (numero < numeroAleatorio)
        {
            Console.WriteLine("El número es mayor.\n");
        }
        else
        {
            Console.WriteLine("¡Has encontrado el número!");
            Console.WriteLine($"¡Correcto! Adivinaste en {contador} intentos.");
        }
    }
    else
    {
        Console.WriteLine("Error: Por favor ingresa un número entero válido.\n");
    }
}
































