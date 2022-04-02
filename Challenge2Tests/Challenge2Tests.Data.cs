namespace Challenge2Tests;

using System.Linq;
using System.Text;

public partial class Challenge2Tests
{
    private string GetPerformanceTestingString()
    {
        int capacity = 2400002;
        StringBuilder sb = new StringBuilder(capacity);

        sb.Append("a");
        foreach (int count in Enumerable.Range(0, 100000))
        {
            sb.Append("bcdefghijklmnopqrstuvwxy");
        }
        sb.Append("z");

        return sb.ToString();
    }
}