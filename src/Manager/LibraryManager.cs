public class LibraryManager
{
    List<Book> books = new List<Book>();

    public bool Load()
    {
        return true;
    }

    public bool Save()
    {
        return false;
    }

    public bool AddBookAction()
    {
        Console.Clear();
        WaitBeforeGoBack();
        return true;
    }

    public bool ListBookAction()
    {
        Console.Clear();
        Helper.DrawTable(books);
        WaitBeforeGoBack();
        return true;
    }

    public bool SearchBookAction()
    {
        Console.Clear();
        Console.Write("Arama yapmak için kitap yada yazar adı giriniz: ");
        string searchKey = Console.ReadLine() ?? "";
        List<Book> findedBooks = books.FindAll(book =>
            book.Title.Contains(searchKey, StringComparison.OrdinalIgnoreCase)
            || book.Author.Contains(searchKey, StringComparison.OrdinalIgnoreCase)
        );

        Console.WriteLine("");
        if (findedBooks.Count == 0)
        {
            Console.WriteLine("Kitap bulunamadı.");
        }
        else
        {
            Helper.DrawTable(findedBooks);
        }

        WaitBeforeGoBack();
        return true;
    }

    public bool LoanBookAction()
    {
        Console.Clear();
        Helper.DrawTable(books);
        Console.WriteLine("\nÖdünç alınacak kitabın ISBN numarasını giriniz:");
        string isbn = Console.ReadLine() ?? "";
        Book? findedBook = books.Find(book => book.Isbn == isbn);

        Console.WriteLine("");
        if (findedBook == null)
        {
            Console.WriteLine("ISBN bulunamadı.");
        }
        else
        {
            if (findedBook.AvailableCount() > 0)
            {
                findedBook.DueDates.Add(DateTime.Now.AddDays(7));
                Console.WriteLine("Ödünç işlemi başarılı.");
            }
            else
            {
                Console.WriteLine("Bu kitap için boşta kopya bulunmamakta.");
            }
        }

        WaitBeforeGoBack();
        return true;
    }

    public bool ReturnBookAction()
    {
        Console.Clear();

        Helper.DrawTable(books);
        Console.WriteLine("\nİade edilecek kitabın ISBN numarasını giriniz:");
        string isbn = Console.ReadLine() ?? "";
        Book? findedBook = books.Find(book => book.Isbn == isbn);

        Console.WriteLine("");
        if (findedBook == null)
        {
            Console.WriteLine("ISBN bulunamadı.");
        }
        else
        {
            if (findedBook.DueDates.Count > 0)
            {
                findedBook.DueDates.Remove(findedBook.DueDates.Min());
                Console.WriteLine("İade işlemi başarılı.");
            }
            else
            {
                Console.WriteLine("Bu kitap için ödünç verilmiş kopya bulunmamakta.");
            }
        }

        WaitBeforeGoBack();
        return true;
    }

    public bool ExpiredBooksAction()
    {
        Console.Clear();
        string rowFormat = "| {0, -20} | {1, -20} | {2, -20} | {3, -20} |";
        string divider = "+" + new string('-', 91) + "+";
        Console.WriteLine(divider);
        Console.WriteLine(string.Format(rowFormat, "Title", "Author", "ISBN", "Due Date"));
        Console.WriteLine(divider);
        foreach (Book book in books)
        {
            foreach (DateTime dueDate in book.DueDates)
            {
                if (dueDate.CompareTo(DateTime.Now) > 0)
                    continue;
                Console.WriteLine(
                    string.Format(
                        rowFormat,
                        book.Title.Length > 20 ? book.Title.Substring(0, 20) : book.Title,
                        book.Author.Length > 20 ? book.Author.Substring(0, 20) : book.Author,
                        book.Isbn.Length > 20 ? book.Isbn.Substring(0, 20) : book.Isbn,
                        dueDate.ToShortDateString()
                    )
                );
                Console.WriteLine(divider);
            }
        }
        WaitBeforeGoBack();
        return true;
    }

    private void WaitBeforeGoBack()
    {
        Console.Write("\nGeri dönmek için bir tuşa basınız.");
        Console.ReadKey();
    }
}
