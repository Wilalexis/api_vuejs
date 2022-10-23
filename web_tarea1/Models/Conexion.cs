using Microsoft.EntityFrameworkCore;
namespace web_tarea1.Models{
    class Conexion : DbContext{
        public Conexion (DbContextOptions<Conexion> options) : base(options){}
        public DbSet<Empleados> Empleados {get;set;}   = null!;  
    }

 class Conectar{
           private const string cadenaConexion = "server=localhost;port=3306;database=dbempleado;userid=root;pwd=admin";
            public static Conexion Create(){
                var constructor = new DbContextOptionsBuilder<Conexion>();
                constructor.UseMySQL(cadenaConexion);
                var cn = new Conexion (constructor.Options);
                return cn;

            }
        }

}
