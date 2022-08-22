using System.IO;
using System.Text;

namespace zoo.Models;

public class Zoo
{
  public string Name { get; set; }
  public string Country { get; set; }
  public string Cellphone { get; set; }
  public string Website { get; set; }

  public void saveZoo()
  {
    string content = toString();
    string path = @".\database.txt";
    if (File.Exists(path))
    {
      content += readFile(path);
      File.Delete(path);
    }

    FileStream fileDatabase = File.Create(path);
    fileDatabase.Close();

    writeFile(path, content);
  }

  public static string readFile(string path)
  {
    string contenido = "";
    using (StreamReader objSR = File.OpenText(path))
    {
      string txt = "";
      while ((txt = objSR.ReadLine()) != null)
      {
        contenido += txt + "\n";
      }
    }
    return contenido;
  }

  private void writeFile(string path, string content)
  {
    FileStream myFile = File.Open(path, FileMode.Open);
    Byte[] info = new UTF8Encoding(true).GetBytes(content);
    myFile.Write(info, 0, info.Length);
    myFile.Close();
  }

  public string toString()
  {
    string objInfo = Name + ";";
    objInfo += Country + ";";
    objInfo += Cellphone + ";";
    objInfo += Website + "\n";

    return objInfo;
  }
}
