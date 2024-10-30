using Retards.DTO;
using Retards.Services;
using Microsoft.AspNetCore.Mvc;

namespace Retards.API
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Stats_Controller : ControllerBase
    {
        private readonly ILogger<Stats_Controller> _logger;
        private IStats_service<Stats_DTO> _service;

        public Stats_Controller(ILogger<Stats_Controller> logger, IStats_service<Stats_DTO> service)
        {
            _logger = logger;
            _service = service;
            
        }

        [HttpPost]
        public Stats_DTO GetStats(DateTime dateDebut, DateTime dateFin)
        {
            return _service.GetStatCompteDto(dateDebut, dateFin);
        }
        
        [HttpGet]
        public IEnumerable<Stats_DTO> GetAll()
        {
            return _service.GetAllStats();
        }
        
        [HttpDelete]
        public void Delete(int id)
        {
            _service.DeleteStat(id);
        }


    }
}

