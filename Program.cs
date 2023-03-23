
using E_Library.Repository;

using (var db = new E_Library.AppContext())
{
    var bookRep = new BookRepository(db);
    var userRep = new UserRepository(db);

    // добавление пользователей
    userRep.Add("User1", "user1@mail");
    userRep.Add("User2", "user2@mail");

    // добавление книг
    bookRep.Add("Book1", 2023);
    bookRep.Add("Book2", 2023);


    // связь многие ко многим
    var user1 = userRep.SelectUser(1).First();
    var book2 = bookRep.SelectBook(2).First();

    user1.Books = new List<E_Library.Entities.Book>
    {
        book2
    };
    db.SaveChanges();



}