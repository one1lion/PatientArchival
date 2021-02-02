using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientArchive.Models;

namespace PatientArchive.API.Models
{
    public class RadiologyReportsRepository : IRadiologyReportsRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public RadiologyReportsRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<Direport> GetRadiologyReport(int FileID)
        {
            return await applicationDbContext.Direports.FirstOrDefaultAsync(RadReport => RadReport.FileId == FileID);
        }

        public async Task<IEnumerable<Direport>> GetRadiologyReports()
        {
            return await applicationDbContext.Direports.ToListAsync();
        }

        public async Task<IEnumerable<Direport>> RadiologySearch([FromQuery]string inputMedicalRecordNumber = default, [FromQuery]string inputAccountNumber = default, [FromQuery] string inputFirstName = default, [FromQuery] string inputLastName = default, [FromQuery] string patIdent = default)
        {
            IQueryable<Direport> query = applicationDbContext.Direports;

            if(!string.IsNullOrEmpty(inputMedicalRecordNumber))
            {
                query = query.Where(report => report.Mrn.Contains(inputMedicalRecordNumber));
            }

            if (!string.IsNullOrEmpty(inputAccountNumber))
            {
                query = query.Where(report => report.AccountNo.Contains(inputAccountNumber));
            }

            if (!string.IsNullOrEmpty(inputFirstName))
            {
                query = query.Where(report => report.FirstName.Contains(inputFirstName));
            }

            if (!string.IsNullOrEmpty(inputLastName))
            {
                query = query.Where(report => report.LastName.Contains(inputLastName));
            }

            if (!string.IsNullOrEmpty(patIdent))
            {
                query = query.Where(report => report.PatientIdentifier.Contains(patIdent));
            }
            return await query.ToListAsync();
        }
    }
}
