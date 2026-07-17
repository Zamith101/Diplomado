Console.Write("Ingresa tu edad: ");
string entrada = Console.ReadLine() ?? "0"; // Evitamos advertencias de nulos [cite: 244]

int edad_jubilacion = 65;
int edad = 0;

if (int.TryParse(entrada, out edad))
{
    int años_faltantes = edad_jubilacion - edad;
    Console.WriteLine($"");
    Console.WriteLine($"==============================================");
    Console.WriteLine($"Tu edad actual: {edad} años.");
    Console.WriteLine($"Te faltan {años_faltantes} años para jubilarte");
}
else
{
    Console.WriteLine("Error: Por favor, introduce un número entero válido.");
}

































