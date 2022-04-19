
namespace App.AxiosProvider   {

    export const ClienteEliminar = (id) => axios.delete<DBEntity>("Cliente/Grid?handler=Eliminar&id=" + id).then(({data})=>data );

    export const ClienteGuardar = (entity) => axios.post<DBEntity>("Cliente/Edit", entity).then(({ data }) => data);

    export const NacionalidadEliminar = (id) => axios.delete<DBEntity>("Nacionalidad/Grid?handler=Eliminar&id=" + id).then(({ data }) => data);

    export const NacionalidadGuardar = (entity) => axios.post<DBEntity>("Nacionalidad/Edit", entity).then(({ data }) => data);


}




