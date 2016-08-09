using System.Collections.Generic;

namespace Configit.Ace.JLR.Grid {
  public enum FamilyCodes {
    ModelYear,
    BuildPhase,
    ProductRange,
    Market,
    BrochureModels,
    Derivative
  }

  public class ValidationReportStartTaskParameters {
    public string ModelYear { get; set; }
    public string BuildPhase { get; set; }
    public string ProductRangeId { get; set; }

    public string BuildDate { get; set; }
    public List<string> Markets { get; set; }
    public int WorkItemId { get; set; }
    public string GlobalVersionId { get; set; }
    public string VersionId { get; set; }
    public string UserId { get; set; }
    public string ReleaseChannelId { get; set; }
    public string ExecutionDateTime { get; set; }
    public string ModelId { get; set; }
    public List<string> FamilyCodes { get; set; }
    public int ReleaseTypeId { get; set; }
  }
}