using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Configit.Ace.JLR.Grid;
using Configit.Ace.JLR.Grid.ValidationReport;
using Configit.Grid;

namespace GridTester {
  class Program {
    static void Main( string[] args ) {
      var gridClient = new GridClient( "http://localhost:8070" );
      gridClient.Connect( "developer", "OptimisticJungleTaxi" ).Wait();

      //var task = gridClient.AddAndStartJob( new TaskStartInfo( "NameRepeater", 10, true ) );
      var startInput = new ValidationReportStartTaskParameters() {
        BuildDate = "2016-05-01",
        ExecutionDateTime = DateTime.Now.ToShortDateString(),
        FamilyCodes = new List<string>() {
            "MODELYEAR_FAM",
            "BUILDPHASE_FAM",
            "PRODUCTRANGE_FAM",
            "MARKET_FAM",
            "BROCHUREMODEL_FAM",
            "DERIVATIVE_FAM"
        },
        GlobalVersionId = "0",
        Markets = new List<string>() {
          "UK_F"
        },
        ModelYear = "16MY",
        BuildPhase = "16MY_JOB1",
        ProductRangeId = "X0",
        ReleaseChannelId = "GenericSolve",
        WorkItemId = 0,
        ModelId = ""
      };
      var taskTree = GetTaskTree( startInput );

      var InitializeTask = new TaskStartInfo( JlrGridJobTypes.ValidationReportStart ) {
        AdditionalDependencies = taskTree
      };


      var job = gridClient.AddAndStartJob( "Test", InitializeTask,
        JobPriority.High,
        new Dictionary<string, string> { { "First", "Test" } }
      );
      job.Wait();

    }

    private static IEnumerable<ITaskStartInfo> GetTaskTree( ValidationReportStartTaskParameters validationReportData ) {
      var builder = new ValidationReportTaskTreeBuilder();
      return builder.BuildTasks( validationReportData );
    }
  }
}
