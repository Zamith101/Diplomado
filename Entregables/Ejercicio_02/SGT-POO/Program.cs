using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

const string ARCHIVO_DB = "tareas.json";
GestorTareas gestor = new GestorTareas();

gestor.CargarDeJSON(ARCHIVO_DB);

bool salir = false;

while (!salir)
{

    Console.WriteLine("=== GESTOR DE TAREAS ===");
    Console.WriteLine("1. Agregar tarea");
    Console.WriteLine("2. Listar todas");
    Console.WriteLine("3. Listar por categoría");
    Console.WriteLine("4. Listar por prioridad");
    Console.WriteLine("5. Marcar como completada");
    Console.WriteLine("6. Mostrar tareas vencidas");
    Console.WriteLine("7. Eliminar tarea");
    Console.WriteLine("8. Exportar a JSON");
    Console.WriteLine("9. Salir");
    Console.Write("\nSelecciona una opción (1-9): ");

    string opcion = Console.ReadLine() ?? "";

    switch (opcion)
    {
        case "1":
            AgregarTareaMenu(gestor);
            break;
        case "2":
            ListarPolimorfico(gestor.ListarTodas(), "TODAS LAS TAREAS");
            break;
        case "3":
            Console.Write("\nIngresa la categoría a buscar: ");
            string cat = Console.ReadLine() ?? "";
            ListarPolimorfico(gestor.ListarPorCategoria(cat), $"TAREAS DE CATEGORÍA '{cat.ToUpper()}'");
            break;
        case "4":
            Prioridad p = LeerPrioridadValida();
            ListarPolimorfico(gestor.ListarPorPrioridad(p), $"TAREAS DE PRIORIDAD '{p}'");
            break;
        case "5":
            int idComp = LeerEnteroValido("Ingresa el ID de la tarea a marcar como completada: ");
            gestor.Completar(idComp);
            break;
        case "6":
            ListarPolimorfico(gestor.ObtenerVencidas(), "TAREAS VENCIDAS PENDIENTES");
            break;
        case "7":
            int idElim = LeerEnteroValido("Ingresa el ID de la tarea a eliminar: ");
            gestor.Eliminar(idElim);
            break;
        case "8":
            Console.WriteLine("\n--- EXPORTACIÓN SIMPLE (IExportable) ---");
            var lista = gestor.ListarTodas();
            if (lista.Count == 0) Console.WriteLine("No hay tareas registradas.");
            else
            {
                foreach (var t in lista)
                {
                    Console.WriteLine(t.Exportar());
                }
            }
            break;
        case "9":
            salir = true;
            gestor.GuardarEnJSON(ARCHIVO_DB);
            Console.WriteLine("\n¡Gracias por usar el Gestor de Tareas! Hasta luego.");
            break;
        default:
            Console.WriteLine("\nOpción inválida. Intenta nuevamente.");
            break;
    }
}

void AgregarTareaMenu(GestorTareas g)
{
    Console.WriteLine("\n--- AGREGAR NUEVA TAREA ---");
    Console.Write("Título: ");
    string titulo = Console.ReadLine() ?? "";

    Console.Write("Descripción: ");
    string desc = Console.ReadLine() ?? "";

    Prioridad prioridad = LeerPrioridadValida();

    Console.Write("Categoría (ej. Trabajo, Estudio, Hogar): ");
    string categoria = Console.ReadLine() ?? "";

    Console.Write("¿Tiene fecha de vencimiento? (S/N): ");
    string respuesta = (Console.ReadLine() ?? "").Trim().ToUpper();

    if (respuesta == "S")
    {
        DateTime fechaVenc = LeerFechaValida("Ingresa la fecha de vencimiento (dd/mm/yyyy): ");
        g.Agregar(new TareaConVencimiento(titulo, desc, prioridad, categoria, fechaVenc));
    }
    else
    {
        g.Agregar(new Tarea(titulo, desc, prioridad, categoria));
    }
}

void ListarPolimorfico(List<Tarea> tareas, string tituloSeccion)
{
    Console.WriteLine($"\n--- {tituloSeccion} ---");
    if (tareas.Count == 0)
    {
        Console.WriteLine("No se encontraron registros.");
        return;
    }

    foreach (Tarea t in tareas)
    {
        t.MostrarInfo();
        Console.WriteLine("------------------------------------------");
    }
}

Prioridad LeerPrioridadValida()
{
    while (true)
    {
        Console.WriteLine("Selecciona la Prioridad: 0 = Baja, 1 = Media, 2 = Alta, 3 = Critica");
        Console.Write("Opción: ");
        if (int.TryParse(Console.ReadLine(), out int p) && Enum.IsDefined(typeof(Prioridad), p))
        {
            return (Prioridad)p;
        }
        Console.WriteLine("Prioridad no válida. Intenta de nuevo.");
    }
}

int LeerEnteroValido(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        if (int.TryParse(Console.ReadLine(), out int val))
        {
            return val;
        }
        Console.WriteLine("Error: Debes ingresar un número entero válido.");
    }
}

DateTime LeerFechaValida(string mensaje)
{
    while (true)
    {
        Console.Write(mensaje);
        if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime fecha))
        {
            return fecha;
        }
        Console.WriteLine("Formato de fecha inválido. Usa el formato exacto dd/mm/yyyy (ej. 25/12/2026).");
    }
}

public enum Prioridad
{
    Baja,
    Media,
    Alta,
    Critica
}

public class Categoria
{
    public string Nombre { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
}

public interface IExportable
{
    string Exportar();
}

public class Tarea : IExportable
{
    private static int _contadorId = 1;

    public int Id { get; protected set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public Prioridad Prioridad { get; set; }
    public string Categoria { get; set; } = string.Empty;
    public bool Completada { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string TipoTarea { get; set; } = "Simple";

    public Tarea()
    {
        FechaCreacion = DateTime.Now;
    }

    public Tarea(string titulo, string descripcion, Prioridad prioridad, string categoria) : this()
    {
        Id = _contadorId++;
        Titulo = titulo;
        Descripcion = descripcion;
        Prioridad = prioridad;
        Categoria = categoria;
        Completada = false;
    }

    public static void ActualizarContadorId(int ultimoId)
    {
        if (ultimoId >= _contadorId)
        {
            _contadorId = ultimoId + 1;
        }
    }

    public virtual void MostrarInfo()
    {
        string estado = Completada ? "[✓] Completada" : "[ ] Pendiente";
        Console.WriteLine($"ID: {Id} | {estado} | Título: {Titulo} | Categ: {Categoria} | Prioridad: {Prioridad}");
        Console.WriteLine($"   Descripción: {Descripcion}");
        Console.WriteLine($"   Fecha Creación: {FechaCreacion:dd/MM/yyyy HH:mm}");
    }

    public string Exportar()
    {
        return $"{Id}|{Titulo}|{Prioridad}|{Completada}";
    }
}

public class TareaConVencimiento : Tarea
{
    public DateTime FechaVencimiento { get; set; }

    public int DiasRestantes => (FechaVencimiento.Date - DateTime.Now.Date).Days;

    public TareaConVencimiento() : base()
    {
        TipoTarea = "ConVencimiento";
    }

    public TareaConVencimiento(string titulo, string descripcion, Prioridad prioridad, string categoria, DateTime fechaVencimiento)
        : base(titulo, descripcion, prioridad, categoria)
    {
        TipoTarea = "ConVencimiento";
        FechaVencimiento = fechaVencimiento;
    }

    public override void MostrarInfo()
    {
        base.MostrarInfo();
        string estadoVencimiento = DiasRestantes < 0 ? "¡VENCIDA!" : $"{DiasRestantes} días restantes";
        Console.WriteLine($"   Fecha Vencimiento: {FechaVencimiento:dd/MM/yyyy} ({estadoVencimiento})");
    }
}

public class TareaDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public Prioridad Prioridad { get; set; }
    public string Categoria { get; set; } = string.Empty;
    public bool Completada { get; set; }
    public DateTime FechaCreacion { get; set; }
    public string TipoTarea { get; set; } = "Simple";
    public DateTime? FechaVencimiento { get; set; }
}

public class GestorTareas
{
    private List<Tarea> _tareas = new List<Tarea>();

    public void Agregar(Tarea tarea)
    {
        _tareas.Add(tarea);
        Console.WriteLine("\n¡Tarea agregada exitosamente!");
    }

    public void Completar(int id)
    {
        var tarea = _tareas.FirstOrDefault(t => t.Id == id);
        if (tarea != null)
        {
            tarea.Completada = true;
            Console.WriteLine($"\n¡Tarea con ID {id} marcada como completada!");
        }
        else
        {
            Console.WriteLine($"\nError: No se encontró ninguna tarea con el ID {id}.");
        }
    }

    public List<Tarea> ListarTodas() => _tareas;

    public List<Tarea> ListarPorCategoria(string categoria)
    {
        return _tareas.Where(t => t.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Tarea> ListarPorPrioridad(Prioridad prioridad)
    {
        return _tareas.Where(t => t.Prioridad == prioridad).ToList();
    }

    public List<Tarea> ObtenerVencidas()
    {
        return _tareas.OfType<TareaConVencimiento>()
                        .Where(t => t.DiasRestantes < 0 && !t.Completada)
                        .Cast<Tarea>()
                        .ToList();
    }

    public void Eliminar(int id)
    {
        var tarea = _tareas.FirstOrDefault(t => t.Id == id);
        if (tarea != null)
        {
            _tareas.Remove(tarea);
            Console.WriteLine($"\n¡Tarea con ID {id} eliminada correctamente!");
        }
        else
        {
            Console.WriteLine($"\nError: No se encontró ninguna tarea con el ID {id}.");
        }
    }

    public void GuardarEnJSON(string archivo)
    {
        try
        {
            var dtos = _tareas.Select(t => new TareaDto
            {
                Id = t.Id,
                Titulo = t.Titulo,
                Descripcion = t.Descripcion,
                Prioridad = t.Prioridad,
                Categoria = t.Categoria,
                Completada = t.Completada,
                FechaCreacion = t.FechaCreacion,
                TipoTarea = t.TipoTarea,
                FechaVencimiento = (t as TareaConVencimiento)?.FechaVencimiento
            }).ToList();

            string json = JsonSerializer.Serialize(dtos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(archivo, json);
            Console.WriteLine($"\nDatos guardados automáticamente en '{archivo}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError al guardar en el archivo JSON: {ex.Message}");
        }
    }

    public void CargarDeJSON(string archivo)
    {
        if (!File.Exists(archivo))
        {
            Console.WriteLine("\nNo se encontró archivo de persistencia previo. Se iniciará con una lista nueva.");
            return;
        }

        try
        {
            string json = File.ReadAllText(archivo);
            var dtos = JsonSerializer.Deserialize<List<TareaDto>>(json);

            if (dtos != null)
            {
                _tareas.Clear();
                int maxId = 0;

                foreach (var dto in dtos)
                {
                    Tarea tarea;
                    if (dto.TipoTarea == "ConVencimiento" && dto.FechaVencimiento.HasValue)
                    {
                        tarea = new TareaConVencimiento
                        {
                            FechaVencimiento = dto.FechaVencimiento.Value
                        };
                    }
                    else
                    {
                        tarea = new Tarea();
                    }

                    typeof(Tarea).GetProperty(nameof(Tarea.Id))?.SetValue(tarea, dto.Id);
                    tarea.Titulo = dto.Titulo;
                    tarea.Descripcion = dto.Descripcion;
                    tarea.Prioridad = dto.Prioridad;
                    tarea.Categoria = dto.Categoria;
                    tarea.Completada = dto.Completada;
                    tarea.FechaCreacion = dto.FechaCreacion;

                    _tareas.Add(tarea);

                    if (dto.Id > maxId) maxId = dto.Id;
                }

                Tarea.ActualizarContadorId(maxId);
                Console.WriteLine($"\nSe cargaron {_tareas.Count} tareas desde '{archivo}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError o archivo corrupto al cargar JSON: {ex.Message}");
            Console.WriteLine("Se iniciará una nueva sesión limpia.");
        }
    }
}