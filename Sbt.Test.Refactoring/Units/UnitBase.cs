using Sbt.Test.Refactoring.Commands;
using System;

namespace Sbt.Test.Refactoring.Units
{
    public class UnitBase
    {
        protected UnitBase(Map map)
        {
            if (map == null)
            {
                throw new ArgumentNullException(nameof(map));
            }

            Map = map;
        }

        protected Map Map { get; }

        public virtual void ExecuteCommand(CommandBase command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
        }
    }
}
