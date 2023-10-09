public enum EstadoTarea
{
    Pendiente,
    EnProgreso,
    Completada
}
public class Tarea
{
    private int id;
    private string? titulo;
    private string? descripcion;
    private EstadoTarea estado;

    public Tarea()
    {

    }

    public Tarea(int id, string titulo, string descripcion, EstadoTarea estado)
    {
        this.Id = id;
        this.Titulo = titulo;
        this.Descripcion = descripcion;
        this.Estado = estado;
    }

    public int Id { get => id; set => id = value; }
    public string? Titulo { get => titulo; set => titulo = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    public EstadoTarea Estado { get => estado; set => estado = value; }
}