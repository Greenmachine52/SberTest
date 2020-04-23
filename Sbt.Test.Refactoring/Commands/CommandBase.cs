namespace Sbt.Test.Refactoring.Commands
{
    public class CommandBase
    {
        protected CommandBase()
        {
            Name = GetType().Name;
        }

        public string Name { get; }
    }
}
