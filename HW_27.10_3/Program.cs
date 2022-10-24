using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

var books = new List<Book>();
var PublishingHouse_1 = new PublishingHouse(1, "Видавництво старого лева", "Адреса 1");
var PublishingHouse_2 = new PublishingHouse(2, "ГІМНАЗІЯ", "Адреса 2");

var first = new Book("Підручник. Алгебра 8", PublishingHouse_2);
var second = new Book("Щоденник нейрохірурга", PublishingHouse_1);
var third = new Book("Підручник. Алгебра 9", PublishingHouse_2);

books.Add(first);
books.Add(second);
books.Add(third);

var options = new JsonSerializerOptions
{
    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
    WriteIndented = true
};

string path = "/Users/vika/Projects/HW_27.10_3/HW_3.json";
using (FileStream fs = new FileStream(path, FileMode.Create))
{
    await JsonSerializer.SerializeAsync(fs, books, options);
    Console.WriteLine("Записано у файл");

}

public class Book
{
    public Book(string title, PublishingHouse house)
    {
        Title = title;
        PublishingHouse = house;
        PublishingHouseId = house.Id;
    }
    public int PublishingHouseId { get; set; }
    [JsonPropertyName("Name")]
    public string Title { get; set; }
    public PublishingHouse PublishingHouse { get; set; }
}

public class PublishingHouse
{
    public PublishingHouse(int id, string name, string adress)
    {
        Id = id;
        Name = name;
        Adress = adress;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }
}