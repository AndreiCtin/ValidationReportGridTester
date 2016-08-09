using System.Collections.Generic;

namespace Configit.Ace.JLR.Grid.ValidationReport {
  public class ValidationReportSplitScopesInput {
    public int NbOfSolveTaskProcessors { get; set; }
    public string BuildDate { get; set; }
    public string BuildPhase { get; set; }
    public string ProductRange { get; set; }
    public string ModelYear { get; set; }
    public IEnumerable<string> Markets { get; set; }

    public List<string> FeatureFamilyCodes { get; set; }
  }
}