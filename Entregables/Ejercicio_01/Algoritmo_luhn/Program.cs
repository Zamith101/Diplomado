using System;
using System.IO;

namespace ValidadorTarjetas
{
    class Program
    {
        static int totalValidas = 0;
        static int totalInvalidas = 0;
        static int totalVisa = 0;
        static int totalMastercard = 0;
        static int totalAmex = 0;
        static int totalDiscover = 0;
        static int totalDesconocida = 0;

        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("=== VALIDADOR DE TARJETAS ===");
                Console.WriteLine("1. Validar una tarjeta");
                Console.WriteLine("2. Validar desde archivo");
                Console.WriteLine("3. Generar número válido");
                Console.WriteLine("4. Estadísticas");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                string entrada = Console.ReadLine();

                try
                {
                    opcion = int.Parse(entrada);

                    if (opcion == 1)
                    {
                        ValidarUnaTarjeta();
                    }
                    else if (opcion == 2)
                    {
                        Console.Write("Ingrese la ruta del archivo: ");
                        string ruta = Console.ReadLine();
                        ValidarDesdeArchivo(ruta);
                    }
                    else if (opcion == 3)
                    {
                        GenerarYMostrarNumero();
                    }
                    else if (opcion == 4)
                    {
                        MostrarEstadisticas();
                    }
                    else if (opcion == 5)
                    {
                        Console.WriteLine("Adiós");
                    }
                    else
                    {
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Error: Ingrese un número válido. (" + ex.Message + ")");
                }

                Console.WriteLine();

            } while (opcion != 5);
        }

        // metodo de la opcion 1
        static void ValidarUnaTarjeta()
        {
            Console.Write("Ingrese el número de la tarjeta: ");
            string numero = Console.ReadLine();

            bool esValida = ValidarTarjeta(numero);
            string marca = IdentificarMarca(numero);

            ActualizarEstadisticas(marca, esValida);

            Console.WriteLine("\nNúmero: " + numero);
            Console.WriteLine("Marca: " + marca);
            Console.WriteLine("Estado: " + (esValida ? " VÁLIDA" : " INVÁLIDA"));
        }

        // metodo que implementa el algoritmo de Luhn
        static bool ValidarTarjeta(string numero)
        {
            // si esta vacio o tiene letras debe ser i9nvalido
            if (numero.Length < 2)
            {
                return false;
            }

            char[] arregloChars = numero.ToCharArray();
            Array.Reverse(arregloChars);
            string invertido = new string(arregloChars);

            int sumaTotal = 0;

            // recorre de izquierda a derecha el número invertido
            for (int i = 0; i < invertido.Length; i++)
            {
                int digito = (int)char.GetNumericValue(invertido[i]);

                // Si no es un número, retorna falso
                if (digito == -1) return false;

                if ((i + 1) % 2 == 0)
                {
                    digito = digito * 2;

                    // Si el numero multiplicado es >= 10, se suman
                    if (digito >= 10)
                    {
                        /* matematicamente es lo mismo que restar 9 como lo dice el mismo algoritmo de luhn,
                        pero lo hago paso a paso para que se entienda */

                        int decena = digito / 10;
                        int unidad = digito % 10;
                        digito = decena + unidad;
                    }
                }

                // sumar todos los digitos
                sumaTotal = sumaTotal + digito;
            }

            // por ultimo, si la suma es múltiplo de 10, el numero de la tarjeta es valido
            if (sumaTotal % 10 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // metodo para identificar la marca
        static string IdentificarMarca(string numero)
        {
            int longitud = numero.Length;

            if (numero.StartsWith("4") && (longitud == 13 || longitud == 16))
            {
                return "Visa";
            }
            
            if (longitud == 16)
            {
                if (numero.StartsWith("51") || numero.StartsWith("52") || numero.StartsWith("53") || numero.StartsWith("54") || numero.StartsWith("55"))
                {
                    return "Mastercard";
                }
            }

            if (longitud == 15 && (numero.StartsWith("34") || numero.StartsWith("37")))
            {
                return "American Express";
            }

            if (longitud >= 16 && longitud <= 19)
            {
                if (numero.StartsWith("6011") || numero.StartsWith("65"))
                {
                    return "Discover";
                }
                
                if (longitud >= 3)
                {
                    string tresPrimeros = numero.Substring(0, 3);
                    int num = int.Parse(tresPrimeros);
                    if (num >= 644 && num <= 649)
                    {
                        return "Discover";
                    }
                }

                if (longitud >= 6)
                {
                    string seisPrimeros = numero.Substring(0, 6);
                    int num6 = int.Parse(seisPrimeros);
                    if (num6 >= 622126 && num6 <= 622925)
                    {
                        return "Discover";
                    }
                }
            }

            return "Desconocida";
        }

        // metodo para leer archivo de la opcion 2 para leer archivo
        static void ValidarDesdeArchivo(string ruta)
        {
            try
            {
                // Intento leer el archivo
                string[] lineas = File.ReadAllLines(ruta);
                Console.WriteLine("\n--- Procesando archivo ---");

                foreach (string linea in lineas)
                {
                    if (string.IsNullOrEmpty(linea) == false)
                    {
                        string numero = linea.Replace(" ", "");
                        bool esValida = ValidarTarjeta(numero);
                        string marca = IdentificarMarca(numero);

                        ActualizarEstadisticas(marca, esValida);

                        Console.WriteLine("Número: " + numero + " | Marca: " + marca + " | Estado: " + (esValida ? " VÁLIDA" : " INVÁLIDA"));
                    }
                }
                Console.WriteLine("--------------------------");
                Console.WriteLine("Resumen: Se procesaron " + lineas.Length + " líneas.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(" Error: No se encontró el archivo.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error al leer el archivo: " + ex.Message);
            }
        }

        // metodo de generacion de numeros de tarjeta validos
        static string GenerarNumeroValido()
        {
            Random random = new Random();
            string numeroParcial = "";

            for (int i = 0; i < 15; i++)
            {
                numeroParcial = numeroParcial + random.Next(0, 10).ToString();
            }

            for (int digitoFinal = 0; digitoFinal <= 9; digitoFinal++)
            {
                string numeroCompleto = numeroParcial + digitoFinal.ToString();
                
                if (ValidarTarjeta(numeroCompleto) == true)
                {
                    return numeroCompleto;
                }
            }

            return "";
        }

        // metodo auxiliar para mostrar el numero que se generó
        static void GenerarYMostrarNumero()
        {
            string nuevoNumero = GenerarNumeroValido();
            string marca = IdentificarMarca(nuevoNumero);

            ActualizarEstadisticas(marca, true);

            Console.WriteLine("\nNúmero: " + nuevoNumero);
            Console.WriteLine("Marca: " + marca);
            Console.WriteLine("Estado:  VÁLIDA");
        }

        // actualizo los contadores de estadisticas
        static void ActualizarEstadisticas(string marca, bool esValida)
        {
            if (esValida)
            {
                totalValidas++;
                
                if (marca == "Visa") totalVisa++;
                else if (marca == "Mastercard") totalMastercard++;
                else if (marca == "American Express") totalAmex++;
                else if (marca == "Discover") totalDiscover++;
                else totalDesconocida++;
            }
            else
            {
                totalInvalidas++;
            }
        }
        static void MostrarEstadisticas()
        {
            Console.WriteLine("\n=== ESTADÍSTICAS ===");
            Console.WriteLine("Total válidas: " + totalValidas);
            Console.WriteLine("Total inválidas: " + totalInvalidas);
            Console.WriteLine("Desglose por marca (válidas):");
            Console.WriteLine("  - Visa: " + totalVisa);
            Console.WriteLine("  - Mastercard: " + totalMastercard);
            Console.WriteLine("  - American Express: " + totalAmex);
            Console.WriteLine("  - Discover: " + totalDiscover);
            Console.WriteLine("  - Desconocida: " + totalDesconocida);
        }
    }
}