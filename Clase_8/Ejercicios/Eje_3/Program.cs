using System;

Console.WriteLine("=== Ejercicio 3 — Reto: Sistema de Figuras con comparación ===\n");

Figura[] figuras = {
    new Circulo("Rojo", 5),
    new Rectangulo("Azul", 4, 6),
    new Triangulo("Verde", 3, 8)
};

foreach (Figura f in figuras)
{
    f.MostrarDatos();
}

Console.WriteLine();
Figura.CompararAreas(figuras[0], figuras[1]);
Figura.CompararAreas(figuras[1], figuras[2]);

class Figura
{
    public string Color { get; set; }

    public Figura(string color)
    {
        Color = color;
    }

    public virtual double CalcularArea()
    {
        return 0;
    }

    public virtual void MostrarDatos()
    {
        Console.WriteLine($"Figura de color {Color} con área {CalcularArea():0.##}");
    }

    public static void CompararAreas(Figura a, Figura b)
    {
        double areaA = a.CalcularArea();
        double areaB = b.CalcularArea();

        if (areaA > areaB)
        {
            Console.WriteLine($"El área de la figura A ({areaA:0.##}) es mayor que la figura B ({areaB:0.##}).");
        }
        else if (areaA < areaB)
        {
            Console.WriteLine($"El área de la figura B ({areaB:0.##}) es mayor que la figura A ({areaA:0.##}).");
        }
        else
        {
            Console.WriteLine($"Ambas figuras tienen el mismo área ({areaA:0.##}).");
        }
    }
}

class Circulo : Figura
{
    public double Radio { get; set; }

    public Circulo(string color, double radio) : base(color)
    {
        Radio = radio;
    }

    public override double CalcularArea()
    {
        return Math.PI * Radio * Radio;
    }

    public override void MostrarDatos()
    {
        Console.WriteLine($"Círculo de color {Color}, radio {Radio}, área {CalcularArea():0.##}");
    }
}

class Rectangulo : Figura
{
    public double Base { get; set; }
    public double Altura { get; set; }

    public Rectangulo(string color, double @base, double altura) : base(color)
    {
        Base = @base;
        Altura = altura;
    }

    public override double CalcularArea()
    {
        return Base * Altura;
    }

    public override void MostrarDatos()
    {
        Console.WriteLine($"Rectángulo de color {Color}, base {Base}, altura {Altura}, área {CalcularArea():0.##}");
    }
}

class Triangulo : Figura
{
    public double Base { get; set; }
    public double Altura { get; set; }

    public Triangulo(string color, double @base, double altura) : base(color)
    {
        Base = @base;
        Altura = altura;
    }

    public override double CalcularArea()
    {
        return (Base * Altura) / 2;
    }

    public override void MostrarDatos()
    {
        Console.WriteLine($"Triángulo de color {Color}, base {Base}, altura {Altura}, área {CalcularArea():0.##}");
    }
}







































