using System;
using System.Drawing;

namespace Sbt.Test.Refactoring.Units
{
    public class Stoun : UnitBase
    {
        private Point position;

        public Stoun(Map map, Point position) : base(map)
        {
            if (position.X > Map.Width || position.Y > Map.Height)
            {
                throw new ArgumentOutOfRangeException(nameof(position));
            }
        }
    }
}
