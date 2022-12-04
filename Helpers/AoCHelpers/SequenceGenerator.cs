using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoCHelpers;

public static class SequenceGenerator
{
    public static IEnumerable<(int x, int y)> GeneratePositions(int numberOfPositions, int xStart, int yStart, int xDelta, int yDelta, bool includeStart = false)
    {
        if(includeStart)
            yield return (xStart, yStart);

        for(var i = 1; i <= numberOfPositions; i++)
        {
            yield return (xStart + (xDelta * i), yStart + (yDelta * i));
        }
    }
}
