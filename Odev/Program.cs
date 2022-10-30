using Newtonsoft.Json;
using Odev;


//User'ları txt dosyasından çek, json olarak oku, list<user>'ın içine at ve oluşturduğun userları repository'nin içine ver
var users = new List<User>();
string _filePath = @"C:\Users\asuspc\Desktop\dosyaTest1.txt";
int departmentInt = 0;
var jsonText = File.ReadAllText(_filePath);
var users2 = JsonConvert.DeserializeObject<List<User>>(jsonText);
if (users2 != null)
{
    users = users2;
}

//------------------------------------------


var repository = new Repository(users); // Userı repositoryi
var controller = new Controller(repository);

while (true)
{
    Console.Write("Bir komut giriniz    :");
    string? input = Console.ReadLine(); //gelen cevabı oku
    List<string> inputParts = new List<string>();
    
    if (input == null)
    {
        Console.WriteLine("Boş giriş yapmamalısınız. ");
        continue; //boş girdiyse uyarı ver, continue
    }
    else if (input == "exit")
    {
        Console.WriteLine("exit yazdığınız için program kapatılıyor.");
        break;
    }
    else //dolu girdiyse parçala
    {
        inputParts = input.Split(' ').ToList(); 
    }

    try //ilk kelime search, get, add kelimelerinden biri değilse uyarı ver, continue
    {
        if (inputParts[0] != "add" || inputParts[0] !="search" || inputParts[0] !="get"|| inputParts[0] !="exit")
        {
            Console.WriteLine($"ilk girilen değer search, get, add veya exit kelimelerinden biri olmalıdır.");
            continue;
        }
       
    }
    catch (Exception e)
    {
        Console.WriteLine($"ilk girilen değer search, get, add veya exit kelimelerinden biri olmalıdır.");
        continue;
    }


    // ilk kelimeye göre;

    if (inputParts[0]== "add") //"ilk kelime eşitse add"
    {
       controller.AddUser(inputParts);
    }
    else if(inputParts[0] == "get")
    {
        controller.GetUser()
    }
    else if (inputParts[0] == "search")
    {
        controller.Search( inputParts.Count == 5 ? inputParts[1] : inputParts[1] + " " + inputParts[2]);
    }

    //Bu şekilde tüm methodlarını oluştur.
}