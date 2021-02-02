using System;
using System.Collections.Generic;

namespace PatientArchive.Models
{
    public partial class LabReports
    {
        public int FileId { get; set; }
        public string PatientIdentifier { get; set; }
        public string FileReference { get; set; }
        public string FileName { get; set; }
        public string AccountNo { get; set; }
        public string Mrn { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Zip { get; set; }
        public DateTime? Dob { get; set; }
        public string Ssn { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
    }
}
