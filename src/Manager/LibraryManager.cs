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
        WaitBeforeGoBack();
        return true;
    }

    public bool ReturnBookAction()
    {
        Console.Clear();
        WaitBeforeGoBack();
        return true;
    }

    public bool ExpiredBooksAction()
    {
        Console.Clear();
        WaitBeforeGoBack();
        return true;
    }

    private void WaitBeforeGoBack()
    {
        Console.Write("\nGeri dönmek için bir tuşa basınız.");
        Console.ReadKey();
    }
}
