public class Helper
{
    public static void DrawTable(List<Book> books)
    {
        string rowFormat = "| {0, -20} | {1, -20} | {2, -20} | {3, -20} | {4, -20} | {5, -20} |";
        string divider = "+" + new string('-', 137) + "+";
        Console.WriteLine(divider);
        Console.WriteLine(
            string.Format(
                rowFormat,
                "Title",
                "Author",
                "ISBN",
                "Copy Count",
                "Loaned Copy Count",
                "Available Copy Count"
            )
        );
        Console.WriteLine(divider);

        foreach (Book book in books)
        {
            Console.WriteLine(
                string.Format(
                    rowFormat,
                    book.Title.Length > 20 ? book.Title.Substring(0, 20) : book.Title,
                    book.Author.Length > 20 ? book.Author.Substring(0, 20) : book.Author,
                    book.Isbn.Length > 20 ? book.Isbn.Substring(0, 20) : book.Isbn,
                    book.CopyCount,
                    book.DueDates.Count,
                    book.AvailableCount()
                )
            );
            Console.WriteLine(divider);
        }
    }
}
