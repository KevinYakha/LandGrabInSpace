using System;
using System.Diagnostics;

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot
{
    public Plot(Coord coord1, Coord coord2, Coord coord3, Coord coord4)
    {
        this.coord1 = coord1;
        this.coord2 = coord2;
        this.coord3 = coord3;
        this.coord4 = coord4;
    }
    public Coord coord1 { get; }
    public Coord coord2 { get; }
    public Coord coord3 { get; }
    public Coord coord4 { get; }
}


public class ClaimsHandler
{
    public void StakeClaim(Plot plot)
    {
        if (!IsClaimStaked(plot))
        {
            if (plots == null)
            {
                plots = [plot];
                return;
            }
            Array.Resize(ref plots, plots.Length + 1);
            plots[^1] = plot;
        }
    }

    public bool IsClaimStaked(Plot plot)
    {
        if (plots == null || plots.Length == 0) return false;
        else
        {
            foreach (Plot claimedPlot in plots)
            {
                if(claimedPlot.Equals(plot)) return true;
            }
            return false;
        }
    }

    public bool IsLastClaim(Plot plot)
    {
        return plots[^1].Equals(plot);
    }

    public Plot GetClaimWithLongestSide()
    {
        if (plots == null) return new Plot();
        else
        {
            Plot currentLongest = plots[0];
            for (int i = 1; i < plots.Length; i++)
            {
                double[] currentLongestSideLengths = {
                    Math.Sqrt((currentLongest.coord1.X - currentLongest.coord2.X)^2 +  (currentLongest.coord1.Y - currentLongest.coord2.Y)),
                    Math.Sqrt((currentLongest.coord2.X - currentLongest.coord3.X)^2 +  (currentLongest.coord2.Y - currentLongest.coord3.Y)),
                    Math.Sqrt((currentLongest.coord3.X - currentLongest.coord4.X)^2 +  (currentLongest.coord3.Y - currentLongest.coord4.Y)),
                    Math.Sqrt((currentLongest.coord4.X - currentLongest.coord1.X)^2 +  (currentLongest.coord4.Y - currentLongest.coord1.Y))
                };
                int currentLongestSideIndex = 0;
                for (int j = 1; j < currentLongestSideLengths.Length; j++)
                {
                    if (currentLongestSideLengths[currentLongestSideIndex] < currentLongestSideLengths[j])
                        currentLongestSideIndex = j;
                }

                double[] plotSideLengths = {
                    Math.Sqrt((plots[i].coord1.X - plots[i].coord2.X)^2 +  (plots[i].coord1.Y - plots[i].coord2.Y)),
                    Math.Sqrt((plots[i].coord2.X - plots[i].coord3.X)^2 +  (plots[i].coord2.Y - plots[i].coord3.Y)),
                    Math.Sqrt((plots[i].coord3.X - plots[i].coord4.X)^2 +  (plots[i].coord3.Y - plots[i].coord4.Y)),
                    Math.Sqrt((plots[i].coord4.X - plots[i].coord1.X)^2 +  (plots[i].coord4.Y - plots[i].coord1.Y))
                };
                int plotLongestSideIndex = 0;
                for (int j = 1; j < plotSideLengths.Length; j++)
                {
                    if (plotSideLengths[plotLongestSideIndex] < plotSideLengths[j])
                        plotLongestSideIndex = j;
                }

                if (currentLongestSideLengths[currentLongestSideIndex] < plotSideLengths[plotLongestSideIndex])
                {
                    currentLongest = plots[i];
                }
            }
            return currentLongest;
        }
    }
    Plot[] plots;
}
