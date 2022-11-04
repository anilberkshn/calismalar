using Newtonsoft.Json;

namespace Odev;

public class User
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Department { get; set; }
    public bool Admin { get; set; }

    public string PrintUser()
    {
        return  JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
