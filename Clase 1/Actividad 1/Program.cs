Console.WriteLine("======================================");
Console.WriteLine("       FICHA PERSONAL                 ");
Console.WriteLine("======================================");

Console.Write("Nombre: ");
string nombre = Console.ReadLine() ?? "";

Console.Write("Edad: ");
string Edad = Console.ReadLine() ?? "";

Console.Write("Ciudad de residencia: ");
string ciudad = Console.ReadLine() ?? "";

Console.Write("Ocupacion actual: ");
string ocupacion = Console.ReadLine() ?? "";

Console.Write("Comida favorita: ");
string Comida = Console.ReadLine() ?? "";

Console.Write("Pasatiempo: ");
string Pasatiempo = Console.ReadLine() ?? "";

Console.WriteLine();
Console.WriteLine("========== FICHA PERSONAL ==========");
Console.WriteLine($"Nombre:      {nombre}");
Console.WriteLine($"Edad:        {Edad}");
Console.WriteLine($"Ciudad:      {ciudad}");
Console.WriteLine($"Ocupacion:   {ocupacion}");
Console.WriteLine($"Comida favorita: {Comida}");
Console.WriteLine($"Pasatiempo:  {Pasatiempo}");
Console.WriteLine("=====================================");
Console.WriteLine($"Registro completado, {nombre}!");