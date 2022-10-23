<template>
    <div>
    <Header />
    <div class="container izquierda">
        <h5><b>Ingresar un nuevo empleado</b></h5>  
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
                    
                    <button  class="btn btn-success" name="btn_editar" id="btn_editar" v-on:click="guardar()">Guardar</button>
                    <button  class="btn btn-secondary" name="btn_salir" id="btn_salir" v-on:click="salir()">Salir</button>
                </form>
                <br><br>
    </div>
    <Footer />
</div>
</template>

<script>
import Header from '@/components/HeaderView.vue';
import Footer from '@/components/FooterView.vue';
import axios from 'axios';
export default{
    name: "AgregarView",
    data:function(){
        return{
            //empleadosId:null,
            form:{
                //"idEmpleado": "",
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
    components:{
        Header,
        Footer
    },
    methods:{
        guardar(){
            axios.post("https://localhost:5001/api/Empleados",this.form)
            .then(data =>{
                console.log(data);
                this.makeToast("Hecho","Empleado agregado correctamente","success")
                this.$router.push("/");
            }).catch(e=>{
                console.log(e);
                this.makeToast("Error","Error al guardar","error")
            })
        },
        salir(){
            //console.log("Funciona")
            this.$router.push("/");
        },
        makeToast(titulo,texto,tipo) {
        this.toastCount++
        this.$bvToast.toast(texto, {
          title: titulo,
          variant:tipo,
          autoHideDelay: 5000,
          appendToast: true
        })
      }
    }
}
</script>

<style scoped>
.izquierda{
    text-align: left;
  }
</style>