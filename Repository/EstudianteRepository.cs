using System;
using System.Collections.Generic;
using System.Linq;


public class EstudiantesRepository
{
    private static List<Estudiante> estudiantes = new List<Estudiante>();
    private static int nextId = 1;

    public List<Estudiante> ObtenerTodos()
    {
        return estudiantes;
    }

    public Estudiante ObtenerPorId(int id)
    {
        if(id <= 0 || estudiantes.Count() < id)
        {
            return null;
        }
        return estudiantes[id-1];
        
    }

    public Estudiante Crear(Estudiante estudiante)
    {
        estudiante.ID = nextId++;
        estudiantes.Add(estudiante);
        return estudiante;
    }

    public void Actualizar(Estudiante estudiante)
    {
        int id = estudiante.ID;
        estudiantes[id].Nombre = estudiante.Nombre;
        estudiantes[id].Apellido = estudiante.Apellido;
        estudiantes[id].FechaNacimiento = estudiante.FechaNacimiento;
        estudiantes[id].CorreoElectronico = estudiante.CorreoElectronico;
    }

    public bool Eliminar(int id)
    {
        var estudianteExistente = estudiantes.FirstOrDefault(e => e.ID == id);
        if (estudianteExistente != null)
        {
            estudiantes.Remove(estudianteExistente);
            return true;
        }
        return false;
    }
}
