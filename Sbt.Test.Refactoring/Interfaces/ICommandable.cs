using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sbt.Test.Refactoring.Interfaces
{
    public interface ICommandable
    {
        /// <summary>
        /// TODO - заменить строковые комманды на конкретный класс и соответствующую обработку.
        /// Возможно рассмотреть подход с объявленнием интерфейса под конкретные команды и избавления от общего.
        /// </summary>
        /// <param name="command"></param>
        void Command(string command);
    }
}
