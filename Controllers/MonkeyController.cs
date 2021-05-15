using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PostgresCRUD.Models;
using PostgresCRUD.DataAccess;

namespace monkey_shelter.Controllers
{
    [ApiController]
    [Route("rest/monkeys")]
    public class MonkeyController : ControllerBase
    {

        private readonly IDataAccessProvider _dataAccessProvider;  

        public MonkeyController(IDataAccessProvider dataAccessProvider)  
        {  
            _dataAccessProvider = dataAccessProvider;  
        }  

        [HttpPost]  
        public IActionResult Create([FromBody]Monkey monkey)  
        {  
            if (ModelState.IsValid)  
            {  
                Guid obj = Guid.NewGuid();  
                monkey.Id = obj.ToString();  
                _dataAccessProvider.AddMonkeyRecord(monkey);
                return Ok();  
            }  
            return BadRequest();  
        }  
 
    }
}
