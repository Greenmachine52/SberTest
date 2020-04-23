using Sbt.Test.Refactoring.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbt.Test.Refactoring.Base
{
    public abstract class MoveableObject : BaseUnit, IPositionable, IOrientable,ICommandable
    {
        protected int[] _position = new int[] { 0, 0 };
        protected int[] _field = new int[] { 5, 5 };
        protected Orientation _orientation = Orientation.North;

        /// <summary>
        /// TODO: В данный момент реализация комманды осуществляет за счет передачи стринги.
        /// Перепись - переопределением метода. Заменить на класс команды c дополнительными параметрами
        /// </summary>
        /// <param name="command"></param>
        public virtual void Command(string command)
        {
            if (command == "F")
            {
                MoveForwards();
            }
            else if (command == "T")
            {
                TurnClockwise();
            }
        }
        protected virtual void MoveForwards()
        {
            if (_orientation == Orientation.North)
            {
                _position = new int[] { _position[0], _position[1] + 1 };
            }
            else if (_orientation == Orientation.East)
            {
                _position = new int[] { _position[0] + 1, _position[1] };
            }
            else if (_orientation == Orientation.South)
            {
                _position = new int[] { _position[0], _position[1] - 1 };
            }
            else if (_orientation == Orientation.West)
            {
                _position = new int[] { _position[0] - 1, _position[1] };
            }

            if (_position[0] > _field[0] || _position[1] > _field[1])
            {
                throw new TractorInDitchException();
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

        public Orientation Orientation
        {
            get
            {
                return _orientation;
            }
        }

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
