using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.TipoCliente
{
    public class EditModel : PageModel
    {
        private readonly ITipoClienteService tipoClienteService;

        public EditModel(ITipoClienteService tipoClienteService)
        {
            this.tipoClienteService = tipoClienteService;
        }

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        [FromBody]
        public TipoClienteEntity Entity { get; set; } = new TipoClienteEntity();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await tipoClienteService.GetByID(new()
                    {
                        IdTipoCliente = id
                    });
                }
                return Page();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var result = new DBEntity();
                //Actualización
                if (Entity.IdTipoCliente.HasValue)
                {
                    result = await tipoClienteService.Update(Entity);
                }
                else
                //Metodo insertar
                {
                    result = await tipoClienteService.Create(Entity);
                }
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
