using Configit.Grid;

namespace GridTester {
  public class NameRepeaterTaskStartInfo : TaskStartInfo {
    public NameRepeaterTaskStartInfo( string name, int repeat, bool upperCase )
      : base( "NameRepeater", name, repeat, upperCase ) {
    }
  }
}