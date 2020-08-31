using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace elva
{
    class Program
    {
        static void Main(string[] args)
        {
            GetFileBingMaps fileGetter = new GetFileBingMaps();
            Console.WriteLine("Введите адрес:");
            string address = Console.ReadLine();
            int n = 0;
            string s = null;
            do
            {
                Console.WriteLine("Введите n");
                s = Console.ReadLine();
            }
            while (!int.TryParse(s, out n));
            Console.WriteLine("Введите имя файла без расширения");
            string fileName = Console.ReadLine();
            try
            {
                IFileGetter getter = new GetFileBingMaps();
                FileProcessor processor = new FileProcessor(getter);
                processor.Process(address, n, fileName);
            }
            catch(WebException ex)
            {
                Console.WriteLine("Произошла ошибка.Возможно адрес не найден.");
            }
        }
    }
}
