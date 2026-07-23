using System;
using System.Linq;

Console.WriteLine("Ejercicio 3 — Reto: Clase Estudiante");

Estudiante est = new Estudiante();
est.Nombre = "María Pérez";
est.Edad = 20;
est.AgregarNota(8.5);
est.AgregarNota(7.0);
est.AgregarNota(6.5);
est.MostrarInfo();

class Estudiante
{
	public string Nombre { get; set; }

	private int edad;
	public int Edad
	{
		get => edad;
		set
		{
			if (value < 5)
				throw new ArgumentException("Edad inválida. Debe ser >= 5.");
			edad = value;
		}
	}

	private double[] notas = new double[5];
	private int contadorNotas = 0;

	public void AgregarNota(double nota)
	{
		if (nota < 0 || nota > 10)
			throw new ArgumentException("Nota inválida. Debe estar entre 0 y 10.");
		if (contadorNotas >= notas.Length)
			throw new InvalidOperationException("El arreglo de notas está lleno.");
		notas[contadorNotas++] = nota;
	}

	public double Promedio
	{
		get
		{
			if (contadorNotas == 0) return 0;
			return notas.Take(contadorNotas).Average();
		}
	}

	public string Estado
	{
		get
		{
			double p = Promedio;
			if (p >= 6) return "Aprobado";
			if (p >= 4) return "Recuperación";
			return "Reprobado";
		}
	}

	public void MostrarInfo()
	{
		Console.WriteLine($"Nombre: {Nombre}");
		Console.WriteLine($"Edad: {Edad}");
		var notasList = contadorNotas == 0 ? "" : string.Join(", ", notas.Take(contadorNotas).Select(n => n.ToString("0.##")));
		Console.WriteLine($"Notas: {notasList}");
		Console.WriteLine($"Promedio: {Promedio.ToString("0.00")}" );
		Console.WriteLine($"Estado: {Estado}");
	}
}


