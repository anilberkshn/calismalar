namespace Odev;

public class Controller
{
    private readonly Repository _repository;

    public Controller(Repository repository)
    {
        _repository = repository;
    }

    public User? GetUser(string[] parts)
    {
        // get 12232u389rfndsaffkds98u3r41ıj
        //partların içinden id'yi çek ve aşağıdaki methoda yolla
        return _repository.GetById(parts[1]);
    }


    public List<User> Search(string[] parts)
    {
        return _repository.SearchByName(parts[1]);
    }

    public List<User> GetAll()
    {
        return _repository.GetAll();
    }

    public string AddUser(string[] parts)
    {
        var user = new User
        {
            Id = Guid.NewGuid().ToString()
        };

        if (parts.Length == 5)
        {
            user.Admin = Convert.ToBoolean(parts[4]);
            user.Department = int.Parse(parts[3]);
            user.Surname = parts[2];
            user.Name = parts[1];
        }
        else
        {
            user.Admin = Convert.ToBoolean(parts[5]);
            user.Department = int.Parse(parts[4]);
            user.Surname = parts[3];
            user.Name = parts[1] + " " + parts[2];
        }

        if (user.Department is not ( 1 or 2))
        {
            throw new UnknownDepartmentException();
        }

        _repository.Insert(user);
        _repository.SaveDb();
        return user.Id;
    }
}