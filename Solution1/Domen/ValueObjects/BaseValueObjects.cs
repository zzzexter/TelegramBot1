using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.ValueObjects
{
    public abstract class BaseValueObjects
    {
        /// <summary>
        /// ToDo. Найти и реализовать глубокое сравнение(DeepClone,DeepCompare)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>

        // Метод для глубокого клонирования объекта
        protected abstract BaseValueObjects DeepClone();

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // Глубокое клонирование объекта для сравнения
            BaseValueObjects thisObj = DeepClone();
            BaseValueObjects otherObj = ((BaseValueObjects) obj).DeepClone();

            // Сравнение клонов объектов
            return ValueObjectEquals.DeepEquals(thisObj, otherObj);
        }
        
        public override int GetHashCode()
        {
            // В качестве хэш-кода можно использовать хэш-код клонированного объекта
            BaseValueObjects thisObj = DeepClone();
            return thisObj.GetHashCode();
        }
    }
}
