<template>
    
    <div>
        <Header />
            <div class="container izquierda">
                <h5><b>Modificar empleado</b></h5>
                <form action="" >                    
                    <div class="form-group">
                    <label for="nombres">Nombres</label>
                    <input type="text" class="form-control" id="nombres" name="nombres" v-model="form.nombre">
                    </div>
                    <div class="form-group">
                    <label for="apellidos">Apellidos</label>
                    <input type="text" class="form-control" id="apellidos" name="apellidos" v-model="form.apellido">
                    </div>
                    <div class="form-group">
                    <label for="direccion">Direccio:</label>
                    <input type="text" class="form-control" id="direccion" name="direccion" v-model="form.direccion">
                    </div>
                    <div class="form-group">
                    <label for="telefono">Telefono</label>
                    <input type="number" class="form-control" id="telefono" name="telefono" v-model="form.telefono">
                    </div>            
                    <div class="form-group">
                    <label for="id_tipo_sangre">Puesto</label>
                    <input type="text" class="form-control" id="puesto" name="puesto" v-model="form.idPuesto">
                    </div>
                    <div class="form-group">
                    <label for="dpi">DPI</label>
                    <input type="text" class="form-control" id="dpi" name="dpi" v-model="form.dpi">
                    </div>
                    <div class="form-group">
                    <label for="fecha_nacimiento">Fecha de nacimiento</label>
                    <input type="date" class="form-control" id="fecha_nacimiento"  name="fecha_nacimiento" v-model="form.fechaNacimiento">
                    </div>
                    <div class="form-group">
                    <label for="fecha_nacimiento">Fecha de ingreso</label>
                    <input type="date" class="form-control" id="fecha_ingreso"  name="fecha_ingreso" v-model="form.fechaIngresoRegistro">
                    </div>
                    <br>
                    
                    <button  class="btn btn-info" name="btn_editar" id="btn_editar" v-on:click="editar()">Actualizar</button>
                    <button  class="btn btn-danger" name="btn_eliminar" id="btn_eliminar" v-on:click="eliminar()" >Eliminar</button>
                    <button  class="btn btn-secondary" name="btn_salir" id="btn_salir" v-on:click="salir()">Salir</button>
                </form>   
            </div>
        <Footer />
    </div>
</template>

<script>
import Header from '@/components/HeaderView.vue';
import Footer from '@/components/FooterView.vue';
import axios from 'axios';
export default{
    name: "EditarView",
    components:{
        Header,
        Footer
    },
    data:function(){
        return{
            //empleadosId:null,
            form:{
                "idEmpleado": "",
                "nombre": "",
                "apellido": "",
                "direccion": "",
                "telefono": "",
                "idPuesto": "",
                "dpi": "",
                "fechaNacimiento": "",
                "fechaIngresoRegistro": ""
            }
        }
    },
    methods:{
        editar(){
            axios.put("https://localhost:5001/api/Empleados",this.form)
            .then(data =>{
                console.log(data);
            })
        },
        salir(){
            this.$router.push("/");
        }, eliminar(){
            var enviar = {
                "empleadoId" : this.form.empleadoId
            };
            axios.delete("https://localhost:5001/api/Empleados", {body:enviar})
            .then(datos=>{
                console.log(datos);
                this.$router.push("/");
            })
        }
    },
    mounted:function(){
        this.from.empleadosId = this.$route.params.id;
        axios.get("https://localhost:5001/api/Empleados?id="+ this.from.empleadosId)
        .then(datos =>{
            //console.log(datos);
            this.form.nombre = datos.data[0].Nombre;
            this.form.apellido = datos.data[0].Apellido;
            this.form.direccion = datos.data[0].Direccion;
            this.form.telefono = datos.data[0].Telefono;
            this.form.idPuesto = datos.data[0].IdPuesto;
            this.form.dpi = datos.data[0].Dpi;
            this.form.fechaNacimiento = datos.data[0].FechaNacimiento;
            this.form.fechaIngresoRegistro = datos.data[0].FechaIngresoRegistro;
            console.log(this.form);
        })
    }
}
</script>

<style scoped>
.izquierda{
    text-align: left;
  }
</style>