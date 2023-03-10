/*-----------------------------------------------------------------------------------------------------
 * Controleers -> <- Service LAyer -> <- Repository Layer/Business Layer
 ------------------------------------------------------------------------------------------------------*/




using CrudOperation.CommonLayer.Model;
using CrudOperation.ServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CrudOperation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudOperationController : ControllerBase
    {
        public readonly ICrudOperationSL _crudOperationSL;
        public CrudOperationController(ICrudOperationSL crudOperationSL)
        {
            _crudOperationSL= crudOperationSL;
        }


        [HttpPost]
        [Route(template: "CreateRecord")]
        public async Task<IActionResult> CreateRecord(CreateRecordRequest request)
        {
            CreateRecordResponse response = null;
            try
            {
                response = await _crudOperationSL.CreateRecord(request);
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message= ex.Message;
            }
            return Ok(response);
        }

        [HttpGet]
        [Route(template: "ReadRecord")]
        public async Task<IActionResult> ReadRecord()
        {
            ReadRecordResponse response = null; 
            try
            {
                response = await _crudOperationSL.ReadRecord();  
            }
            catch(Exception ex)
            {
                response.IsSuccess = false; 
                response.Message= ex.Message;   
            }
            return Ok(response);
        }


        [HttpPut]
        [Route(template:"UpdateRecord")]
        public async Task<IActionResult> UpdateRecord(UpdateRecordRequest request)
        {
            UpdateRecordResponse response = null;
            try
            {
                response = await _crudOperationSL.UpdateRecord(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess= false;  
                response.Message= ex.Message;   
            }
            return Ok(response);
        }


        [HttpDelete]
        [Route(template: "DeleteRecord")]
        public async Task<IActionResult> DeleteRecord(DeleteRecordRequest request)
        {
            DeleteRecordResponse response = null;
            try
            {
                response = await _crudOperationSL.DeleteRecord(request);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }

    }
}
