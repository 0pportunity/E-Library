using E_Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace E_Library.Repository
{
    public class UserRepository : Repository
    {
        private AppContext db;
        public UserRepository(AppContext context) { db = context; }

        /// <summary>
        /// выбор объекта из БД по его идентификатору
        /// </summary>
        /// <returns></returns>
        public List<User> SelectUser(int id)
        {
            return db.Users.Where(user => user.Id == id).ToList();
        }


        /// <summary>
        /// выбор всех объектов
        /// </summary>
        /// <returns></returns>
        public List<User> SelectAllUsers()
        {
            return db.Users.ToList();
        }

        /// <summary>
        /// добавление объекта в БД
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Email"></param>
        public void Add(string name, string email)
        {
            var user1 = new User { Name = name, Email = email };
            db.Users.Add(user1);
            db.SaveChanges();
        }

        /// <summary>
        /// удаление объекта из БД
        /// </summary>
        /// <param name="user"></param>
        public void Delete(User user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
        }

        /// <summary>
        /// обновление имени пользователя (по Id)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newName"></param>
        public void UpdateName(int id, string newName)
        {
            SelectUser(id).First().Name = newName;
        }
    }
}
