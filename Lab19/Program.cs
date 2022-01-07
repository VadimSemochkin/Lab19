using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19
{
    class Computer
    {
        public string Id { get; set; }
        public string Proc { get; set; }
        public int Freq { get; set; }
        public int Memory { get; set; }
        public int HDD { get; set; }
        public int VideoMemory { get; set; }
        public int Cost { get; set; }
        public int Sum { get; set; }


    }
    static class Program
    {
        static void Main(string[] args)
        {
            List<Computer> computers = new List<Computer>()
            {
                new Computer(){Id="01HyperX", Proc="Intel-i7", Freq=3400, Memory=6, HDD=1000, VideoMemory=2, Cost=55000, Sum=25},
                new Computer(){Id="02Intel", Proc="Intel-i7", Freq=3900, Memory=16, HDD=2000, VideoMemory=4, Cost=90000, Sum=10},
                new Computer(){Id="03AMD", Proc="AMD", Freq=3200, Memory=8, HDD=1000, VideoMemory=4, Cost=60000, Sum=35},
                new Computer(){Id="04MSI", Proc="Intel-i3", Freq=2600, Memory=6, HDD=2000, VideoMemory=1, Cost=35000, Sum=20},
                new Computer(){Id="05Acer", Proc="AMD", Freq=3400, Memory=16, HDD=1000, VideoMemory=6, Cost=100000, Sum=5},
                new Computer(){Id="06Asus", Proc="Intel-i5", Freq=3000, Memory=12, HDD=1500, VideoMemory=4, Cost=65000, Sum=12},
                new Computer(){Id="07Gigabyte", Proc="Intel-i3", Freq=2600, Memory=8, HDD=1000, VideoMemory=2, Cost=40000, Sum=14},
            };

            Console.WriteLine("Введите интересующий Вас процессор");
            string proc = Console.ReadLine();
            List<Computer> computers1 = computers
                .Where(p => p.Proc == proc)
                .ToList();
            Print(computers1);

            Console.WriteLine("Введите интересующий Вас объем ОЗУ");
            int memory = Convert.ToInt32(Console.ReadLine());
            List<Computer> computers2 = computers
                .Where(p => p.Memory >= memory)
                .ToList();

            Print(computers2);

            Console.WriteLine("Список компьютеров отсортированный по возрастанию стоимости");
            List<Computer> computers3 = computers
                .OrderBy(p => p.Cost)
                .ToList();

            Print(computers3);

            Console.WriteLine("Список сгрупированный по типу процессора");
            IEnumerable<IGrouping<string, Computer>> computers4 = computers.GroupBy(p => p.Proc);
            foreach (IGrouping<string, Computer> gr in computers4)
            {
                Console.WriteLine(gr.Key);
                foreach (Computer c in gr)
                {
                    Console.WriteLine($"{c.Id} {c.Proc} {c.Freq} {c.Memory} {c.HDD} {c.VideoMemory} {c.Cost} {c.Sum}");
                }
            }
            Console.WriteLine();
            Computer computer5 = computers.OrderByDescending(c => c.Cost).FirstOrDefault();
            Console.WriteLine($"Самый дорогой компьютер: {computer5.Id} {computer5.Proc} {computer5.Freq} {computer5.Memory} {computer5.HDD} {computer5.VideoMemory} {computer5.Cost} {computer5.Sum}");

            Computer computer6 = computers.OrderBy(c => c.Cost).FirstOrDefault();
            Console.WriteLine($"Самый бюджетный компьютер: {computer6.Id} {computer6.Proc} {computer6.Freq} {computer6.Memory} {computer6.HDD} {computer6.VideoMemory} {computer6.Cost} {computer6.Sum}");
            Console.WriteLine();
            Console.Write("Есть ли хоть один компьютер в колличестве более 30 шт: ");
            Console.WriteLine(computers.Any(c=>c.Sum>30)); 
            Console.ReadKey();

        }

        static void Print(List<Computer> computers)
        {
            foreach(Computer c in computers)
            {
                Console.WriteLine($"{c.Id} {c.Proc} {c. Freq} {c.Memory} {c.HDD} {c.VideoMemory} {c.Cost} {c.Sum}");
            }
            Console.WriteLine();
        }
       
    }
}
