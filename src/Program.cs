LibraryManager libraryManager = new LibraryManager();

List<ConsoleKey> validActionList = new List<ConsoleKey>()
{
    ConsoleKey.D1,
    ConsoleKey.D2,
    ConsoleKey.D3,
    ConsoleKey.D4,
    ConsoleKey.D5,
    ConsoleKey.D6,
    ConsoleKey.Escape
};

while (true)
{
    Draw();
    if (!Action())
        break;
}

void Draw()
{
    Console.Clear();
    Console.WriteLine("+-------------------------------+");
    Console.WriteLine("|            İşlemler           |");
    Console.WriteLine("+-------------------------------+");
    Console.WriteLine("|  1  | Kitap Ekle              |");
    Console.WriteLine("+-------------------------------+");
    Console.WriteLine("|  2  | Kitapları Listele       |");
    Console.WriteLine("+-------------------------------+");
    Console.WriteLine("|  3  | Kitap Ara               |");
    Console.WriteLine("+-------------------------------+");
    Console.WriteLine("|  4  | Kitap Ödünç Al          |");
    Console.WriteLine("+-------------------------------+");
    Console.WriteLine("|  5  | Kitap İade Et           |");
    Console.WriteLine("+-------------------------------+");
    Console.WriteLine("|  6  | Süresi Geçmişleri Getir |");
    Console.WriteLine("+-------------------------------+");
    Console.WriteLine("| ESC | Kaydet ve Çık           |");
    Console.WriteLine("+-------------------------------+");
}

bool Action()
{
    switch (GetValidInput())
    {
        case ConsoleKey.D1:
            return libraryManager.AddBookAction();
        case ConsoleKey.D2:
            return libraryManager.ListBookAction();
        case ConsoleKey.D3:
            return libraryManager.SearchBookAction();
        case ConsoleKey.D4:
            return libraryManager.LoanBookAction();
        case ConsoleKey.D5:
            return libraryManager.ReturnBookAction();
        case ConsoleKey.D6:
            return libraryManager.ExpiredBooksAction();
        case ConsoleKey.Escape:
            return libraryManager.Save();
        default:
            return false;
    }
}

ConsoleKey GetValidInput()
{
    do
    {
        Console.Write("\nİşlem seçiniz: ");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        if (validActionList.Contains<ConsoleKey>(keyInfo.Key))
            return keyInfo.Key;
        Console.Write("\nGeçersiz işlem. Tekrar deneyiniz.");
    } while (true);
}
