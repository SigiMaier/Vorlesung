using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books
{
    public class Library
    {
        private List<string> books;

        

        public Library()
        {
            this.books = new List<string>();
        }

        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name != value)
                {
                    string oldValue = this.name;
                    this.name = value;
                    if (this.NameChanged != null)
                    {
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.OldValue = oldValue;
                        args.NewValue = this.name;
                        this.NameChanged(this, args);
                    }
                }
            }
        }
        public event NameChangedEvent NameChanged;

        public void AddBook(string book)
        {
            this.books.Add(book);
            
            char firstBookTitleLetter = GetFirstLetterOfBookTitle(book);
        }

        private char GetFirstLetterOfBookTitle(string book)
        {
            return book.First();
        }

        private char GetFirstLetterOfBookTitle(char[] book)
        {
            return book[0];
        }
    }
}
