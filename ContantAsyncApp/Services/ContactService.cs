using System.Text.Json;
using ContactAsyncApp.Models;

namespace ContactAsyncApp.Services;

public class ContactService
{
    private readonly List<Contact> _contacts;
    public readonly string FilePath;

    private ContactService()
    {
        _contacts = new List<Contact>();
        FilePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../../../Data.txt"));
    }

    public static async Task<ContactService> Create()
    {
        var contactService = new ContactService();
        await contactService.GetFile();
        return contactService;
    }

    public void IfFileExists()
    {
        if (!File.Exists(FilePath)) File.Create(FilePath);
    }

    public async Task GetFile()
    {
        IfFileExists();

        var lines = await File.ReadAllLinesAsync(FilePath);

        _contacts.Clear();

        foreach (var line in lines)
            if (!string.IsNullOrEmpty(line))
                try
                {
                    var contactLine = JsonSerializer.Deserialize<Contact>(line);
                    _contacts.Add(contactLine);
                }
                catch (JsonException e)
                {
                    Console.WriteLine(e);
                    throw new Exception($"Deserialization failure: {e.Message}");
                }
    }

    public async Task Add(Contact contact)
    {
        try
        {
            _contacts.Add(contact);

            var json = JsonSerializer.Serialize(contact);


            using (var writer = new StreamWriter(FilePath))
            {
                await writer.WriteAsync(json);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception($"Adding failure: {e.Message}");
        }
    }

    public async void ClearAll()
    {
        using (var stream = new FileStream(FilePath, FileMode.Open))
        {
            stream.SetLength(0);
        }
    }

    public async void Print()
    {
        foreach (var contact in _contacts) Console.Write(contact.ToString());
    }

    public async Task<Contact?> Search(string value)
    {
        return await Task.Run(() =>
        {
            return _contacts.FirstOrDefault(contact =>
                contact.Id == value ||
                contact.Name == value ||
                contact.Surname == value ||
                contact.TelephoneNumber == value
            );
        });
    }
}