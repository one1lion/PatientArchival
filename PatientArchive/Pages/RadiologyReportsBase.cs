using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PatientArchive.Models;
using PatientArchive.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientArchive.Pages
{
    public class RadiologyReportsBase : ComponentBase
    {
        [Inject]
        public IRadiologyReportsService RadiologyReportsService { get; set; }

        [Parameter]
        public IEnumerable<Direport> RadiologyReports { get; set; }

        [Parameter]
        public IEnumerable<Direport> RadiologySearch { get; set; }

        public Direport RadiologyReport  { get; set; } = new Direport();

        public String[] columnNames { get; set; }

        public string inputMedicalRecordNumber = string.Empty;
        public string inputAccountNumber = string.Empty;
        public string inputFirstName = string.Empty;
        public string inputLastName = string.Empty;

        [Parameter]
        public int isFiltered { get; set; }


        public override async Task SetParametersAsync(ParameterView parameters)
        {
            if (((isFiltered == 0) && (RadiologyReports == null)))
            {
                columnNames = typeof(Direport).GetProperties()
                .Select(property => property.Name)
                .ToArray();

                RadiologyReports = await RadiologyReportsService.GetRadiologyReports();
            }
            await base.SetParametersAsync(parameters);
        }

        protected override async Task OnInitializedAsync()
        {
            await InitialLoad();
        }

        protected async Task InitialLoad()
        {
             columnNames = typeof(Direport).GetProperties()
             .Select(property => property.Name)
             .ToArray();

             RadiologyReports = await RadiologyReportsService.GetRadiologyReports();
        }

        protected async Task FilterButton()
        {
            try
            {
                isFiltered = 1;
                await InitialLoad();
            }
            catch(Exception e)
            {
                string Error = e.ToString();
            }
        }
    }
}
