using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientArchive.Models;
using PatientArchive.State;

namespace PatientArchive.Services
{
    public interface IRadiologyReportsService
    {
        Task<IEnumerable<Direport>> GetRadiologyReports();
        Task<Direport> GetRadiologyReport(int FileID);
        Task<IEnumerable<Direport>> RadiologySearch(FilterState filterState);
    }
}
