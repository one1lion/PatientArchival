using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PatientArchive.Models;
using PatientArchive.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PatientArchive.Services {
  public class RadiologyReportsService : IRadiologyReportsService {
    private readonly HttpClient httpClient;
    public RadiologyReportsService(HttpClient httpClient) {
      this.httpClient = httpClient;
    }
    public async Task<IEnumerable<Direport>> GetRadiologyReports() {
      return await httpClient.GetJsonAsync<Direport[]>("api/RadiologyReports");
    }

    public async Task<Direport> GetRadiologyReport(int FileID) {
      return await httpClient.GetJsonAsync<Direport>($"api/RadiologyReports/{FileID}");
    }

    public async Task<IEnumerable<Direport>> RadiologySearch(FilterState filterState) {
      Console.WriteLine($"Performing Search Request for \r\n{Newtonsoft.Json.JsonConvert.SerializeObject(filterState)}");
      IEnumerable<Direport> reports = await httpClient.GetJsonAsync<Direport[]>($"api/RadiologyReports/RadiologySearch?MedicalRecordNumber={filterState.MedicalRecordNumber}&AccountNumber={filterState.AccountNumber}&FirstName={filterState.FirstName}&LastName={filterState.LastName}&patIdent={filterState.PatientIdentifier}");
      //IQueryable<Direport> query = reports.AsQueryable();

      //if (!string.IsNullOrEmpty(inputMedicalRecordNumber))
      //{
      //    query = query.Where(report => report.Mrn.Contains(inputMedicalRecordNumber));
      //}

      //if (!string.IsNullOrEmpty(inputAccountNumber))
      //{
      //    query = query.Where(report => report.AccountNo.Contains(inputAccountNumber));
      //}

      //if (!string.IsNullOrEmpty(inputFirstName))
      //{
      //    query = query.Where(report => report.FirstName.Contains(inputFirstName));
      //}

      //if (!string.IsNullOrEmpty(inputLastName))
      //{
      //    query = query.Where(report => report.LastName.Contains(inputLastName));
      //}
      //reports = query.AsEnumerable();

      return await Task.FromResult(reports);
    }

  }
}
