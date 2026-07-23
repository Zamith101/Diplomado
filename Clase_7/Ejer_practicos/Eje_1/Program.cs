namespace EjemploEncapsulamiento
{
    public class Producto
    {
        // ----------------------------------------------------
        // 1. CAMPOS PRIVADOS (Atributos ocultos)
        // Guardan el estado interno de la clase.
        // NUNCA deben ser públicos.
        // ----------------------------------------------------
        private string nombre;
        private double precio;


        // ----------------------------------------------------
        // 2. PROPIEDADES PÚBLICAS (Accesores get y set)
        // Controlan la lectura y escritura del estado.
        // ----------------------------------------------------
        
        // Propiedad con validación personalizada
        public double Precio
        {
            get 
            { 
                return precio; 
            }
            set 
            {
                // Validación para proteger la integridad del dato
                if (value < 0)
                {
                    Console.WriteLine("❌ El precio no puede ser negativo.");
                    return;
                }
                precio = value;
            }
        }

        // Propiedad Auto-implementada con lectura pública y modificación privada
        public string Nombre 
        { 
            get { return nombre; }
            private set { nombre = value; } 
        }


        // ----------------------------------------------------
        // 3. CONSTRUCTOR
        // Inicializa el objeto garantizando un estado válido desde el inicio.
        // ----------------------------------------------------
        public Producto(string nombreInicial, double precioInicial)
        {
            Nombre = nombreInicial;
            Precio = precioInicial; // Pasa por la validación del setter
        }


        // ----------------------------------------------------
        // 4. MÉTODOS PÚBLICOS (Comportamiento controlado)
        // Exponen las operaciones permitidas sobre el objeto.
        // ----------------------------------------------------
        public void AplicarDescuento(double porcentaje)
        {
            if (porcentaje <= 0 || porcentaje > 50)
            {
                Console.WriteLine("❌ Descuento no permitido (máximo 50%).");
                return;
            }

            double descuento = precio * (porcentaje / 100);
            precio -= descuento;
            Console.WriteLine($"✅ Descuento del {porcentaje}% aplicado. Nuevo precio: ${precio:F2}");
        }
    }
}
