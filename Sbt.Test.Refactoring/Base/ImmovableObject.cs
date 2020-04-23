using Sbt.Test.Refactoring.Interfaces;

namespace Sbt.Test.Refactoring.Base
{
    public abstract class ImmovableObject : IPositionable
    {
        protected int[] _position = new int[] { 0, 0 };
        public int GetPositionX()
        {
            return _position[0];
        }

        public int GetPositionY()
        {
            return _position[1];
        }
    }
}
