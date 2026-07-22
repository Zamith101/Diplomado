Console.WriteLine("Ejercicio 1 — Básico: Sumatoria");

Console.Write("Ingresa un número entero positivo (n): ");
int n = int.Parse(Console.ReadLine() ?? "0");

int suma = 0;

for (int i = 1; i <= n; i++)
{
    suma += i;
}

Console.WriteLine($"La suma de 1 hasta {n} es: {suma}");

