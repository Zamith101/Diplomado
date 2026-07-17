Console.WriteLine("Ejercicio 1 — Básico: ¿Puede votar?");

Console.Write("Ingrese su edad: ");
int Edad = int.Parse(Console.ReadLine() ?? "0") ;

Console.Write("Ingrese su nacionalidad (colombiano/extranjero): ");
string nacionalidad = Console.ReadLine() ?? "";


if (Edad > 18 && nacionalidad == "colombiano")
{
    Console.WriteLine($"");
    Console.WriteLine($"==============================================");
    Console.WriteLine($"Puedes votar en las elecciones.");

}
else
{
    Console.WriteLine("No puedes votar. Debes tener al menos 18 años y ser colombiano");
}




































