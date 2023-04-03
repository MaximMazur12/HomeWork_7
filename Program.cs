
SquaresDelegate SquaresDelegate = new SquaresDelegate(FindNumbers);  // делегат куди передається метод FindSquares
List<int> result = new List<int>();


Thread[] threads = new Thread[4]; // створив 4 потоки
int range = 100000 / 4; // ділим потоки на 4 порівну
//while (threads.Any(threads => threads.isActive)) ;
List<int> resultThreads = new List<int>(); // буде виводити кінцевий список всих потоків

for (int i = 0; i < 4; i++)
{
    int start = i * range + 1;
    int finish = (i + 1) * range;
    threads[i] = new Thread(() => FindNumbers(start, finish, result));
    threads[i].Start();
}

while (threads.Any(thread => thread.IsAlive));


foreach (var item in resultThreads) 
{
    Console.WriteLine(item);
}


SquaresDelegate(1, 100000, result);

     foreach (var item in result)  // виводить кінцевий список всіх чисел з цілими коренями
      {
         Console.WriteLine(item);
      } 

    static void FindNumbers(int start, int finish, List<int> result)
    {
        for (int i = start; i <= finish; i++)   // цикл біжить від start до finish
        {
            double squareRoot = Math.Sqrt(i);   //Math.Sqrt(i) -  функція яка дає корінь квадратний, squareRoot - тут кожне число(і) отримує квадратний корінь
            if (squareRoot == (int)squareRoot)  // перевіряється якщо число отримує цілий квадратний корінь
            {
                result.Add(i);  // цілий корінь числа додається в list
            }
        }
    }
delegate void SquaresDelegate(int start, int finish, List<int> result); // створюєм сам делегат




