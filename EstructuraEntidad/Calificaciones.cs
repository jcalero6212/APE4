using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructuraEntidad
{
        public class Calificaciones
        {
            public int IdCalificaciones { get; set; }
            public int IdMatricula { get; set; }
            public string Notas { get; set; }
            public decimal Promedio { get; set; }
            public string Descripcion { get; set; }

            // Constructor
            public Calificaciones(int idMatricula, string notas, decimal promedio, string descripcion)
            {
                IdMatricula = idMatricula;
                Notas = notas;
                Promedio = promedio;
                Descripcion = descripcion;
            }

        public Calificaciones( int idcalificaciones,int idMatricula, string notas, decimal promedio, string descripcion)
        {
            IdCalificaciones = idcalificaciones;
            IdMatricula = idMatricula;
            Notas = notas;
            Promedio = promedio;
            Descripcion = descripcion;
        }

        public Calificaciones()
             {
              }
    }
 }

