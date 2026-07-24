Console.WriteLine("=== Ejercicio 1 — Básico: Vehículos ===\n");


Auto auto = new() { Marca = "Toyota", Modelo = "Corolla", Puertas = 4 };
Moto moto = new() { Marca = "Yamaha", Modelo = "MT-07", Cilindrada = 689 };
auto.MostrarInfo();
moto.MostrarInfo();

class Vehiculo
{
    public string Marca { get; set; }
    public string Modelo { get; set; }

    public virtual void MostrarInfo()
    {
        Console.WriteLine($"{Marca} {Modelo}");
    }
}

class Auto : Vehiculo
{
    public int Puertas { get; set; }

    public override void MostrarInfo()
    {
        Console.WriteLine($"{Marca} {Modelo} - {Puertas} puertas");
    }
}

class Moto : Vehiculo
{
    public int Cilindrada { get; set; }

    public override void MostrarInfo()
    {
        Console.WriteLine($"{Marca} {Modelo} - {Cilindrada}cc");
    }
}










































