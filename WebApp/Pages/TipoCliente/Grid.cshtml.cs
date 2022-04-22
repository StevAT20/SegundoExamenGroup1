using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Entity.dbo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.TipoCliente
{
    public class GridModel : PageModel
    {
        private readonly ITipoClienteService tipoClienteService;

        public GridModel(ITipoClienteService tipoClienteService)
        {
            this.tipoClienteService = tipoClienteService;
        }

        public IEnumerable<TipoClienteEntity> GridList { get; set; } = new List<TipoClienteEntity>();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await tipoClienteService.Get();

                return Page();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public async Task<JsonResult> OnDeleteEliminar(int Id)
        {
            try
            {
                var result = await tipoClienteService.Delete(new()
                {
                    IdTipoCliente = Id
                }); ;

                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity
                {
                    CodeError = ex.HResult,
                    MsgError = ex.Message
                });
            }
        }
    }
}
