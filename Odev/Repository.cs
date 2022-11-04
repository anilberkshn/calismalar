using Newtonsoft.Json;

namespace Odev;

public class Repository
{
    private List<User> _users;
    private string _filePath;       //= @"C:\Users\asuspc\Desktop\dosyaTest1.txt";

    public Repository(List<User> users, string filePath)
    {
        _users = users;
        _filePath = filePath;
    }


    // public void LoadDb(List<User> users)
    // {
    //     var jsonText = File.ReadAllText(_filePath);
    //     var users2 = JsonConvert.DeserializeObject<List<User>>(jsonText);
    //     if (users2 != null)
    //     {
    //         users = users2;
    //     }
    // }

    public void SaveDb()
    {
        var jsonText = JsonConvert.SerializeObject(_users, Formatting.Indented);
        File.WriteAllText(_filePath, jsonText);
    }
    
    public void Insert(User user)
    { 
        _users.Add(user);
    }
    
    public User? GetById(string id)
    {

        return _users.FirstOrDefault(x => x.Id == id);
    }
    
    public List<User> SearchByName(string keyword)
    {
        return _users.Where(x=> x.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
        //keyworde göre arama yap, elde ettiğin sonuçları dön
         
    }
    
    public List<User> GetAll()
    {
        return _users;
    }
}