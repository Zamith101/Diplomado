Console.WriteLine("======================================");
Console.WriteLine("      Presentacion de producto        ");
Console.WriteLine("======================================");

Console.Write("Nombre: ");
string Nombre = Console.ReadLine() ?? "";

Console.Write("Categoria: ");
string Categoria = Console.ReadLine() ?? "";

Console.Write("Precio: ");
string Precio = Console.ReadLine() ?? "";

Console.Write("Cantidad: ");
string Cantidad = Console.ReadLine() ?? "";

Console.Write("Descripcion: ");
string Descripcion = Console.ReadLine() ?? "";


Console.WriteLine();
Console.WriteLine("============ PRODUCTO ===============");
Console.WriteLine($"Nombre:      {Nombre}");
Console.WriteLine($"Categoria:   {Categoria}");
Console.WriteLine($"Precio:      {Precio}");
Console.WriteLine($"Cantidad:    {Cantidad}");
Console.WriteLine($"Descripcion: {Descripcion}");
Console.WriteLine("=====================================");
