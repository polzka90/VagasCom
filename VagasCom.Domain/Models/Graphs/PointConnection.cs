﻿using System;
using System.Collections.Generic;
using System.Text;

namespace VagasCom.Domain.Models.Graphs
{
    internal class PointConnection
    {
        internal Point TargetPoint { get; private set; }
        internal double Distance { get; private set; }

        internal PointConnection(Point targetPoint, double distance)
        {
            TargetPoint = targetPoint;
            Distance = distance;
        }
    }
}
