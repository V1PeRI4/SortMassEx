
/*9.Различные цеха завода выпускают продукцию нескольких наименований. 
 * Сведения о продукции включают: наименование, количество, номер цеха.
 * Для заданного цеха необходимо вывести изделия по каждому наименованию в
 * порядке убывания их количества.Ключ: количество выпущенных изделий.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SortMassEx
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            // хотел красиво все оформить, перенести все в класс, но задолбался ночь сидеть)))
            // очень тупил с двумерными массивами, а так смотриться очень легко


            //счетчик цехов, дальше как элемент условия для массива
            Console.Write("Количество цехов: ");
            int countManu = Convert.ToInt32(Console.ReadLine());

            //счетчик наименований, дальше как элемент условия для массива
            Console.Write("Количество наименований: ");
            int countAmount = Convert.ToInt32(Console.ReadLine());


            Production[,] prod = new Production[countManu, 50];


            for (int i = 0; i < countManu; i++)
            {
                Console.Write("Номер цеха: ");
                int count = Convert.ToInt32(Console.ReadLine());

                    for (int j = 0; j < countAmount; j++)
                    {
                        prod[i, j] = new Production();
                        prod[i, 0].NumManufactory = count;

                        Console.Write("Наименование изделия: ");
                        prod[i, j].Name = Console.ReadLine();

                        Console.Write("Количество изделий: ");
                        prod[i, j].Amount = Convert.ToInt32(Console.ReadLine());
                    }
             }
           
            //ввременная переменная для сравнения номера завода
            Console.Write("\nНомер цеха для вывода информации: ");
            int manufactory = Convert.ToInt32(Console.ReadLine());

            // l - для переноса номера завода, temp - для сортировки
            int l = 0, temp;

            //поиск подходящего номера завода
            for (int i = 0; i < countManu; i++)
            {
                if (prod[i, 0].NumManufactory == manufactory) { l = i; }
                else if (l == 0) { Console.WriteLine("Ввели неверный номер завода..."); }
            }

            // сортировка по возрастанию
            for (int i = 0; i < countAmount - 1; i++)
            {
                for (int j = i + 1; j < countAmount; j++)
                {
                    if (prod[l, i].Amount > prod[l, j].Amount)
                    {
                        temp = prod[l, i].Amount;
                        prod[l, i].Amount = prod[l, j].Amount;
                        prod[l, j].Amount = temp;
                    }  
                }
            }
            
            //переворот массива
            for (int i = countAmount - 1; i >= 0; i--) 
            Console.WriteLine(prod[l, i].Name + " в наличии: " + prod[l, i].Amount + " шт.");

            Console.ReadKey();
        }

     
    }         
}


