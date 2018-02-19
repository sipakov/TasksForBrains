using System;

namespace FibonacciNumbers
{
    class Program
    {
        static double Fibo(int number = 0, int numberFibo = 0)
        {
            double result = 0;
            if (number != 0 && numberFibo==0)
            {
                //формула Бине. До 71 элемента считает быстрее цикла и без погрешности.
                if (number <= 70)
                {
                    double num = 5;
                    double pow = 0.5;
                    double sqrtFive = Math.Pow(num, pow);

                    result = (Math.Pow(((1 + sqrtFive) / 2), number) - Math.Pow(((1 - sqrtFive) / 2), number)) / sqrtFive;
                }
                else
                {
                    //Рекурсию не используем, так как сложность алгоритма станет 2^n. Здесь O(n) 
                    double one = 1;
                    double two = 1;
                    double three = one + two;
                    double count = 3;
                    while (count<number)
                    {
                        one = two;
                        two = three;
                        //проверка на переполнение
                        if (two>double.MaxValue)
                        {
                            return -1;
                        }
                        three = one + two;
                        count++;
                       

                    }
                    return three;
                }
            }
            if (number == 0 && numberFibo != 0)
            {
                double one = 1;
                double two = 1;
                double three = one + two;
                double counter = 3;
                while (three<numberFibo)
                {
                    one = two;
                    two = three;
                    three = one + two;
                    counter++;
                }
                return counter;               
            }
            //проверки
            if (number != 0 && numberFibo != 0)
            {
                return -1;
            }
            if (number == 0 && numberFibo == 0)
            {
                return -1;
            }

            return result;
        }

        static void Main(string[] args)
        {
            double result = Fibo();

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
