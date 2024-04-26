
using System.IO;
using System.Runtime;
using System.Text.Json;
using System.Text.Json.Serialization;

abstract class Task
{
    protected string text = "";
    public string Text
    {
        get => text;
        protected set => text = value;
    }
    public Task(string text)
    {
        this.text = text;
    }
}

class JsonIO
{
    public static void Write<T>(T obj, string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(fs, obj); 
        }
    }

    public static T Read<T>(string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            return JsonSerializer.Deserialize<T>(fs)!; 
        }
    }
}

class Task2 : Task
{
    private char[] commonLetters;

    public char[] CommonLetters
    {
        get => commonLetters;
    }

    public Task2(string text) : base(text)
    {
        this.text = text;
        var words = text.Split();

        var word1Set = new HashSet<char>();
        var word2Set = new HashSet<char>();

        foreach (char c in words[0])
            word1Set.Add(c);
        foreach (char c in words[1])
            word2Set.Add(c);

        commonLetters = word1Set.Intersect(word2Set).ToArray();
    }

    [JsonConstructor]
    public Task2(string text, char[] commonLetters) : base(text)
    {
        this.commonLetters = commonLetters;
    }

    public override string ToString() => new string(commonLetters);
}

class Task1 : Task
{
    private double average;

    public Task1(string text) : base(text)
    {
        var words = text.Split();

        double sum = 0;
        int count = 0;

        foreach (var word in words)
        {
            double num = double.NaN;
            if (double.TryParse(word, out num))
            {
                sum += num;
                count++;
            }
        }

        average = sum / (double)count;
    }

    [JsonConstructor]
    public Task1(string text, double average) : base(text)
    {
        this.average = average;
    }

    public override string ToString() => average.ToString();
}

class Program()
{
    static void Main(string[] args)
    {
        string userName = "maga";
        string folder = @"C:\Users\" + userName + @"\Documents\Test\";

        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        Task[] tasks =
        {
            new Task1("1 50 -8 4"),
            new Task2("kool basket"),
        };

        Console.WriteLine(tasks[0]);
        Console.WriteLine(tasks[1]);

        string task1File = folder + "Task1.json";
        string task2File = folder + "Task2.json";

        if (!File.Exists(task1File))
            JsonIO.Write((Task1)tasks[0], task1File);
        else
        {
            var t1 = JsonIO.Read<Task1>(task1File);
            Console.WriteLine(t1);
        }

        if (!File.Exists(task2File))
            JsonIO.Write((Task2)tasks[1], task2File);
        else
        {
            var t2 = JsonIO.Read<Task2>(task2File);
            Console.WriteLine(t2);
        }
    }
}