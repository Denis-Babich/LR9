using System;

class Rectangle
{
    // Поля класса
    private int a;
    private int b;

    // Конструктор класса для создания прямоугольника с заданными длинами сторон
    public Rectangle(int sideA, int sideB)
    {
        a = sideA;
        b = sideB;
    }

    // Вывод длин сторон прямоугольника
    public void DisplaySides()
    {
        Console.WriteLine($"Длина a: {a}, Длина b: {b}");
    }

    // Расчета периметра прямоугольника
    public int CalculatePerimeter()
    {
        return 2 * (a + b);
    }

    // Расчета площади прямоугольника
    public int CalculateArea()
    {
        return a * b;
    }

    // Получение и установка длин сторон прямоугольника
    public int[] Sides
    {
        get { return new int[] { a, b }; }
        set
        {
            if (value.Length == 2)
            {
                a = value[0];
                b = value[1];
            }
            else
            {
                Console.WriteLine("Ошибка");
            }
        }
    }

    public bool IsSquare
    {
        get { return a == b; }
    }

    // Индексатор для доступа к полям a и b по индексам 0 и 1
    public int this[int index]
    {
        get
        {
            if (index == 0) return a;
            else if (index == 1) return b;
            else
            {
                Console.WriteLine("Ошибка");
                return -1; 
            }
        }
        set
        {
            if (index == 0) a = value;
            else if (index == 1) b = value;
            else
            {
                Console.WriteLine("Ошибка");
            }
        }
    }

    // ++ (увеличение длин сторон)
    public static Rectangle operator ++(Rectangle rectangle)
    {
        rectangle.a++;
        rectangle.b++;
        return rectangle;
    }

    // -- (уменьшение длин сторон)
    public static Rectangle operator --(Rectangle rectangle)
    {
        if (rectangle.a > 0 && rectangle.b > 0)
        {
            rectangle.a--;
            rectangle.b--;
        }
        return rectangle;
    }

    // Проверка, является ли прямоугольник квадратом
    public static bool operator true(Rectangle rectangle)
    {
        return rectangle.IsSquare;
    }

    public static bool operator false(Rectangle rectangle)
    {
        return !rectangle.IsSquare;
    }

    // * (умножение длин сторон на скаляр)
    public static Rectangle operator *(Rectangle rectangle, int scalar)
    {
        rectangle.a *= scalar;
        rectangle.b *= scalar;
        return rectangle;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите размер a: ");
        int sideA = int.Parse(Console.ReadLine());

        Console.Write("Введите размер b: ");
        int sideB = int.Parse(Console.ReadLine());

        // Создание объекта Rectangle с введенными длинами сторон
        Rectangle myRectangle = new Rectangle(sideA, sideB);

        // Вывод длин сторон
        Console.WriteLine("Стороны прямоугольника :");
        myRectangle.DisplaySides();

        // Расчет и вывод периметра и площади
        Console.WriteLine($"Периметр {myRectangle.CalculatePerimeter()}");
        Console.WriteLine($"Площадь {myRectangle.CalculateArea()}");

        // Изменение длин сторон
        Console.Write("Введите новый размер a: ");
        int newSideA = int.Parse(Console.ReadLine());

        Console.Write("Введите новый размер b: ");
        int newSideB = int.Parse(Console.ReadLine());

        myRectangle.Sides = new int[] { newSideA, newSideB };

        // Проверка, является ли прямоугольник квадратом
        if (myRectangle)
        {
            Console.WriteLine("Прямоугольник - это квадарат.");
        }
        else
        {
            Console.WriteLine("Прямоугольник - это не квадрат.");
        }

        // Увеличение длин сторон с использованием оператора ++
           myRectangle++;
           myRectangle.DisplaySides();

        // Уменьшение длин сторон с использованием оператора --
        myRectangle--;
        myRectangle.DisplaySides();
        // Умножение длин сторон на скаляр
        Console.Write("Введите скалярное значение : ");
        int scalar = int.Parse(Console.ReadLine());

        myRectangle = myRectangle * scalar;
        myRectangle.DisplaySides();

        // Доступ к полям через индексатор
        Console.WriteLine($"Длина a: {myRectangle[0] + 4}, Длина b: {myRectangle[1] + 6}");

        Console.ReadKey();
    }
}
