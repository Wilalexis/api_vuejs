using System.ComponentModel.DataAnnotations;
namespace web_tarea1.Models{
    public class Empleados{
        [Key]
        public int idEmpleado{get; set;}
        public string nombre{get; set;}
        public string apellido{get; set;}
        public string direccion{get; set;}
        public string telefono{get; set;}
        public string idPuesto{get; set;}
        public string dpi{get; set;}
        public string fechaNacimiento{get; set;}
        public string fechaIngresoRegistro{get; set;}
    }
}