using CafeteriaWebApi.Data.Entities;
using CafeteriaWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CafeteriaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleOrderLineController : ControllerBase
    {
        private readonly ISalesOrderLineService _saleOrderLineService;

        public SaleOrderLineController(ISalesOrderLineService SolService)
        {
            _saleOrderLineService = SolService;
        }

        [HttpGet("{idSol}")]
        public ActionResult<SaleOrderLine> GetSaleOrderLine(int idSol)
        {
            var saleOrderLine = _saleOrderLineService.GetSaleOrderLineById(idSol);

            if (saleOrderLine == null)
            {
                return NotFound();
            }

            return saleOrderLine;
        }
    }
}
