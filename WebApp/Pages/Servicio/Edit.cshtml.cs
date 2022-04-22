using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace WebApp.Pages.Servicio
{
    public class EditModel : PageModel
    {
        private readonly IServicioService servicioService;

        public EditModel(IServicioService servicioService)
        {
            this.servicioService = servicioService;
        }

        [BindProperty(SupportsGet = true)]
        public int? id { get; set; }

        [BindProperty]
        [FromBody]
        public ServicioEntity Entity { get; set; } = new ServicioEntity();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await servicioService.GetByID(new()
                    {
                        IdServicio = id
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
                //Actualizaci�n
                if (Entity.IdServicio.HasValue)
                {
                    result = await servicioService.Update(Entity);
                }
                else
                //Metodo insertar
                {
                    result = await servicioService.Create(Entity);
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
