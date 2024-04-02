using Domen.Primitivies;
using Domen.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domen.Entities
{
    /// <summary>
    /// Основная сущность персоны(человека)
    /// </summary>
    public class Pers: BaseEntity
    {
        public Pers(FullName fullName, DateTime birthDay, Gender gender, string telegram, string phoneNumber) 
        { 
            // ToDo: Сделать валидацию для всех остальных. Для DateTime 150 лет максимум, Gender проверка не undefined, по Telegram есть собачка ник не больше 20 символов, +37377 , 123 не допускается, 5 цифр
            FullName = ValidateFullName(fullName);
            BirthDay = ValidateBirthDay(birthDay);
            Gender = ValidateGender(gender);
            Telegram = ValidateTelegram(telegram);
            PhoneNumber = ValidatePhoneNumber(phoneNumber);
            // ToDo: * FluentValidation
        }
        public FullName FullName { get; private set; }
        public DateTime BirthDay { get; private set; }
        public int Age => DateTime.Now.Year - BirthDay.Year;
        public Gender Gender { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Telegram { get; private set; }
        
        /// <summary>
        /// Валидация полного имени (имени, фамилии и отчества)
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        private FullName ValidateFullName(FullName fullName) 
        {
            // ToDo: !Добавить валидацию допускающаю только русские или английские буквы
            // Проверка на ввод имени, фамилии
            if (string.IsNullOrEmpty(fullName.FirstName))
            {
                throw new ValidationException(ValidationMessages.NullOrEmpty(fullName.FirstName));
            }

            if (string.IsNullOrEmpty(fullName.LastName))
            {
                throw new ValidationException(ValidationMessages.NullOrEmpty(fullName.LastName));
            }

            // Проверка на допустимые символы (только русские или английские буквы)
            if (!fullName.FirstName.All(char.IsLetter))
            {
                throw new ValidationException(ValidationMessages.IsLetter(fullName.FirstName));
            }

            if (!fullName.LastName.All(char.IsLetter))
            {
                throw new ValidationException(ValidationMessages.IsLetter(fullName.LastName));
            }

            if (!string.IsNullOrEmpty(fullName.MiddleName) && !fullName.MiddleName.All(char.IsLetter))
            {
                throw new ValidationException(ValidationMessages.IsLetter(fullName.MiddleName));
            }

            return fullName;
        }
        /// <summary>
        /// Валидация даты рождения
        /// </summary>
        /// <param name="birthDay"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        private DateTime ValidateBirthDay(DateTime birthDay)
        {
            // Проверка на ввод
            if (birthDay == DateTime.MinValue)
            {
                throw new ValidationException(ValidationMessages.NullOrEmpty(birthDay.ToString()));
            }
            // Проверка не является ли дата больше сегодняшней и указанный возраст не больше 150  
            if (birthDay > DateTime.Now || birthDay < DateTime.Now.AddYears(-150))
            {
                throw new ValidationException(ValidationMessages.IsBirthdayFalse(birthDay.ToString()));
            }

            return birthDay;
        }
        /// <summary>
        /// Валидация пола
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        private Gender ValidateGender(Gender gender)
        {
            // Проверка указан ли пол
            if (gender == Gender.Undefined)
            {
                throw new ValidationException(ValidationMessages.IsGenderUndefined(gender.ToString()));
            }
            return gender;
        }
        /// <summary>
        /// Валидация ника в телеграме
        /// </summary>
        /// <param name="telegram"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        private string ValidateTelegram(string telegram)
        {
            // Проверка указан ли ник
            if (string.IsNullOrEmpty(telegram))
            {
                throw new ValidationException(ValidationMessages.NullOrEmpty(telegram));
            }
            // Проверка на длинну и содержание собачки
            if (telegram.Length > 20 || !telegram.Contains("@"))
            {
                throw new ValidationException(ValidationMessages.IsTelegramFalse(telegram));
            }

            return telegram;
        }
        /// <summary>
        /// Валидация номера телефона
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        private string ValidatePhoneNumber(string phoneNumber)
        {
            // Проверка на ввод номера телефона
            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new ValidationException(ValidationMessages.NullOrEmpty(phoneNumber));
            }

            string pattern = @"^\+37377(?!.*[123])\d{6}$";

            // Проверка на правильность указанного номера телефона
            if (!Regex.IsMatch(phoneNumber, pattern))
            {
                throw new ValidationException(ValidationMessages.IsPhoneNumberFalse(phoneNumber));
            }

            return phoneNumber;
        }
    }

}