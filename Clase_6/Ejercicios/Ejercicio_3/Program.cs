Console.WriteLine("=== Ejercicio 3 — Reto: Clase Cuenta Bancaria ===\n");

CuentaBancaria cuenta = new CuentaBancaria("Ana López", 1000);
cuenta.MostrarSaldo();                 
cuenta.Depositar(500);             
cuenta.MostrarSaldo();                  
bool retiro = cuenta.Retirar(2000);
Console.WriteLine(retiro ? "Retiro exitoso" : "Saldo insuficiente"); 
Console.WriteLine(cuenta.ObtenerResumen());

public class CuentaBancaria
{
    public string Titular { get; set; }
    public decimal Saldo { get; private set; }

    public CuentaBancaria(string titular, decimal saldoInicial)
    {
        Titular = titular;
        Saldo = saldoInicial;
    }

    public void Depositar(decimal cantidad)
    {
        if (cantidad > 0)
        {
            Saldo += cantidad;
            Console.WriteLine($"Depósito de {cantidad:C} realizado. Nuevo saldo: {Saldo:C}\n");
        }
        else
        {
            Console.WriteLine("La cantidad a depositar debe ser positiva.");
        }
    }

    public bool Retirar(decimal cantidad)
    {
        if (cantidad > 0 && cantidad <= Saldo)
        {
            Saldo -= cantidad;
            Console.WriteLine($"Retiro de {cantidad:C} realizado. Nuevo saldo: {Saldo:C}\n");
            return true;
        }
        else
        {
            Console.WriteLine("Cantidad inválida o saldo insuficiente.\n");
            return false;
        }
    }

    public void MostrarSaldo()
    {
        Console.WriteLine($"Titular: {Titular}, Saldo actual: {Saldo:C}\n");
    }

    public string ObtenerResumen()
    {
        return $"\nResumen — Titular: {Titular}, Saldo: {Saldo:C}";
    }
}






















































