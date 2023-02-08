using Newtonsoft.Json;
class Program : rezult
{
    public static string path = Directory.GetCurrentDirectory();
    static void Main()
    {
        if (Directory.Exists("результаты") == false)
        {
            Directory.CreateDirectory(path + "/результаты");
        }
        if (File.Exists("результаты\\текст.json") == false)
        {
            FileInfo fi = new FileInfo(path + "/результаты" + "/текст.json");
            FileStream fs = fi.Create();
            fs.Close();
        }
        myusers = JsonConvert.DeserializeObject<List<rezult>>(File.ReadAllText("результаты\\текст.json")) ?? new List<rezult>();
        while (true)
        {
            text();
        }
    }
}
class rezult : maining
{
    public string user;
    public string min;
    public string sec;
}
class maining
{
    protected static int a = 1;
    protected static int time;
    protected static List<rezult> myusers;
    public static string name;
    public static void text()
    {
        File.WriteAllText("результаты\\текст.json", JsonConvert.SerializeObject(myusers));
        ConsoleKeyInfo c;
        do
        {
            Console.Clear();
            Console.WriteLine("Список результатов");
            foreach (rezult a in myusers)
            {
                Console.WriteLine($"{a.user}\n{a.min}\n{a.sec}\n");
            }
            Console.WriteLine("+ - добавить результат");
            c = Console.ReadKey();
            a = 1;
            time = 0;
        } while (c.Key != ConsoleKey.Add);
        tp_na_regu();
    }
    static void tp_na_regu()
    {
        Console.Clear();
        Console.WriteLine("Введите имя: ");
        name = Console.ReadLine();
        tp_na_text();
    }
    static void tp_na_text()
    {
        string txt = "какой-то текст";
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"{txt}\n\nНачать - Enter");
            ConsoleKeyInfo k = Console.ReadKey();
            if (k.Key == ConsoleKey.Enter)
                break;
        }
        Console.Clear();
        Console.WriteLine(txt);
        Thread pot = new Thread(potok);
        pot.Start();
        int h = 0;
        do
        {
            char hh = Console.ReadKey(true).KeyChar;
            if (hh == txt[h])
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(h, 0);
                Console.Write(hh);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(h, 0);
                Console.Write(hh);
                h--;
            }
            h++;
            if (h == txt.Length)
                a = 0;
        } while (a != 0);
        Console.ResetColor();
        rezult w = new rezult();
        w.user = name;
        w.min = $"Результат в минуту : {(float)h * 60 / time}";
        w.sec = $"Результат в секунду: {(double)h / time}";
        myusers.Add(w);
    }
    static void potok()
    {
        for (int i = 60; i > -1; i--)
        {
            Console.ResetColor();
            if (i == 60)
            {
                Console.SetCursorPosition(0, 4);
                Console.WriteLine("1:00");
            }
            else
            {
                Console.SetCursorPosition(0, 4);
                Console.WriteLine("0:" + i);
            }
            time++;
            Thread.Sleep(1000);
            Console.SetCursorPosition(0, 4);
            Console.WriteLine("      ");
            if (a == 0)
                break;
        }
    }
}