namespace database.Models;
using zoo.Models;

public class Database
{
  public List<Zoo> zoos { get; set; }

  public Database()
  {
    zoos = new List<Zoo>();
    string path = ".\\database.txt";
    using (StreamReader objSR = File.OpenText(path))
    {
      string txt = "";
      while ((txt = objSR.ReadLine()) != null)
      {
        Zoo zoo = new Zoo();
        string[] data = txt.Split(";");

        zoo.Name = data[0];
        zoo.Country = data[1];
        zoo.Cellphone = data[2];
        zoo.Website = data[3];

        zoos.Add(zoo);
      }
    }
  }
}
