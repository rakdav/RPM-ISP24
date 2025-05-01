using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Threading.Channels;
//пример 1
//void Hello() => Console.WriteLine("Hello Голубчиков. Ты в армии?");
//void Display() => Console.WriteLine("Надежда - компос земной. Заблудилась в полюсах.");
//Message mes;//2. Создаем переменную делегата
//mes = Hello;//3. Присваиваем этой переменной адрес метода
//mes();//4. Вызываем метод
//mes = Display;
//mes();
//mes = Welcome.Print;
//mes();
//class Welcome
//{
//    public static void Print() => Console.WriteLine("Welcome");
//}
//delegate void Message();//1. Объявляем делегат

//пример 2
//int Add(int x, int y) => x + y;
//int Sub(int x, int y) => x - y;
//int Mult(int x, int y) => x * y;
//int Div(int x, int y) => x/y;

//Operation operation=Add;
//Console.WriteLine(operation(5,8));
//operation = Sub;
//Console.WriteLine(operation(5, 8));
//Operation operation2 = new Operation(Mult);//присвоение ссылки на метод
//Console.WriteLine(operation2(7,9));
//operation2 = Div;
//Console.WriteLine(operation2.Invoke(6,3));

//delegate int Operation(int x, int y);

//пример 3. Цепочные делегаты.

//void Hello() => Console.WriteLine("Hello");
//void HowAreYou() => Console.WriteLine("How are you?");
//Message message = Hello;
//message += HowAreYou;
//message += Hello;
//message += Hello;
//message();
//Console.WriteLine();
//message -= Hello;
//message -= Hello;
//message -= HowAreYou;
//if(message!=null) message();
//Console.WriteLine();
//Message message2 = HowAreYou;
//Message message3 = message + message2;
//message3();
//delegate void Message();

//пример 4. Обощенные делегаты.
//decimal Square(int n) => n * n;
//int Double(int n) => n + n;
//Operation<decimal, int> squareOperation = Square;
//Console.WriteLine(squareOperation(5));
//Operation<int, int> doubleOperation = Double;
//Console.WriteLine(doubleOperation(3));
//delegate T Operation<T, K>(K val);

//пример 4. Делегаты как параметры методов.
//int Add(int x, int y) => x + y;
//int Sub(int x, int y) => x - y;
//int Mult(int x, int y) => x*y;
//void DoOperation(int a, int b, Operation op)
//{
//    Console.WriteLine(op(a, b));
//}
//Operation SelectOperation(OperationType opType)
//{
//    switch (opType)
//    {
//        case OperationType.Add:return Add;
//        case OperationType.Sub: return Sub;
//        default:return Mult;
//    }
//}
//Console.Write("Введите первую переменную:");
//int x = int.Parse(Console.ReadLine()!);
//Console.Write("Введите вторую переменную:");
//int y = int.Parse(Console.ReadLine()!);
//Console.Write("Введите операцию +,-,*:");
//char op = char.Parse(Console.ReadLine()!);
//Operation operation;
//switch (op)
//{
//    case '+':
//        operation = SelectOperation(OperationType.Add);
//        break;
//    case '-':
//        operation = SelectOperation(OperationType.Sub);
//        break;
//    default:
//        operation = SelectOperation(OperationType.Mult);
//        break;
//}
//Console.WriteLine(operation(x,y));
//enum OperationType
//{
//    Add, Sub, Mult
//}
//delegate int Operation(int x, int y);

//пример 5. Делегаты Action, Predicate и Func.
//Action
//void Add(int x, int y) => Console.WriteLine($"{x}+{y}={x+y}");
//void Sub(int x, int y) => Console.WriteLine($"{x}-{y}={x - y}");
//void Mult(int x, int y) => Console.WriteLine($"{x}*{y}={x * y}");
//void DoOperation(int a, int b, Action<int, int> op) => op(a, b);
//DoOperation(16, 15, Add);
//DoOperation(16, 15, Sub);
//DoOperation(16, 15, Mult);
////Predicate
//Predicate<int> isPositive = (int x) => x > 0;
//Console.WriteLine(isPositive(6));
//Console.WriteLine(isPositive(-3));
////Func
//int Square(int n) => n * n;
//int Double(int n) => n + n;
//int DoOperationFunc(int n, Func<int, int> operation) => operation(n);
//Console.WriteLine(DoOperationFunc(6, Square));
//Console.WriteLine(DoOperationFunc(9, Double));

//пример 6. Анонимные методы.
//MessageHandler handler = delegate (string mes)
//{
//    Console.WriteLine(mes);
//};
//static void ShowMessage(string mes,MessageHandler handler)
//{
//    handler(mes);
//}
//handler("Hello, world!");
//ShowMessage("Hi!",delegate(string mes){
//    Console.WriteLine(mes);
//});
//delegate void MessageHandler(string message);

//пример 7. Лямбды.Лямбда-выражения представляют упрощенную запись анонимных методов
//Message handler = () => Console.WriteLine("Hello!");
//handler();
//handler();
//Message mes = () =>
//{
//    Console.WriteLine("Hello, world!");
//    Console.WriteLine("Hi!");
//};
//mes();
//Operation sum = (x, y) => Console.WriteLine($"{x}+{y}={x + y}");
//sum(12, 67);
//sum(33, 71);
//ShowMessage print = mes => Console.WriteLine(mes);
//print("Hello");
//print("World");
//var welcome = (string mes) => Console.WriteLine(mes);
//welcome("Hello, world!");
//var summa = (int x, int y) => x + y;
//Console.WriteLine(summa(6,9));
//IntOperation op = (x, y) => x * y;
//Console.WriteLine(op(5,9));

//int[] mas = { 1, 5, 2, 8, 6, 9, 3 };
//int Sum(int[] array, Predicate<int> func)
//{
//    int result = 0;
//    foreach (int i in array)
//        if (func(i)) result += i;
//    return result;
//}
//Console.WriteLine(Sum(mas,x=>x%2==0));
//Console.WriteLine(Sum(mas, x => x % 2 != 0));
//Console.WriteLine(Sum(mas, x => x > 0));

//delegate void Operation(int x, int y);
//delegate void Message();
//delegate void ShowMessage(string str);
//delegate int IntOperation(int x, int y);

//пример 8. Замыкания.
//Action Outer()
//{
//    int x = 5;
//    void Inner()
//    {
//        x++;
//        Console.WriteLine(x);
//    }
//    return Inner;
//}
//var outerFn = () =>
//{
//    int x = 10;
//    var innerFn = () => Console.WriteLine(++x);
//    return innerFn;
//};
//var f = Outer();
//f();
//f();
//f();
//var fn = outerFn();
//fn();
//fn();
//fn();
//Func<int, int> fact = null!;
//fact= (int x) => (x > 1) ? x * fact(x - 1) : 1;
//Console.WriteLine(fact(5));
//var mult = (int n) => (int m) => m * n;
//var fmult = mult(5);
//Console.WriteLine(fmult(3));
//Console.WriteLine(fmult(4));
//Console.WriteLine(fmult(6));

//пример 9. События.
void DisplayMessage(Account sender,AccountEventArgs e)
{
    Console.WriteLine($"Сумма транзакций:{e.Sum}");
    Console.WriteLine(e.Message);
    Console.WriteLine($"Текущая сумма на счете:{sender.Sum}");
}
Account account = new Account(100);
account.Notify += DisplayMessage;
account.Put(20);
account.Take(70);
//account.Notify -= DisplayMessage;
account.Take(180);

class AccountEventArgs
{
    public string Message { get; }
    public int Sum { get; }
    public AccountEventArgs(string message, int sum)
    {
        Message = message;
        Sum = sum;
    }
}
class Account
{
    public delegate void AccountHandler(Account sender,AccountEventArgs e);
    public event AccountHandler? Notify;
    public int Sum { get; private set; }
    public Account(int sum) => Sum = sum;
    public void Put(int sum) {
        Sum += sum;
        Notify?.Invoke(this, new AccountEventArgs($"На счет поступило:{sum}",sum));
    }
    public void Take(int sum)
    {
        if (Sum >= sum)
        {
            Sum -= sum;
            Notify?.Invoke(this,new AccountEventArgs($"Cо счета снято:{Sum}",sum));
        }
        else
        {
            Notify?.Invoke(this,new AccountEventArgs($"Недостаточно средств. Баланc:{Sum}",sum));
        }
    }
}

