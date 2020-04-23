using Sbt.Test.Refactoring.Base;
using Sbt.Test.Refactoring.Interfaces;


namespace Sbt.Test.Refactoring.Models
{
    public class Wind : NatureEffect, IOrientable, ICommandable
    {
        protected Orientation _orientation = Orientation.North;
        public Orientation Orientation
        {
            get
            {
                return _orientation;
            }
        }

        public void Command(string command) 
        {
            if (command == "T")
            {
                TurnClockwise();
            }
        }

        protected virtual void TurnClockwise()
        {
            if (_orientation == Orientation.North)
            {
                _orientation = Orientation.East;
            }
            else if (_orientation == Orientation.East)
            {
                _orientation = Orientation.South;
            }
            else if (_orientation == Orientation.South)
            {
                _orientation = Orientation.West;
            }
            else if (_orientation == Orientation.West)
            {
                _orientation = Orientation.North;
            }
        }

    }
}
