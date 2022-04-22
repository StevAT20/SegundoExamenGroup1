"use strict";
var NacionalidadGrid;
(function (NacionalidadGrid) {
    function OnClickEliminar(id) {
        ComfirmAlert("¿Desea eliminar el registro seleccionado?", "Eliminar", "warning", '#3085d6', '#d33')
            .then(function (result) {
            if (result.isConfirmed) {
                Loading.fire("Borrando");
                App.AxiosProvider.NacionalidadEliminar(id).then(function (data) {
                    Loading.close();
                    if (data.CodeError == 0) {
                        Toast.fire({ title: "El registro se eliminó correctamente", icon: "success" }).then(function () {
                            return window.location.reload();
                        });
                    }
                    else {
                        Toast.fire({ title: data.MsgError, icon: "error" });
                    }
                });
            }
        });
    }
    NacionalidadGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(NacionalidadGrid || (NacionalidadGrid = {}));
//# sourceMappingURL=Grid.js.map