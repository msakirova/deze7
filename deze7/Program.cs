using CompanyTasks.Class;
using deze7.Enums;

namespace CompanyTasks
{
    internal class Program
    {
        static void Main()
        {
            TaskOrganization();
        }

        static void TaskOrganization()
        {

            Employee timur = new Employee("Тимур", TaskCategory.Management);
            Employee rashid = new Employee("Рашид", TaskCategory.Management);
            Employee ilham = new Employee("О Ильхам", TaskCategory.Management);
            Employee lukas = new Employee("Лукас", TaskCategory.Management);
            Employee arkadiy = new Employee("Оркадий", TaskCategory.Management);
            Employee volodya = new Employee("Володя", TaskCategory.Management);

            Employee ilshat = new Employee("Ильшат", TaskCategory.Systems);
            Employee ivanych = new Employee("Иваныч", TaskCategory.Systems);
            Employee ilya = new Employee("Илья", TaskCategory.Systems);
            Employee vitia = new Employee("Витя", TaskCategory.Systems);
            Employee zhenya = new Employee("Женя", TaskCategory.Systems);

            Employee sergey = new Employee("Сергей", TaskCategory.Developers);
            Employee laysyan = new Employee("Ляйсан", TaskCategory.Developers);
            Employee marat = new Employee("Марат", TaskCategory.Developers);
            Employee dina = new Employee("Дина", TaskCategory.Developers);
            Employee ildar = new Employee("Ильдар", TaskCategory.Developers);
            Employee anton = new Employee("Антон", TaskCategory.Developers);

            #region Назначение руководителей

            rashid.AddManager(timur);
            ilham.AddManager(timur);

            lukas.AddManager(rashid);

            arkadiy.AddManager(ilham);
            volodya.AddManager(ilham);

            ilshat.AddManager(arkadiy);
            sergey.AddManager(arkadiy);

            sergey.AddManager(volodya);
            ilshat.AddManager(volodya);

            ivanych.AddManager(ilshat);

            ilya.AddManager(ivanych);
            vitia.AddManager(ivanych);
            zhenya.AddManager(ivanych);


            laysyan.AddManager(sergey);

            marat.AddManager(laysyan);
            dina.AddManager(laysyan);
            ildar.AddManager(laysyan);
            anton.AddManager(laysyan);

            #endregion

            List<Employee> employees = new List<Employee> {timur,rashid,ilham,lukas,arkadiy,volodya,ilshat,ivanych,ilya,vitia,zhenya,sergey,laysyan,marat,dina,ildar,anton};

            Console.WriteLine();
            Console.WriteLine("Список сотрудников:");

            foreach (Employee employee in employees)
                employee.PrintInformation();

            #region Создание и распределение задач

            WorkTask task1 = new WorkTask(1,"Проверить работу отдела","Подготовить отчёт о работе отдела", TaskCategory.Management);
            WorkTask task2 = new WorkTask(2,"Настроить сервер","Проверить настройки и подключение сервера",TaskCategory.Systems);
            WorkTask task3 = new WorkTask(3,"Разработать программу","Написать и проверить программный код",TaskCategory.Developers);
            WorkTask task4 = new WorkTask(4,"Обновить сетевое оборудование","Проверить и обновить оборудование",TaskCategory.Systems);
            WorkTask task5 = new WorkTask(5,"Исправить ошибки программы","Найти и устранить ошибки в коде",TaskCategory.Developers);

            AssignTask(ilham, arkadiy, task1);
            AssignTask(ilshat, ivanych, task2);
            AssignTask(laysyan, marat, task3);
            AssignTask(volodya, ilshat, task4);
            AssignTask(sergey, dina, task5);
            AssignTask(timur, marat, task3);

            #endregion
        }

        #region Назначение задачи

        /// <summary>
        /// Передаёт задачу сотруднику и проверяет возможность её принятия
        /// </summary>
        static void AssignTask(Employee manager, Employee employee, WorkTask task)
        {
            Console.WriteLine();

            Console.WriteLine($"От человека {manager.Name} даётся задача \"{task.Description}\" человеку {employee.Name}.");

            task.PrintInformation();

            if (employee.CanAcceptTask(manager, task))
                Console.WriteLine($"{employee.Name} принимает задачу.");
            else
                Console.WriteLine($"{employee.Name} не принимает задачу.");
        }

        #endregion
    }
}
