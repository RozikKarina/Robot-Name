using System;
using System.Collections.Generic;
using System.Text;

public class Robot
{
    private static HashSet<string> usedNames = new HashSet<string>();
    private static Random random = new Random();

    private string name;
    public string Name
    {
        get
        {
            if (name == null)
            {
                name = GenerateUniqueName();
            }
            return name;
        }
    }

    public void Reset()
    {
        // Видаляємо старе ім'я зі списку імен, щоб його можна було використовувати повторно
        usedNames.Remove(name);
        // Генеруємо нове ім'я
        name = GenerateUniqueName();
    }

    private static string GenerateUniqueName()
    {
        string newName;
        do
        {
            newName = GenerateName();
        } while (!usedNames.Add(newName)); // Повторюємо, поки не знайдемо унікальне ім'я
        return newName;
    }

    private static string GenerateName()
    {
        var sb = new StringBuilder();
        // Генеруємо дві випадкові великі літери
        sb.Append((char)('A' + random.Next(0, 26)));
        sb.Append((char)('A' + random.Next(0, 26)));
        // Генеруємо три випадкові цифри
        sb.Append(random.Next(0, 10));
        sb.Append(random.Next(0, 10));
        sb.Append(random.Next(0, 10));
        return sb.ToString();
    }
}
