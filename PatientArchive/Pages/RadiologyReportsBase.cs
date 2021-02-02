using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PatientArchive.Models;
using PatientArchive.Services;
using PatientArchive.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientArchive.Pages {
  public class RadiologyReportsBase : ComponentBase {
    [Inject]
    public IRadiologyReportsService RadiologyReportsService { get; set; }

    [Inject]
    public FilterState FilterState { get; set; }

    [Parameter]
    public IEnumerable<Direport> RadiologyReports { get; set; }

    [Parameter]
    public IEnumerable<Direport> RadiologySearch { get; set; }

    public Direport RadiologyReport { get; set; } = new Direport();

    public string[] columnNames { get; set; }

    protected override async Task OnInitializedAsync() {
      await InitialLoad();
    }

    protected async Task InitialLoad() {
      columnNames = typeof(Direport).GetProperties()
      .Select(property => property.Name)
      .ToArray();

      RadiologyReports = await RadiologyReportsService.GetRadiologyReports();
    }

    protected async Task FilterButton() {
      try {
        Console.WriteLine("Filtering List");
        FilterState.Filtering = true;
        RadiologyReports = await RadiologyReportsService.RadiologySearch(FilterState);
        FilterState.FilterApplied = true;
        //await InitialLoad();
      } catch (Exception e) {
        string Error = e.ToString();
      } finally {
        FilterState.Filtering = false;
      }
    }
  }
}
