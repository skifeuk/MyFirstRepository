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
        string Name = StringInput("Введите своё имя:");
        string LastName = StringInput("Введите свою фамилию:");
        int Age = IntInput("Введите свой возраст:");
        
        int NumOfPets = IntInput("Сколько у Вас питомцев?");        
        string[] Pets = new string[NumOfPets];
        for (int i = 0; i < NumOfPets; i++)
        {
            Pets[i] = StringInput("Введите имя питомца " + (i + 1));
        }
                
        int NumOfColors = IntInput("Сколько у Вас любимых цветов?");        
        string[] Colors = new string[NumOfColors];
        for (int i = 0; i < NumOfColors; i++)
        {            
            Colors[i] = StringInput("Введите любимый цвет " + (i + 1));
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
        while (iscorrect);

        string input = tempinput;

        return (input);
    }
}
