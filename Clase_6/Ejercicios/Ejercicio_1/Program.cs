var persona1 = new Persona("Ana", 25, "Madrid");
var persona2 = new Persona("Carlos", 30, "Barcelona");

persona1.MostrarInformacion();
persona2.MostrarInformacion();

public class Persona
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Ciudad { get; set; }

    public Persona(string nombre, int edad, string ciudad)
    {
        Nombre = nombre;
        Edad = edad;
        Ciudad = ciudad;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Hola, soy {Nombre} y tengo {Edad} años");
    }
}































