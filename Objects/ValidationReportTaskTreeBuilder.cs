using System.Collections.Generic;
using System.Linq;
using Configit.Ace.JLR.Grid.ValidationReport;
using Configit.Grid;

namespace Configit.Ace.JLR.Grid {

  public class ValidationReportTaskTreeBuilder {

    public IEnumerable<ITaskStartInfo> BuildTasks( ValidationReportStartTaskParameters validationReportData ) {

      //var buildReleaseTask = new TaskStartInfo("Compile Model");
      //yield return buildReleaseTask;

      var storeModelTask = BuildStoreModelTask( validationReportData );//, buildReleaseTask );
      yield return storeModelTask;

      var taskProcessorCount = 3;

      var splitScopesInput = new ValidationReportSplitScopesInput() {
        FeatureFamilyCodes = validationReportData.FamilyCodes,
        ProductRange = validationReportData.ProductRangeId,
        ModelYear = validationReportData.ModelYear,
        Markets = validationReportData.Markets,
        BuildPhase = validationReportData.BuildPhase,
        BuildDate = validationReportData.BuildDate,
        NbOfSolveTaskProcessors = taskProcessorCount
      };

      var splitScopesTask = new TaskStartInfo(
       JlrGridJobTypes.ValidationReportSplitScopes,
       splitScopesInput,
       TaskInputs.Dependency<ValidationReportStoreModelOutput>( storeModelTask ) ) {
        TaskName = JlrGridJobTypes.ValidationReportSplitScopes,
      };

      yield return splitScopesTask;

      var getOrderabilityTask = new TaskStartInfo(
      JlrGridJobTypes.ValidationReportGetOrderability,
      TaskInputs.Dependency<ValidationReportSplitScopesOutput>( splitScopesTask )
      ) {
        TaskName = JlrGridJobTypes.ValidationReportGetOrderability,
      };
      yield return getOrderabilityTask;

      var solveTasks = new List<ITaskStartInfo>();

      for ( int i = 0; i < taskProcessorCount; i++ ) {
        var executeSolvesInput = new ValidationReportExecuteSolveInput() {
          TaskProcessorIndex = i,
          FeatureFamilyCodes = validationReportData.FamilyCodes
        };
        var executeSolvesTask = new TaskStartInfo(
         JlrGridJobTypes.ValidationReportExecuteSolves,
         executeSolvesInput,
         TaskInputs.Dependency<ValidationReportStoreModelOutput>( storeModelTask ),
         TaskInputs.Dependency<ValidationReportSplitScopesOutput>( splitScopesTask )
         ) {
          TaskName = JlrGridJobTypes.ValidationReportExecuteSolves,
        };
        solveTasks.Add( executeSolvesTask );
        yield return executeSolvesTask;
      }

      var mapOrderabilityTask = new TaskStartInfo(
        JlrGridJobTypes.ValidationReportMapOrderability,
       TaskInputs.Collection( solveTasks.Select( TaskInputs.Dependency<ValidationReportExecuteSolveOutput> ).ToArray() ),
       TaskInputs.Dependency<ValidationReportGetOrderabilityOutput>( getOrderabilityTask )
        ) {
        TaskName = JlrGridJobTypes.ValidationReportMapOrderability,
      };

      yield return mapOrderabilityTask;

      var mapBisonAndDescriptionTask = new TaskStartInfo(
        JlrGridJobTypes.ValidationReportMapBisonAndDescription,
        TaskInputs.Dependency<ValidationReportMapOrderabilityOutput>( mapOrderabilityTask )
      ) {
        TaskName = JlrGridJobTypes.ValidationReportMapBisonAndDescription,
      };

      yield return mapBisonAndDescriptionTask;
    }

    private ITaskStartInfo BuildStoreModelTask(
      ValidationReportStartTaskParameters validationReportData ) { //,ITaskStartInfo compileTaskStartInfo ) {

      var storeModelInput = new ValidationReportStoreModelInput() {
        ProductRange = validationReportData.ProductRangeId,
        ReleasePackageToken = validationReportData.ModelId,
        ResourceRepositoryUrl = "ResourceRepUrl"
      };
      var storeModelTask = new TaskStartInfo( JlrGridJobTypes.ValidationReportStoreModel, storeModelInput ) {
        TaskName = JlrGridJobTypes.ValidationReportStoreModel,
        //AdditionalDependencies = new[] { compileTaskStartInfo }
      };

      return storeModelTask;
    }
  }
}
