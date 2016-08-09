using System.Text;
using System.Threading;
using Configit.Grid;

namespace GridTestTaskProcessor {
  public class NameRepeaterTaskProcessor : TaskProcessor<string, int, bool, string> {
    public override string TypeKey => "NameRepeater";
    public override string Name => "Name Repeater";

    public override string Run( string str, int repeat, bool upperCase, CancellationToken cancellationToken, GridServices services ) {
      if ( upperCase ) {
        str = str.ToUpperInvariant();
      }

      var stringBuilder = new StringBuilder();
      for (var i = 0; i < repeat; i++) {
        stringBuilder.Append( str );
        if (i < repeat - 1) {
          stringBuilder.Append( " " );
        }
      }

      return stringBuilder.ToString();
    }
  }
}