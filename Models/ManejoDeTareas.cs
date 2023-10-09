public class ManejoDeTareas
{
    private AccesoADatos accesoADatos;

    public ManejoDeTareas(AccesoADatos accesoADatos)
    {
        this.accesoADatos = accesoADatos;
    }

    public bool AddTarea(Tarea tarea)
    {
        if (tarea != null)
        {
            List<Tarea> listadoTarea = accesoADatos.Obtener();
            tarea.Id = listadoTarea.Count() + 1;
            listadoTarea.Add(tarea);
            return accesoADatos.Guardar(listadoTarea);
        }
        return false;
    }

    public Tarea? GetTarea(int id)
    {
        List<Tarea> listadoTarea = accesoADatos.Obtener();
        Tarea? tarea = listadoTarea.SingleOrDefault(t => t.Id == id);
        return tarea;
    }

    public bool SetTarea(Tarea tareaModificada)
    {
        List<Tarea> listadoTarea = accesoADatos.Obtener();
        Tarea? tarea = listadoTarea.SingleOrDefault(t => t.Id == tareaModificada.Id);
        if (tarea != null)
        {
            listadoTarea.Remove(tarea);
            listadoTarea.Add(tareaModificada);
            return accesoADatos.Guardar(listadoTarea);
        }
        return false;
    }

    public bool DeleteTarea(int id)
    {
        List<Tarea> listadoTarea = accesoADatos.Obtener();
        Tarea? tarea = listadoTarea.SingleOrDefault(t => t.Id == id);
        if (tarea != null)
        {
            listadoTarea.Remove(tarea);
            return accesoADatos.Guardar(listadoTarea);
        }
        return false;
    }

    public List<Tarea> GetTareas()
    {
        List<Tarea> listadoTarea = accesoADatos.Obtener();
        return listadoTarea;
    }

    public List<Tarea> GetTareasCompletadas()
    {
        List<Tarea> listadoTarea = accesoADatos.Obtener();
        List<Tarea> listadoTareaCompletada = listadoTarea.Where(t => t.Estado == EstadoTarea.Completada).ToList();
        return listadoTareaCompletada;
    }
}