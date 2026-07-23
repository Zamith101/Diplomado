Console.WriteLine("Ejercicio 2 — Intermedio: Clase Cuenta de Ahorros\n");

CuentaAhorros cuenta = new CuentaAhorros(1000);
    cuenta.MostrarSaldo();
    cuenta.Depositar(500);
    cuenta.MostrarSaldo();
    bool r1 = cuenta.Retirar(200);
    Console.WriteLine(r1 ? "Retiro exitoso\n" : "Saldo insuficiente\n");
    bool r2 = cuenta.Retirar(2000);
    Console.WriteLine(r2 ? "Retiro exitoso\n" : "Saldo insuficiente\n");
    cuenta.MostrarSaldo();

public class CuentaAhorros
{
    private double saldo;

    public double Saldo => saldo;

    public CuentaAhorros(double saldoInicial)
    {
        saldo = saldoInicial;
    }

    public void Depositar(double monto)
    {
        if (monto > 0)
        {
            saldo += monto;
            Console.WriteLine($"Depósito exitoso: +{monto:C}\n");
        }
        else
        {
            Console.WriteLine("La cantidad a depositar debe ser mayor que cero.\n");
        }
    }

    public bool Retirar(double monto)
    {
        if (monto > 0 && monto <= saldo)
        {
            saldo -= monto;
            return true;
        }
        return false;
    }

    public void MostrarSaldo()
    {
        Console.WriteLine($"Saldo actual: {saldo:C}\n");
    }

}