namespace Configit.Ace.JLR.Grid {
  public struct JlrGridJobTypes {
    public const string ExportFileWriter = "ProFET Export File Writer";
    public const string InitializeProfetExport = "Intialize ProFET Export";
    public const string StartProfetExport = "Start ProFET Export";
    public const string FinalizeProfetExport = "Finalise ProFET Export";
    public const string BmFaFileWriter = "Export BM Feature Applicability";
    public const string BmsFaWriter = "Export BMS Feature Applicability";
    public const string CbmsFaWriter = "Export CBMS Feature Applicability";
    public const string FASGeneration = "Feature Applicability Generation";
    public const string ValidationReportStart = "Start a Validation Report Export";
    public const string ValidationReportStoreModel = "Store Model For Validation Reports";
    public const string ValidationReportSplitScopes = "Generate and Split the scopes";
    public const string ValidationReportExecuteSolves = "Solve for a scope list";
    public const string ValidationReportGetOrderability = "Get Orderability for scopes";
    public const string ValidationReportMapOrderability = "Map Orderability with solves";
    public const string ValidationReportMapBisonAndDescription = "Map Codes and Description";
    public const string ValidationReportExportToExcel = "Validation Report Export To Excel";
    public const string ValidationReportZipFile = "Validation Report Zip File";
    public const string ValidationReportStoreFile = "Store Zipped File for download";
  }
}
