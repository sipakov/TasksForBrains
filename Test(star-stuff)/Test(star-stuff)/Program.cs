using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Test_star_stuff_
{
    class Program
    {
        static  void Main(string[] args)
        {
            CompilerBoxed compilerBoxed = new CompilerBoxed();
            //Эта конструкция имитирует запуск 
            //метода повторно, когда предыдущая запущенная задача еще не выполнилась. 
            for (int i = 0; i < compilerBoxed.listString.Count; i++)           
            {
                compilerBoxed.byteTask(compilerBoxed.listString.ElementAt(i));
            }
            //Это имитация и демонстрация работы основного потока.            
            for (int i = 0; i < 16; i++)
            {
                Console.WriteLine("FrontStreem. Stream ID {0}", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(500);              
            }
            compilerBoxed.Show();
            Console.ReadLine();
        }
        
    }
    public class Compiler
    {
        //Класс Compiler немного модифицировал исключительно в демонстрационных целях.
        //Иначе, кроме кода тестовой демонстрации не получится.
        public byte[] BuildProject(string projectPath)
        {
            //Имитация деятельности
            char[] filePath = new char[5];
            for (byte i = 0; i < 5; i++)
            {
                filePath[i] = '1';
                //Вывод потока в котором выполняется метод и 
                //демонстрация того, что он выполняется в фоновом потоке
                Console.WriteLine("BackgroundStream. Stram ID {0}", Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(500);
            } 
            return Encoding.UTF8.GetBytes(filePath);
        }
    }
    class CompilerBoxed
    {
        //Класс CompilerBoxed также содержит лишние элементы,
        //предназначенные для демонстрации
        Compiler compiler;
        static object locker = new object();
        byte[] bytesArray { get; set; }
        List<byte[]> list { get; set; }
        //Я не стал создавать систему ввода-вывода информации и имитацию запуска метода сборки, так 
        //как не совсем понял нужно ли её было делать и на 
        //это ушло бы больше времени. С ходу не получилось это реализовать,
        //поэтому ограничился элементарными действиями. Этот список моделирует какую-то очередь из путей к сборкам.
        //Все результаты сохраняются в list. 
        public List<string> listString = new List<string>() { "path1", "path2", "path3" };
        public CompilerBoxed()
        {
            compiler = new Compiler();
            list = new List<byte[]>();
        }
        public Task byteTask(string S) => Task.Run(() => {
            //Один из способов реализации синхронизации.
            lock (locker)
            {
                bytesArray = compiler.BuildProject(S);
                list.Add(bytesArray);             
            }
        });
        //Этот не безопасный к потокам метод просто показывает, что байты сохранены и доступны.
      
        public  void Show()
        {
                Console.WriteLine("Данные доступны");
                int z = 1;
            foreach (var i in list.ElementAt(z))
                {
                    Console.Write(i + " ");
                }                                           
        }
    }
}
