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
        throw new NotImplementedException("Please implement the ClaimsHandler.IsLastClaim() method");
    }

    public Plot GetClaimWithLongestSide()
    {
        throw new NotImplementedException("Please implement the ClaimsHandler.GetClaimWithLongestSide() method");
    }
    Plot[] plots;
}
