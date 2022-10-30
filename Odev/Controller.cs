namespace Odev;

public class Controller
{
    private readonly Repository _repository;

    public Controller(Repository repository)
    {
        _repository = repository;
    }

    public User GetUser(string[] parts)
    {
        //partların içinden id'yi çek ve aşağıdaki methoda yolla
        return _repository.GetById("Buraya Id gelecek");
    }
    
    
    
    public List<User> Search(string keyword)
    {
        return _repository.SearchByName(keyword);
    }

    public List<User> GetAll()
    {
        return _repository.GetAll();
    }
    
    public string AddUser(List<string> parts)
    {
        try
        {
        
            departmentInt = inputParts.Count == 5 ? int.Parse(inputParts[3]) : int.Parse(inputParts[4]);
            if (departmentInt != 1 && departmentInt != 2 )
            {
                Console.WriteLine("Sayı 1 veya 2 olmalı");
                continue;
            }
            
        }
        catch (Exception)
        {
            Console.WriteLine("Girilen değer sayı olmalı ve Yanlızca  1 veya 2 girebilirsiniz");
            continue;
        }
        var id = controller.AddUser(new User()
        {
            Admin = inputParts.Count == 5 ?  Convert.ToBoolean(inputParts[4]) : Convert.ToBoolean(inputParts[5]),
            Department = departmentInt,  
            Surname = inputParts.Count == 5 ? inputParts[2] : inputParts[3],
            Name = inputParts.Count == 5 ? inputParts[1] : inputParts[1] + " " + inputParts[2],
            Id =  Guid.NewGuid().ToString() 
        });
        
        Console.WriteLine("id: " + id);
        //parts dizisindeki verilere göre bir user oluştur ve bu userı insert methoduna gönder
         _repository.Insert(new User());
         return "yeni userın idsi";
    }
}