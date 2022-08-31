using IvanRetoCurso.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IvanRetoCurso.Models
{
    public class EmpleadoViewModel
    {
        public List<EmployeesIvan> datos { get; set; }

        public int Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string RFC { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int PositionId { get; set; }
        public bool IsDeleted { get; set; }


    }

}