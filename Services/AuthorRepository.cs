using System.Collections.Generic;
using Fisher.Bookstore.Data;
using Fisher.Bookstore.Models;

namespace Fisher.Bookstore.Services
{

    public class AuthorssRepository : IAuthorRepository
    {
        private readonly BookstoreContext db;

        public AuthorRepository(BookstoreContext db)
        {
            this.db = db;
        }

        public int AddAuthor(Author author)
        {
            db.Authors.Add(author);
            db.SaveChanges();
            return author.Id;
        }

        public bool Authorexists(int authorId)
        {
            return (db.Authors.Find(authorId) != null);

        }

        public void DeleteAuthor(int authorId)
        {
            var author = db.Authors.Find(authorId);
            db.Authors.Remove(author);
            db.SaveChanges();
        }

        public Book GetAuthor(int authorId)
        {
            return db.Authors.Find(authorId);
        }

        public IEnumerable<Author> GetAuthors()
        {
            return db.Authors;
        }

        public void UpdateAuthor(Author author)
        {
            var updateAuthor = db.Authors.Find(author.Id);
            updateAuthor.Name = author.Name;
            db.Authors.Update(updateAuthor);
            db.SaveChanges();
        }
    }
}