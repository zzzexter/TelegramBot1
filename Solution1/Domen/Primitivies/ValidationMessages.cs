using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Primitivies
{
    public static class ValidationMessages
    {
        // ToDo: Сделать ошибки шаблонами (StringBuilder, stringFormat)
        public static string NullOrEmpty(string checkObj)
        {
            StringBuilder message = new StringBuilder();
            message.AppendFormat("Поле {0} не может быть null или пустым.", checkObj);
            return message.ToString();
        }

        public static string IsLetter(string checkObj)
        {
            StringBuilder message = new StringBuilder();
            message.Append("Следующие поля должны содержать только буквы: ");
            message.Append(checkObj);
            return message.ToString();
        }

        public static string IsBirthdayFalse(string checkObj)
        {
            StringBuilder message = new StringBuilder();
            message.AppendFormat("Дата {0} должна быть не позже текущей даты и не ранее 150 лет назад. ", checkObj);
            return message.ToString();
        }

        public static string IsGenderUndefined(string checkObj)
        {
            StringBuilder message = new StringBuilder();
            message.AppendFormat("Поле {0} не может быть неопределённым. ", checkObj);
            return message.ToString();
        }

        public static string IsTelegramFalse(string checkObj)
        {
            StringBuilder message = new StringBuilder();
            message.AppendFormat("Поле {0} не должно превышать 20 символов и должно содержать '@'.", checkObj);
            return message.ToString();
        }

        public static string IsPhoneNumberFalse(string checkObj)
        {
            StringBuilder message = new StringBuilder();
            message.AppendFormat("Поле {0} должно соответствовать формату +373XXYYYYYY, где XX - код оператора, а YYYYYY - номер абонента, и код оператора не должен содержать цифры 1, 2 или 3.", checkObj);
            return message.ToString();
        }
    }
}
