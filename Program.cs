using System;
using System.Collections.Generic;
using System.Linq;

namespace Индивидуальное_задание_коллекции
{
    class Program
    {
        //метод, чтобы проверить, является ли символ оператором
        static bool Operand(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        //метод для преобразования из постфиксного в инфиксный
        static string PostfiksInInfiks(string postfix)
        {
            var stack = new Stack<String>();

            foreach(var token in postfix.Split(' '))
            {
                if (!string.IsNullOrEmpty(token))
                {
                    if (Operand(token[0]))
                    {
                        //извлекаем два верхних элемента
                        var right = stack.Pop();
                        var left = stack.Pop();

                        //здесь создается инфиксное выражение
                        var expression = $"({left} {token} {right})";
                        stack.Push(expression);
                    }
                    else
                    {
                        //если не оператор, помещаем в стек
                        stack.Push(token);
                    }
                }
            }

            return stack.Pop();
        }
        static void Main(string[] args)
        {
            //постфиксное выражение
            string postfix = "6 5 2 + * 12 4 / -";

            string infix = PostfiksInInfiks(postfix);
            Console.WriteLine("Инфиксное выражение " + infix);
        }
    }
}
