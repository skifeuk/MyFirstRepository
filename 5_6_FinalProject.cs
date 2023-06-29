using System;

class Program
{
    public static void Main(string[] args)
    {
        (string Name, string LastName, int Age, string[] Pets, string[] Colors) Person = DataInput();
        
        DataOutput(Person.Name, Person.LastName, Person.Age, Person.Pets, Person.Colors);
    }



    static (string Name, string LastName, int Age, string[] Pets, string[] Colors) DataInput()
    {
        Console.WriteLine("Введите своё имя:");
        string Name = StringInput();

        Console.WriteLine("Введите свою фамилию:");
        string LastName = StringInput();

        Console.WriteLine("Введите свой возраст:");
        int Age = IntInput();

        Console.WriteLine("Сколько у Вас питомцев?");
        int NumOfPets = IntInput();
        
        string[] Pets = new string[NumOfPets];
        for (int i = 0; i < NumOfPets; i++)
        {
            Console.WriteLine("Введите имя питомца {0}:", i + 1);
            Pets[i] = StringInput();
        }

        Console.WriteLine("Сколько у Вас юбимых цветов?");
        int NumOfColors = IntInput();
        
        string[] Colors = new string[NumOfColors];
        for (int i = 0; i < NumOfColors; i++)
        {
            Console.WriteLine("Введите люимый цвет {0}:", i + 1);
            Colors[i] = StringInput();
        }

        return (Name, LastName, Age, Pets, Colors);
    }
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

    static int IntInput()
    {
        bool iscorrect;
        int input;
        do
        {            
            iscorrect = int.TryParse(Console.ReadLine(), out input);
            if (!iscorrect)
            {
                Console.WriteLine("Ошибка. Введите число больше нуля:");
            }
        }
        while (!iscorrect && input <= 0);
        return (input);
    }

    static string StringInput()
    {
        bool iscorrect;
        string tempinput;
        int temp;
        do
        {            
            tempinput = Console.ReadLine();
            iscorrect = int.TryParse(tempinput, out temp);
            if (iscorrect)
            {
                Console.WriteLine("Ошибка. Цифры не допускаются. Повторите ввод:");
            }
        }
        while (iscorrect);

        string input = tempinput;

        return (input);
    }
}
