using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using web_tarea1.Models;
namespace web_tarea1.Controllers{
    
    [Route("api/[controller]")]
    
    public class EmpleadosController : Controller {
         private Conexion dbConexion;
         public EmpleadosController(){
            dbConexion = Conectar.Create();
         }
         [HttpGet]
         public ActionResult Get(){
             return Ok(dbConexion.Empleados.ToArray());
         }
        [HttpGet("{id}")]
        public ActionResult Get(int id){
            var empleados = dbConexion.Empleados.SingleOrDefault(a => a.idEmpleado == id);
            if(empleados != null){
                return Ok(empleados);
            }else{                
                return NotFound();
            }
        }
        //insert
        [HttpPost]
        public ActionResult Post([FromBody] Empleados empleados){
             if (ModelState.IsValid){
                dbConexion.Empleados.Add(empleados);
                //await dbConexion.SaveChangesAsync();
                dbConexion.SaveChanges();
                return Ok(empleados);
                //return Ok(clientes); retorna el registro ingresado
                //return Created("api/clientes",clientes); retorna los registros
             }else{
                //return BadRequest();
                return NotFound();
             }
        }
        //update
        [HttpPut]
        public ActionResult Put([FromBody] Empleados empleados){
             var v_empleados = dbConexion.Empleados.SingleOrDefault(a => a.idEmpleado == empleados.idEmpleado);
            if (v_empleados != null && ModelState.IsValid) {
            dbConexion.Entry(v_empleados).CurrentValues.SetValues(empleados);
            dbConexion.SaveChanges();
            //await dbConexion.SaveChangesAsync();
            //return Created("api/clientes",clientes);
                return Ok();
            } else {
                //return BadRequest();
                return NotFound();
            }
        }
        //delete
        [HttpDelete("{id}")]
        public ActionResult Delete(int id){
            var empleados = dbConexion.Empleados.SingleOrDefault(a => a.idEmpleado == id);
            if(empleados != null){
                dbConexion.Empleados.Remove(empleados);
                dbConexion.SaveChanges();
                return Ok();
            }else {
                //return BadRequest();
                return NotFound();
            }
        }

    }
}