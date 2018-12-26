using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
     class Program
    {
        public class Worker
        {
            public int id;
            public string surname;
            public int departmentId;

            public Worker(int _id, string _surname, int _departmentId)
            {
                id = _id;
                surname = _surname;
                departmentId = _departmentId;
            }
        }

        public class Department
        {
            public int id;
            public string name;

            public Department(int _id, string _name)
            {
                id = _id;
                name = _name;
            }
        }

        public class DepartmentWorker
        {
            public int workerId;
            public int departmentId;

            public DepartmentWorker(int _wId, int _depId)
            {
                workerId = _wId;
                departmentId = _depId;
            }
        }

        public static void Main(string[] args)
        {
            List<Worker> workers = new List<Worker>
            {
                new Worker(1, "Орлова", 2),
                new Worker(2, "Ануров", 1),
                new Worker(3, "Обезкова", 3),
                new Worker(4, "Курьянов", 2),
                new Worker(5, "Трофимова", 1),
                new Worker(6, "Акушко", 3),
                new Worker(7, "Голубкова", 2),
                new Worker(8, "Петров", 1),
                new Worker(9, "Тимофеев", 3),
            };

            List<Department> departments = new List<Department>
            {
                new Department(1, "Отдел разработок"),
                new Department(2, "Отдел продаж"),
                new Department(3, "Отдел кадров")
            };

            List<DepartmentWorker> depWorkers = new List<DepartmentWorker>
            {
                new DepartmentWorker(1, 2),
                new DepartmentWorker(1, 3),
                new DepartmentWorker(2, 1),
                new DepartmentWorker(2, 2),
                new DepartmentWorker(3, 3),
                new DepartmentWorker(4, 2),
                new DepartmentWorker(5, 1),
                new DepartmentWorker(6, 3),
                new DepartmentWorker(6, 2),
                new DepartmentWorker(7, 2),
                new DepartmentWorker(7, 3),
                new DepartmentWorker(8, 2),
                new DepartmentWorker(9, 3),
            };


            Console.WriteLine("Отделы:");
            var q1 = from dep in departments
                     orderby dep.id
                     select dep.name;
            foreach (var department in q1)
            {
                Console.WriteLine(department);
            }
            Console.WriteLine();


            Console.WriteLine("Сотрудники:");
            var q2 = from w in workers
                     orderby w.departmentId
                     select w.surname;
            foreach (var worker in q2)
            {
                Console.WriteLine(worker);
            }
            Console.WriteLine();


            Console.WriteLine("Сотрудники с фамилией, начинающейся на \"A\":");
            var q3 = from w in workers
                     where w.surname[0] == 'А'
                     select w.surname;
            foreach (var worker in q3)
            {
                Console.WriteLine(worker);
            }

            Console.WriteLine();


            Console.WriteLine("Количество сотрудников в отделах");
            var q4 = from dep in departments
                     join w in workers on dep.id equals w.departmentId into temp
                     select new { Name = dep.name, Cnt = temp.Count() };
            foreach (var dep in q4)
            {
                Console.WriteLine("{0}: {1} сотрудников", dep.Name, dep.Cnt);
            }
            Console.WriteLine();


            Console.WriteLine("Отделы, в которых у всех сотрудников фамилия начинается на \"А\":");
            var q5 = from dep in departments
                     join w in workers on dep.id equals w.departmentId into temp
                     where temp.All(x => x.surname[0] == 'А')
                     select dep.name;
            foreach (var dep in q5)
            {
                Console.WriteLine(dep);
            }
            Console.WriteLine();


            Console.WriteLine("Отделы, в которых есть сотрудники с  фамилией на \"А\":");
            var q6 = from dep in departments
                     join w in workers on dep.id equals w.departmentId into temp
                     where temp.Any(x => x.surname[0] == 'А')
                     select dep.name;
            foreach (var dep in q6)
            {
                Console.WriteLine(dep);
            }
            Console.WriteLine();


            Console.WriteLine("Список отделов и сотрудники в них:");
            var q7 = from dep in departments
                     join depWork in depWorkers on dep.id equals depWork.departmentId into matchingRels

                     from depWork in matchingRels
                     join w in workers on depWork.workerId equals w.id into matchingWorks
                     from link in matchingWorks
                     select new { Dep = dep.name, Workers = link.surname };
            var q8 = from line in q7
                     group line by line.Dep into depWorks
                     select new { Dep = depWorks.Key, Workers = depWorks };

            foreach (var dep in q8)
            {
                Console.WriteLine(dep.Dep);
                foreach (var w in dep.Workers)
                {
                    Console.WriteLine("\t" + w.Workers);
                }
            }

            Console.WriteLine("\nПосле добавления связи многие-ко-многим\n");


            Console.WriteLine("Список отделов и количество сотрудников в них:");
            var q9 = from dep in departments
                     join depWork in depWorkers on dep.id equals depWork.departmentId into matchingRels
                     from depWork in matchingRels
                     join w in workers on depWork.workerId equals w.id into matchingWorks
                     from link in matchingWorks
                     select new { Dep = dep.name, Works = link.surname };
            var q10 = from line in q9
                      group line by line.Dep into depWorks
                      select new { Dep = depWorks.Key, Works = depWorks.Count() };

            foreach (var dep in q10)
            {
                Console.WriteLine(dep.Dep);
                Console.WriteLine("Количество сотрудников : {0}\n", dep.Works);
            }
            Console.ReadKey();
        }
    }
}
