using IvanRetoCurso.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IvanRetoCurso.Services
{
    public class EmpleadoService
    {

        /// <summary>
        /// Método para consultar todos los empleados en la base de datos 
        /// </summary>
        /// <returns>Lista con los objetos de empleados </returns>
        public static List<EmployeesIvan> getAll()
        {
            try
            {
                List<EmployeesIvan> lista = new List<EmployeesIvan>();
                using (var db = new DB_ITSEntities())
                {
                    lista = db.EmployeesIvan.ToList();
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Método para consultar todos las posiciones en la base de datos 
        /// </summary>
        /// <returns>Lista con los objetos de posiciones </returns>
        public static List<PositionsIvan> getAllP()
        {
            try
            {
                List<PositionsIvan> lista = new List<PositionsIvan>();
                using (var db = new DB_ITSEntities())
                {
                    lista = db.PositionsIvan.ToList();
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Metodo para guardar un nuevo empleado
        /// </summary>
        /// <param name="empleado"></param>
        public static void Agregar(EmployeesIvan empleado)
        {
            try
            {
                using (var db = new DB_ITSEntities())
                {
                    db.EmployeesIvan.Add(empleado);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Metodo para actualizar un nuevo empleado
        /// </summary>
        /// <param name="empleado"></param>
        public static void Actualizar(EmployeesIvan empleado)
        {
            try
            {
                using (var db = new DB_ITSEntities())
                {
                    db.Entry(empleado).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Metodo para buscar un empleado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static EmployeesIvan Buscar(int id)
        {
            var empleado = new EmployeesIvan();
            try
            {
                using (var db = new DB_ITSEntities())
                {
                    empleado = db.EmployeesIvan.Find(id);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return empleado;
        }

    }
}