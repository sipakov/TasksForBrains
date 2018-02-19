using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelCards
{
    //Условия задачи не оговаривают количество карточек и то, каким образом поступили данные в приложение.
    //Однако, количество карточек конечно и после поступления данных в приложение оно известно. Для их хранения в неупорядоченном виде есть возможность использовать обычный массив.
    //Задачу можно решить используя различные алгоритмы и структуры данных. Например, можно воспользоваться стеками или решать рекурсивно.
    //В данном случае в качестве возвращаемого типа был выбран связный список и нерекурсивный подход.
    //Массив дает возможность осуществлять поиск по индексу (перебор в данном случае) за константное время O(1).
    //Связный список осуществляет доступ к первому и последнему элементу за O(1). Добавление элемента без его поиска, т.е. 
    //в начало и конец, так же за O(1). Общая оценка скорости алгоритма приведена ниже.
    //Юнит тестированием почти не приходилось заниматься из-за недостаточного количества людей в компании. Надо учиться. Это мне минус. 

    //Карточка путешествия
    class Card
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
    //Класс с методом решения
    class CardsOperations
    {
        public LinkedList<Card> getSortedCards(Card[] unsortedCards)
        {
            LinkedList<Card> sortedCards = new LinkedList<Card>();
            //Пока количество карточек в отсортированном списке не будет равно количеству карточек, которое поступило на вход
            //будет выполняться цикл
            while (unsortedCards.Count() != sortedCards.Count)
            {
                //Выполняется перебор элементов несортированного массива
                for (int i = 0; i < unsortedCards.Count(); i++)
                {
                    //Добавляется первый элемент массива. Не имеет значения
                    //какими свойствами он обладает. К нему слева и справа будут добавляться следующие элементы массива.
                    if (sortedCards.Count == 0)
                    {
                        sortedCards.AddFirst(unsortedCards[i]);
                    }
                    //После проверки на то, что список не пустой
                    else
                    {
                        //Проверяются условия задачи и в случае совпадения добавляются элементы или в начало, или в конец
                        if (sortedCards.Last.Value.To == unsortedCards[i].From)
                        {
                            sortedCards.AddLast(unsortedCards[i]);
                        }
                        if (sortedCards.First.Value.From == unsortedCards[i].To)
                        {
                            sortedCards.AddFirst(unsortedCards[i]);
                        }
                    }
                }
            }
            return sortedCards;
            //Используются два цикла, один из которых вложен в другой. И, в общем, случае
            //сложность равна O(n*n). Но более корректно будет если учесть, что перебор по массиву
            //в нашем случе выполняется A раз и цикл while B раз: O(A*B) 
        }

        class Program
        {
            static void Main(string[] args)
            {
                //Для примера
                Card cardOne = new Card();
                cardOne.Id = 1;
                cardOne.From = "Мельбурн";
                cardOne.To = "Кельн";

                Card cardTwo = new Card();
                cardTwo.Id = 2;
                cardTwo.From = "Кельн";
                cardTwo.To = "Москва";

                Card cardThree = new Card();
                cardThree.Id = 3;
                cardThree.From = "Москва";
                cardThree.To = "Иркутск";

                Card cardFour = new Card();
                cardFour.Id = 4;
                cardFour.From = "Иркутск";
                cardFour.To = "Париж";

                Card cardFive = new Card();
                cardFive.Id = 5;
                cardFive.From = "Париж";
                cardFive.To = "Лондон";

                //Массив заполнен беспоряочно
                Card[] unsortedCards = new Card[5];
                unsortedCards[0] = cardOne;
                unsortedCards[1] = cardThree;
                unsortedCards[2] = cardFive;
                unsortedCards[3] = cardTwo;
                unsortedCards[4] = cardFour;

                CardsOperations sortingCards = new CardsOperations();

                var sortedCards = sortingCards.getSortedCards(unsortedCards);
                Console.WriteLine("До:");
                foreach (var item in unsortedCards)
                {
                    Console.WriteLine($"{item.From}>{item.To}");
                }
                Console.WriteLine();
                Console.WriteLine("После:");

                foreach (var item in sortedCards)
                {
                    Console.WriteLine($"{item.From}>{item.To}");
                }

                Console.ReadLine();

            }
        }
    }
}
