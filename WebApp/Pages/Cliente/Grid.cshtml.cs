using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;
using WBL;


namespace WebApp.Pages.Cliente
{
    public class GridModel : PageModel
    {
        private readonly IClienteService clienteService;

        public GridModel(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }
         
        public IEnumerable<ClienteEntity> GridList { get; set; } = new List<ClienteEntity>();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await clienteService.Get();

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
                var result = await clienteService.Delete(new()
                {
                    IdCliente = Id
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
