using System.Text.Json;
using System.Text.RegularExpressions;

public class LibraryManager
{
    List<Book> books = new List<Book>();

    public void Load(string path)
    {
        Console.WriteLine("\nVeriler yükleniyor.");
        string fileContent = File.ReadAllText(path);
        books = JsonSerializer.Deserialize<List<Book>>(fileContent) ?? [];
        Console.WriteLine("\nVeriler yüklendi. Menü açılıyor...");
        Thread.Sleep(1500);
    }

    public bool Save(string path)
    {
        Console.Clear();
        Console.WriteLine("\naVeriler kaydediliyor.");
        string content = JsonSerializer.Serialize(books);
        File.WriteAllText(path, content);
        Console.WriteLine("Veriler kaydedildi.");
        return false;
    }

    public bool AddBookAction()
    {
        Console.Clear();
        Book newBook = new Book();

        string validationRegex = "^[\\s\\S]{2,20}$";
        Console.WriteLine("(En az 2 en fazla 20 karakter olmalıdır. Sadece harf içermelidir.)");
        while (true)
        {
            Console.Write("Kitap adı giriniz: ");
            string title = Console.ReadLine() ?? "";
            if (!Regex.IsMatch(title, validationRegex))
            {
                Console.WriteLine("Girilen değer uygun değil tekrar deneyiniz.");
                continue;
            }

            newBook.Title = title;
            break;
        }

        Console.WriteLine("(En az 2 en fazla 20 karakter olmalıdır. Sadece harf içermelidir.)");
        while (true)
        {
            Console.Write("Yazar adı giriniz: ");
            string author = Console.ReadLine() ?? "";
            if (!Regex.IsMatch(author, validationRegex))
            {
                Console.WriteLine("Girilen değer uygun değil tekrar deneyiniz.");
                continue;
            }

            newBook.Author = author;
            break;
        }

        string isbnValidationRegex = "^\\d{5}$";
        Console.WriteLine("(5 karakter olmalıdır. Sadece sayı içermelidir.)");
        while (true)
        {
            Console.Write("ISBN numarası giriniz: ");
            string isbn = Console.ReadLine() ?? "";
            if (!Regex.IsMatch(isbn, isbnValidationRegex))
            {
                Console.WriteLine("Girilen değer uygun değil tekrar deneyiniz.");
                continue;
            }

            newBook.Isbn = isbn;
            break;
        }

        string countValidationRegexx = "^([1-9]|[1-8][0-9]|99)$";
        Console.WriteLine("(1-99 arasında bir sayı girilmelidir.)");
        while (true)
        {
            Console.Write("Kopya sayısı giriniz: ");
            string copyCount = Console.ReadLine() ?? "";
            if (!Regex.IsMatch(copyCount, countValidationRegexx))
            {
                Console.WriteLine("Girilen değer uygun değil tekrar deneyiniz.");
                continue;
            }

            newBook.CopyCount = Convert.ToInt32(copyCount);
            break;
        }

        books.Add(newBook);

        Console.WriteLine("\nBaşarı ile eklendi!");
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
                findedBook.DueDates.Add(DateTime.Now.AddDays(new Random().Next(-10, 10)));
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
