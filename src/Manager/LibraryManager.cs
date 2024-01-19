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
        WaitBeforeGoBack();
        return true;
    }

    public bool SearchBookAction()
    {
        Console.Clear();
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
