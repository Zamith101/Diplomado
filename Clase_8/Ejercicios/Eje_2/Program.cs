Console.WriteLine("=== Ejercicio 2 — Intermedio: Figuras geométricas ===\n");

var circulo = new Circulo("Rojo", 5);
var rectangulo = new Rectangulo("Azul", 4, 6);

circulo.MostrarDatos();
rectangulo.MostrarDatos();

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
        Console.WriteLine($"Figura de color {Color}");
    }
}

class Circulo : Figura
{
    public double Radio { get; set; }

    public Circulo(string color, double radio)
        : base(color)
    {
        Radio = radio;
    }

    public override double CalcularArea()
    {
        return Math.PI * Radio * Radio;
    }

    public override void MostrarDatos()
    {
        Console.WriteLine($"Círculo {Color} - Área: {CalcularArea():F2}");
    }
}

class Rectangulo : Figura
{
    public double Base { get; set; }
    public double Altura { get; set; }

    public Rectangulo(string color, double @base, double altura)
        : base(color)
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
        Console.WriteLine($"Rectángulo {Color} - Área: {CalcularArea():F2}");
    }
}


















































