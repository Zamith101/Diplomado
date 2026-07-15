Console.Write("Nombre: ");
string Nombre = Console.ReadLine() ?? "";

Console.Write("Profesión: ");
string Profesion = Console.ReadLine() ?? "";

Console.Write("Area de interés: ");
string A_interes = Console.ReadLine() ?? "";

Console.Write("Herramienta Favorita: ");
string H_favorita = Console.ReadLine() ?? "";

Console.Write("Proyecto Deseado: ");
string P_deseado = Console.ReadLine() ?? "";


Console.WriteLine();
Console.WriteLine("======================================");
Console.WriteLine("      Perfil profesional      ");
Console.WriteLine("======================================");
Console.WriteLine($"Nombre: {Nombre}");
Console.WriteLine($"Profesión: {Profesion}");
Console.WriteLine($"Área de interés: {A_interes}");
Console.WriteLine($"Herramienta Favorita: {H_favorita}");
Console.WriteLine($"Proyecto Deseado: {P_deseado}");
Console.WriteLine("=====================================");
