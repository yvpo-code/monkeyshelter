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
    [Route("rest/reports")]
    public class ReportController : ControllerBase
    {

        private readonly IDataAccessProvider _dataAccessProvider;  
  
        public ReportController(IDataAccessProvider dataAccessProvider)  
        {  
            _dataAccessProvider = dataAccessProvider;  
        }  
  
        [HttpGet]
        public List<SpeciesCount> Get()  
        {  
            return _dataAccessProvider.GetSpeciesCount();
        }  
   
    }
}
