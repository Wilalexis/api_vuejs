<template>
  <div>
    <Header />
      <div class="container izquierda">
        <!--Table-->
        <button class="btn btn-primary" v-on:click="agregar()">Agregar</button>
        <br>
        <br>
<table class="table table-hover table-fixed">

<!--Table head-->
<thead>
  <tr>
    <th>#</th>
    <th>Nombre</th>
    <th>Apellido</th>
    <th>Direccion</th>
    <th>Telefono</th>
    <th>Puesto</th>
    <th>DPI</th>
    <th>Nacimiento</th>
    <th>Ingreso</th>
  </tr>
</thead>
<!--Table head-->

<!--Table body-->
<tbody>
  <tr v-for="empleados in ListaEmpleados" :key="empleados.idEmpleado" v-on:click="editar(empleados.idEmpleado)">
    <th scope="row">{{empleados.idEmpleado}}</th>
    <td>{{empleados.idEmpleado}}</td>
    <td>{{empleados.nombre}}</td>
    <td>{{empleados.apellido}}</td>
    <td>{{empleados.direccion}}</td>
    <td>{{empleados.idPuesto}}</td>
    <td>{{empleados.dpi}}</td>
    <td>{{empleados.fechaNacimiento}}</td>
    <td>{{empleados.fechaIngresoRegistro}}</td>
  </tr>
</tbody>
<!--Table body-->

</table>
<!--Table-->

      </div>

    <Footer />
  </div>
</template>

<script>
// @ is an alias to /src
import Header from '@/components/HeaderView.vue';
import Footer from '@/components/FooterView.vue';
import axios from 'axios';

export default {
  name: 'HomeView',
  data(){
    return{
      ListaEmpleados:null,
      pagina:1
    }
  },
  components: {
    Header,
    Footer
  },
  methods:{
    editar(id){
      //console.log(id);
      this.$route.push('/editarview/' + id);
    },
    agregar(){
      this.$route.push('/agregar');
    }
  },
  mounted:function(){
  let direccion="https://localhost:5001/api/Empleados" + this.pagina;
  axios.get(direccion).then(data =>{
    this.ListaEmpleados = data.data;
    //console.log(data);
  });
}
}

</script>

<style scoped>
  .izquierda{
    text-align: left;
  }
</style>
