using Microsoft.AspNetCore.Mvc;

namespace tl2_tp07_2023_jmfloress.Controllers;

[ApiController]
[Route("[controller]")]
public class TareasController : ControllerBase
{
    private readonly ILogger<TareasController> _logger;
    private ManejoDeTareas manejoDeTareas;

    public TareasController(ILogger<TareasController> logger)
    {
        _logger = logger;
        AccesoADatos accesoADatos = new AccesoADatos();
        manejoDeTareas = new ManejoDeTareas(accesoADatos);
    }

    [HttpGet("GetTareas")]
    public ActionResult<List<Tarea>> GetTareas()
    {
        List<Tarea> listadoTarea = manejoDeTareas.GetTareas();
        if (listadoTarea.Count() != 0)
            return Ok(listadoTarea);
        return BadRequest("No se encontraron tareas :c");
    }

    [HttpGet("GetTarea/{id}")]
    public ActionResult<Tarea> GetTarea(int id)
    {
        Tarea? tarea = manejoDeTareas.GetTarea(id);
        if (tarea != null)
            return Ok(tarea);
        return BadRequest("No se encontro la tarea :c");
    }

    [HttpGet("GetTareasCompletadas")]
    public ActionResult<List<Tarea>> GetTareasCompletadas()
    {
        List<Tarea> listadoTarea = manejoDeTareas.GetTareasCompletadas();
        if (listadoTarea.Count() != 0)
            return Ok(listadoTarea);
        return BadRequest("No se encontraron tareas :c");
    }

    [HttpPost("AddTarea")]
    public ActionResult<Tarea> AddTarea(Tarea tarea)
    {
        if(manejoDeTareas.AddTarea(tarea))
            return Ok(tarea);
        return BadRequest("No se encontro la tarea :c");
    }

    [HttpPut("SetTarea")]
    public ActionResult<Tarea> SetTarea(Tarea tarea)
    {
        if(manejoDeTareas.SetTarea(tarea))
            return Ok(tarea);
        return BadRequest("No se encontro la tarea o fallo al intentar guardar :c");
    }

    [HttpDelete("DeleteTarea/{id}")]
    public ActionResult<Tarea> DeleteTarea(int id)
    {
        if(manejoDeTareas.DeleteTarea(id))
            return Ok("La tarea se elimino con exito e.e");
        return BadRequest("No se encontro la tarea o fallo al intentar actualizar los datos :c");
    }
}
