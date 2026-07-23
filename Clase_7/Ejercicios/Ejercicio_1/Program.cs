Console.WriteLine("=== Ejercicio 1 — Básico: Clase Producto ===\n");

var producto1 = new Producto("Laptop", 1200.50, 10);
producto1.MostrarInformacion();

var producto2 = new Producto("Smartphone", 800.00, 25);
producto2.MostrarInformacion();

public class Producto
{
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Stock { get; set; }

    public Producto(string nombre, double precio, int stock)
    {
        Nombre = nombre;
        Precio = precio;
        Stock = stock;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Producto: {Nombre} - Precio: {Precio:C} - Stock: {Stock}");
    }
}
