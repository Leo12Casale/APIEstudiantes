using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/estudiantes")]
public class EstudiantesController : ControllerBase
{
    private static EstudiantesRepository _repository = new EstudiantesRepository();


    /// <summary>
    /// Obtiene una lista de todos los elementos.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<Estudiante>> ObtenerTodos()
    {
        var estudiantes = _repository.ObtenerTodos();
        return Ok(estudiantes);
    }

    [HttpGet("{id}")]
    public ActionResult<Estudiante> ObtenerPorId(int id)
    {
        var estudiante = _repository.ObtenerPorId(id);
        if (estudiante != null)
        {
            return Ok(estudiante);
        }
        return NotFound();
    }

    [HttpPost]
    public ActionResult<Estudiante> Crear(Estudiante estudiante)
    {
        var nuevoEstudiante = _repository.Crear(estudiante);
        return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoEstudiante.ID }, nuevoEstudiante);
    }

    [HttpPut("{id}")]
    public ActionResult Actualizar(int id, Estudiante estudiante)
    {
        //Chequeo si existe
        if (_repository.ObtenerPorId(id) == null)
        {
            return NotFound();
        }
        _repository.Actualizar(estudiante);

        return Ok(estudiante);
    }

    [HttpDelete("{id}")]
    public ActionResult Eliminar(int id)
    {
        Estudiante estudianteAEliminar = _repository.ObtenerPorId(id);
        var resultado = _repository.Eliminar(id);
        if (resultado)
        {
            return Ok(estudianteAEliminar);
        }
        return NotFound();
    }
}
