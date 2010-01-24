using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ProgrammingContest
{
  public class Program
  {
    [STAThread]
    public static void Main()
    {
      string[] lines = File.ReadAllLines( "../input.txt" );

      // split lines on tab
      var splits =
        (from line in lines
        select line.Split( '\t' )).Skip(1).ToArray();

      // do everything
      var output =
        from split in splits
        where !String.IsNullOrEmpty( split[1] )
        orderby split[1], Convert.ToInt32( split[4] )
        select ParseLine(split);

      // join lines back with tabs
      var joinedOutput =
        from o in output
        select String.Join( "\t", o );

      using ( StreamWriter sw = new StreamWriter( "output.txt" ) )
      {
        sw.WriteLine( lines[0] );
        foreach( var o in joinedOutput )
          sw.WriteLine( o );
      }
    }

    public static string[] ParseLine( string[] line )
    {
      var r = new Regex( "[^A-Za-z]" );
      line[1] = r.Replace( line[1], "" );

      char[] chars = line[1].ToCharArray();
      Array.Reverse( chars );
      line[1] = new string( chars );
      
      return line;
    }
  }
}
