using System.Drawing;
using Sbt.Test.Refactoring.Commands;
using System.Collections.Generic;
using System;

namespace Sbt.Test.Refactoring.Units
{
    public class Tractor : UnitBase
    {
        private Point position;
        private Orientation orientation;

        private Dictionary<Type, Action> actions = new Dictionary<Type, Action>();

        public Tractor(Map map) : base(map)
        {
            orientation = Orientation.North;

            actions = new Dictionary<Type, Action>();
            actions[typeof(MoveForwardCommand)] = () => MoveForward();
            actions[typeof(TurnClockwiseCommand)] = () => TurnClockwise();
        }

        public Orientation Orientation => orientation;

        public int PositionX => position.X;

        public int PositionY => position.Y;

        public override void ExecuteCommand(CommandBase command)
        {
            base.ExecuteCommand(command);

            var commandType = command.GetType();

            if (!actions.ContainsKey(commandType))
            {
                return;
            }

            actions[commandType]();
        }

        private void MoveForward()
        {
            if (orientation == Orientation.North)
            {
                position.Y++;
            }
            else if (orientation == Orientation.East)
            {
                position.X++;
            }
            else if (orientation == Orientation.South)
            {
                position.Y--;
            }
            else if (orientation == Orientation.West)
            {
                position.X--;
            }

            if (position.X > Map.Width || position.Y > Map.Height)
            { 
                throw new TractorInDitchException();
            }
        }

        private void TurnClockwise()
        {
            orientation = orientation.GetNext();
        }
    }
}
