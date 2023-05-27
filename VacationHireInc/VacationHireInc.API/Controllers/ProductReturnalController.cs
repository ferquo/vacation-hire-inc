using System;
using Microsoft.AspNetCore.Mvc;
using VacationHireInc.Domain.DataTransferObjects;
using VacationHireInc.Service.Orders;
using VacationHireInc.Service.VechicleReturnalInfos.Interfaces;

namespace VacationHireInc.API.Controllers
{
    [Route("api/orders/return-product")]
    [ApiController]
    public class ProductReturnalController : ControllerBase
    {
        private readonly ICreateVechicleReturnalInfoStrategy createVechicleReturnalInfoStrategy;

        public ProductReturnalController(
            ICreateVechicleReturnalInfoStrategy createVechicleReturnalInfoStrategy)

		{
            this.createVechicleReturnalInfoStrategy = createVechicleReturnalInfoStrategy;
        }

        [HttpPost("vechicle", Name = "CreateVechicleReturnalInfo")]
        public async Task<IActionResult> Post([FromBody] VechicleReturnalInfoCreationDto vechicleReturnalInfo)
        {
            if (vechicleReturnalInfo == null)
            {
                return BadRequest();
            }
            var vechicleReturnalToReturn = await createVechicleReturnalInfoStrategy.CreateOrder(vechicleReturnalInfo);
            return Created("GetOrder", vechicleReturnalToReturn);
        }
    }
}

