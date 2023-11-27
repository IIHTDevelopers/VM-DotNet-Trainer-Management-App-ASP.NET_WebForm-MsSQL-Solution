using TimeManagement.Models;
using TimeManagementApp.DAL.Interrfaces;
using TimeManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace TimeManagementApp.Controllers
{
    public class TimeController : ApiController
    {
        private readonly ITimeService _service;
        public TimeController(ITimeService service)
        {
            _service = service;
        }
        public TimeController()
        {
            // Constructor logic, if needed
        }
        [HttpPost]
        [Route("api/Time/CreateTime")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> CreateTime([FromBody] Time model)
        {
            var leaveExists = await _service.GetTimeById(model.Id);
            var result = await _service.CreateTime(model);
            return Ok(new Response { Status = "Success", Message = "Time created successfully!" });
        }


        [HttpPut]
        [Route("api/Time/UpdateTime")]
        public async Task<IHttpActionResult> UpdateTime([FromBody] Time model)
        {
            var result = await _service.UpdateTime(model);
            return Ok(new Response { Status = "Success", Message = "Time updated successfully!" });
        }


        [HttpDelete]
        [Route("api/Time/DeleteTime")]
        public async Task<IHttpActionResult> DeleteTime(long id)
        {
            var result = await _service.DeleteTimeById(id);
            return Ok(new Response { Status = "Success", Message = "Time deleted successfully!" });
        }


        [HttpGet]
        [Route("api/Time/GetTimeById")]
        public async Task<IHttpActionResult> GetTimeById(long id)
        {
            var expense = await _service.GetTimeById(id);
            return Ok(expense);
        }


        [HttpGet]
        [Route("api/Time/GetAllTimes")]
        public async Task<IEnumerable<Time>> GetAllTimes()
        {
            return _service.GetAllTimes();
        }
    }
}
