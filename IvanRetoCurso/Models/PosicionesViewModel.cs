using IvanRetoCurso.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IvanRetoCurso.Models
{
    public class PosicionesViewModel
    {
        public List<PositionsIvan> datos { get; set; }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}