var TipoClienteGrid;
(function (TipoClienteGrid) {
    function OnClickEliminar(id) {
        ComfirmAlert("¿Desea eliminar el registro seleccionado?", "Eliminar", "warning", '#3085d6', '#d33')
            .then(function (result) {
            if (result.isConfirmed) {
                Loading.fire("Borrando");
                App.AxiosProvider.TipoClienteEliminar(id).then(function (data) {
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
    TipoClienteGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(TipoClienteGrid || (TipoClienteGrid = {}));
export {};
//# sourceMappingURL=Grid.js.map