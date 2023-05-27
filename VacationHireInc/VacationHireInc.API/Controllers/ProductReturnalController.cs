using System;
using Microsoft.AspNetCore.Mvc;
using VacationHireInc.Domain.DataTransferObjects;
using VacationHireInc.Service.Orders;
using VacationHireInc.Service.VechicleReturnalInfos.Interfaces;

namespace VacationHireInc.API.Controllers
{
    [Route("api/orders/product-returnals")]
    [ApiController]
    public class ProductReturnalController : ControllerBase
    {
        private readonly ICreateVechicleReturnalInfoStrategy createVechicleReturnalInfoStrategy;
        private readonly IGetVechicleReturnalInfoStrategy getVechicleReturnalInfoStrategy;

        public ProductReturnalController(
            ICreateVechicleReturnalInfoStrategy createVechicleReturnalInfoStrategy,
            IGetVechicleReturnalInfoStrategy getVechicleReturnalInfoStrategy)

		{
            this.createVechicleReturnalInfoStrategy = createVechicleReturnalInfoStrategy;
            this.getVechicleReturnalInfoStrategy = getVechicleReturnalInfoStrategy;
        }

        [HttpPost("vechicle-returnals", Name = "CreateVechicleReturnalInfo")]
        public async Task<IActionResult> PostVechicleReturnalInfo([FromBody] VechicleReturnalInfoCreationDto vechicleReturnalInfo)
        {
            if (vechicleReturnalInfo == null)
            {
                return BadRequest();
            }
            var vechicleReturnalToReturn = await createVechicleReturnalInfoStrategy.CreateOrder(vechicleReturnalInfo);
            return Created("GetVechicleReturnalInfo", vechicleReturnalToReturn);
        }

        [HttpGet("vechicle-returnals/{id}", Name = "GetVechicleReturnalInfo")]
        public async Task<IActionResult> GetVechicleReturnalInfo(Guid id)
        {
            var vechicleReturnalToReturn = await getVechicleReturnalInfoStrategy.GetVechicleReturnalInfo(id);
            return Ok(vechicleReturnalToReturn);
        }
    }
}

