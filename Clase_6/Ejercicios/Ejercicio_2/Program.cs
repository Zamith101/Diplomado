Console.WriteLine("Ejercicio 2 — Intermedio: Clase Rectángulo");

Rectangulo r1 = new Rectangulo(5, 3);
Rectangulo r2 = new Rectangulo(1, 1);
r1.MostrarDatos();
r2.MostrarDatos();

public class Rectangulo
{

    public double Base { get; set; }
    public double Altura { get; set; }

    public Rectangulo(double baseRectangulo, double altura)
    {
        Base = baseRectangulo;
        Altura = altura;
    }

    public double CalcularArea()
    {
        return Base * Altura;
    }

    public double CalcularPerimetro()
    {
        return 2 * (Base + Altura);
    }

    public void MostrarDatos()
    {
        Console.WriteLine($"Base: {Base}, Altura: {Altura}, Área: {CalcularArea()}, Perímetro: {CalcularPerimetro()}");
    }
}


















