namespace PatientArchive.State {
  public class FilterState {
    public string MedicalRecordNumber { get; set; }
    public string AccountNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PatientIdentifier { get; set; }

    public bool FilterApplied { get; set; }
    public bool Filtering { get; set; }
  }
}
