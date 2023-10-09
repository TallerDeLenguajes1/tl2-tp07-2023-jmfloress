using System.Text.Json;
public class AccesoADatos{
    public List<Tarea> Obtener()
    {
        string? jsonString = File.ReadAllText("./Datos/tareas.json");
        List<Tarea>? listadoTareas = JsonSerializer.Deserialize<List<Tarea>>(jsonString);
        return listadoTareas;
    }

    public bool Guardar(List<Tarea> tareas)
    {
        string datosTareas = "./Datos/tareas.json";
        string? formatJson = JsonSerializer.Serialize(tareas);
        File.WriteAllText(datosTareas, formatJson);
        return formatJson != null;
    }
}