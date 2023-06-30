using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    public static void Main(string[] args)
    {
        
        (string Name, string LastName, int Age, string[] Pets, string[] Colors) Person = DataInput();
        
        DataOutput(Person.Name, Person.LastName, Person.Age, Person.Pets, Person.Colors);
    }


    //Метод собирает информацию о пользователе и возвращает Имя, Фамилию, Возраст, Имена питомцев (массивом) и Любимые цета (массивом)
    static (string Name, string LastName, int Age, string[] Pets, string[] Colors) DataInput()
    {        
        
        string Name = StringInput("Введите своё имя:");
        
        string LastName = StringInput("Введите свою фамилию:");
        
        int Age = IntInput("Введите свой возраст:");

        string[] Pets = HavePets();
                
        int NumOfColors = IntInput("Сколько у Вас любимых цветов?");        
        string[] Colors = new string[NumOfColors];
        for (int i = 0; i < NumOfColors; i++)
        {            
            Colors[i] = StringInput("Введите любимый цвет " + (i + 1));
        }

        return (Name, LastName, Age, Pets, Colors);
    }

    //Метод принимает на вход собранную информацию о пользователе и выводит её в консоль
    static void DataOutput(string Name, string LastName, int Age, string[] Pets, string[] Colors)
    {
        Console.WriteLine("Ваши имя и фамилия: {0} {1}", Name, LastName);
        Console.WriteLine("Ваш возраст: {0}", Age);
        
        Console.WriteLine("Ваших питомцев зовут:");
        foreach(var name in Pets)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("Ваши любимые цвета:");
        foreach (var color in Colors)
        {
            Console.WriteLine(color);
        }

    }

    //Метод проверяет что введено число и оно больше нуля. Иначе просит повторить ввод.
    static int IntInput(string text)
    {
        bool iscorrect;
        int input;
        do
        {
            Console.WriteLine(text);
            iscorrect = int.TryParse(Console.ReadLine(), out input);
        }
        while (!iscorrect && input <= 0);
        return (input);
    }

    //Метод проверяет что введенная строка не пустая, не начинается с пробела или цифры. Иначе просит повторить ввод.
    static string StringInput(string text)
    {
        bool iscorrect;        
        string tempinput;
        int temp;
        do
        {
            Console.WriteLine(text);
            tempinput = Console.ReadLine();
            iscorrect = int.TryParse(tempinput, out temp);            
        }
        while (iscorrect || string.IsNullOrWhiteSpace(tempinput));

        string input = tempinput;

        return (input);
    }

    //Метод спрашивает есть ли питомцы ("да"/"нет"). Возвращает имена питомцев, если "да", или заготовленный текст, если "нет", в виде массива строк. Если ввод отличается от "да" или "нет" - просит повторить ввод. Если "да" - спрашивает количество питомцев и их имена. Если "нет" - выводит заготовленный текст.
    static string[] HavePets()
    {
        repeat:
        string HavePets = StringInput("Есть ли у Вас питомцы? (да/нет):");        
        if (HavePets is "да")
        {
            int NumOfPets = IntInput("Сколько у Вас питомцев?");
            string[] Pets = new string[NumOfPets];
            for (int i = 0; i < NumOfPets; i++)
            {
                Pets[i] = StringInput("Введите имя питомца " + (i + 1));
            }

            return Pets;
        }
        else if (HavePets is "нет")
        {
            string[] Pets = new string[] { "У Вас нет питомцев :`(" };
            return Pets;
        }
        else
        {
            goto repeat;
        }
    }
}
