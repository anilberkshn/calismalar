using Newtonsoft.Json;

namespace Odev;

public class Repository
{
    public List<User> Users;
    
    public Repository(List<User> users)
    {
        Users = users;
    }
    
    public void SaveDb(string _filePath)
    {
        var jsonText = JsonConvert.SerializeObject(Users.ToArray(), Formatting.Indented);
        File.WriteAllText(_filePath, jsonText);
    }
    
    public void Insert(User user)
    {
    }
    
    public User GetById(string id)
    {
        return new User();
    }
    
    public List<User> SearchByName(string keyword)
    {
        return Users.Where(x=> x.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
        //keyworde göre arama yap, elde ettiğin sonuçları dön
         
    }
    
    public List<User> GetAll()
    {
        return Users;
    }
}