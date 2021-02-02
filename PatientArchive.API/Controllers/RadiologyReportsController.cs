using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientArchive.API.Models;
using PatientArchive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientArchive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RadiologyReportsController : ControllerBase
    {

        private IRadiologyReportsRepository radiologyReportsRepository;
        public RadiologyReportsController(IRadiologyReportsRepository radiologyReportsRepository)
        {
            this.radiologyReportsRepository = radiologyReportsRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetRadiologyReports()
        {
            try
            {
                return Ok(await radiologyReportsRepository.GetRadiologyReports());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpGet("{FileID:int}")]
        public async Task<ActionResult<Direport>> GetRadiologyReport(int FileID)
        {
            try
            {
                var result = await radiologyReportsRepository.GetRadiologyReport(FileID);

                if(result == null)
                {
                    return NotFound();
                }
                else
                {
                    return result;
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpGet("{RadiologySearch}")]
        public async Task<ActionResult<IEnumerable<Direport>>> RadiologySearch(string MedicalRecordNumber, string AccountNumber, string FirstName, string LastName, string patIdent)
        {
            try
            {
                var result = await radiologyReportsRepository.RadiologySearch(MedicalRecordNumber, AccountNumber, FirstName, LastName, patIdent);

                if(result.Any())
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }



    }
}
