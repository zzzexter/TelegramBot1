using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Entities
{
    /// <summary>
    /// Основная сущность персоны(человека)
    /// </summary>
    public class Pers: BaseEntity
    {
        /// <summary>
        /// To Do. Максимально полно описать сущность персоны. Помимо описания сделать все поля через конструктор.
        /// </summary>
        public Pers(string firstName, string lastName, DateTime dateOfBirth, Gender gender, DateTime createdData) 
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            UserGender = gender;
            CreatedData = createdData;
        }
        public static Pers ExampleUsage(string firstName, string lastName, DateTime dateOfBirth, Gender gender, DateTime createdData)
        {            // Создание объекта Pers с помощью конструктора

            return new Pers(firstName, lastName, dateOfBirth, gender, createdData);
        }
    }

}