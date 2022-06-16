using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Tickets : IEquatable<Tickets>
{ 
    public int DurationInHours { get; set; }

    public Tickets(int durationInHours)
    {
        DurationInHours = durationInHours;
    }

    public bool Equals(Tickets other)
    {
        return this.DurationInHours == other.DurationInHours;
    }

}
