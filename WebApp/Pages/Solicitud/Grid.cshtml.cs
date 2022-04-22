using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;
using WBL;

namespace WebApp.Pages.Solicitud
{
    public class GridModel : PageModel
    {
        private readonly ISolicitudService solicitudService;

        public GridModel(ISolicitudService solicitudService)
        {
            this.solicitudService = solicitudService;
        }

        public IEnumerable<SolicitudEntity> GridList  = new List<SolicitudEntity>();
        
        public async Task<IActionResult> OnGet()
        {
            try
            {
                GridList = await solicitudService.Get();

                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }
        public async Task<JsonResult> OnDeleteEliminar(int id)
        {
            try
            {
                var result = await solicitudService.Delete(new SolicitudEntity()
                {
                    IdSolicitud = id
                }
                );


                return new JsonResult(result);
            }
            catch (Exception ex)
            {

                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }
    }
}
 