public interface IEstudianteRepository
{
    List<Estudiante> ObtenerTodos();
    Estudiante ObtenerPorId(int id);
    Estudiante Crear(Estudiante estudiante);
    Estudiante Actualizar(int id, Estudiante estudiante);
    void Eliminar(int id);
}
