using Newtonsoft.Json;
using Odev;
//System.IndexOutOfRangeException: "get"
////getall yazdığımızda uyarı vermedi.
/// departman yerine her hangi bir sayı girilebiliryo
//System.FormatException:  boolın değerde 
//get  boşluk yazınca boş satır döndü.

var filePath = @"C:\Users\asuspc\Desktop\dosyaTest1.txt";
var users = new List<User>();

var jsonText = File.ReadAllText(filePath);
     var users2 = JsonConvert.DeserializeObject<List<User>>(jsonText);
     if (users2 != null)
     {
         users = users2;
     }

var repository = new Repository(users,filePath);
var controller = new Controller(repository);

while (true)
{
    try
    {
        Console.Write("Bir komut giriniz: ");
        var input = Console.ReadLine();

        if (input == null)
        {
            continue;
        }

        if (input.Equals("Exit", StringComparison.OrdinalIgnoreCase))
        {
            break;
        }

        var inputParts = input.Split(" ");

        if (inputParts[0].Equals("get", StringComparison.OrdinalIgnoreCase))
        {
            if (inputParts[1].Equals("all", StringComparison.OrdinalIgnoreCase))
            {
                // controllerin getall metotu
                var response = controller.GetAll();
                foreach (var user in response)
                {
                    Console.WriteLine(user.PrintUser());
                }

            }

            var userControl = controller.GetUser(inputParts);
            if (userControl == null)
            {
                Console.WriteLine("Kullanıcı bulunamadı. ");
                continue;
            }

            //controllerin getbyID 
            Console.WriteLine(userControl.PrintUser());
            continue;
        }

        if (inputParts[0].Equals("add", StringComparison.OrdinalIgnoreCase))
        {
            // controllerın add metotu
            Console.WriteLine("Oluşturulan kayıt id'si: " + controller.AddUser(inputParts));
            continue;
        }

        if (inputParts[0].Equals("search", StringComparison.OrdinalIgnoreCase))
        {
            // Controller search metot.
            var response = controller.Search(inputParts);
            foreach (var user in response)
            {
                Console.WriteLine(user.PrintUser());
            }
            continue;
        }

        Console.WriteLine("Bilinmeyen komut. ");

    }
    catch (IndexOutOfRangeException e)
    {
        Console.WriteLine("Girdiğiniz değerler eksik.");
        continue;
    }
    catch (FormatException)
    {
        Console.WriteLine("Girdiğiniz değerler hatalı. ");
        continue;
    }
    catch (UnknownDepartmentException)
    {
        Console.WriteLine("Bilinmeyen department değeri girildi.");
    }
}


