using Sbt.Test.Refactoring.Commands;
using System.Collections.ObjectModel;

namespace Sbt.Test.Refactoring.Units
{
    public class UnitCollection : Collection<UnitBase>
    {
        public void ExecuteCommand(CommandBase command)
        {
            foreach (var unit in this)
            {
                unit.ExecuteCommand(command);
            }
        }
    }
}
