using System;
using System.Collections.Generic;
using System.Linq;

namespace Configit.Ace.JLR.Grid.ValidationReport {
  public class ValidationReportSplitScopesOutput {
    public ValidationReportSplitScopesOutput( List<string> stringGuid ) {
      Guids = stringGuid.Select( s => new Guid( s ) ).ToArray();
    }

    public ValidationReportSplitScopesOutput( List<Guid> guid ) {
      Guids = guid.ToArray();
    }

    public Guid[] Guids { get; set; }
  }
}