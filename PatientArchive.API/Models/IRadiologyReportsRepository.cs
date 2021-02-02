using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientArchive.Models;

namespace PatientArchive.API.Models
{
    public interface IRadiologyReportsRepository
    {
        Task<IEnumerable<Direport>> RadiologySearch(string inputMedicalRecordNumber, string inputAccountNumber, string inputFirstName, string inputLastName, string patIdent);
        Task<IEnumerable<Direport>> GetRadiologyReports();
        Task<Direport> GetRadiologyReport(int FileID);
    }
}
