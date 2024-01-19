public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
    public int CopyCount { get; set; }
    public List<DateTime> DueDates { get; set; }

    public Book()
    {
        Title = "";
        Author = "";
        Isbn = "";
        CopyCount = 0;
        DueDates = new List<DateTime>();
    }

    public int AvailableCount()
    {
        return CopyCount - DueDates.Count;
    }
}
