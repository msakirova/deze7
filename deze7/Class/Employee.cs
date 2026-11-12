using deze7.Enums;

namespace CompanyTasks.Class
{
    public class Employee
    {
        private string _name;
        private TaskCategory _category;
        public List<Employee> Managers { get; }
        public List<Employee> Subordinates { get; }

        public string Name
        {
            get { return _name; }
        }

        public TaskCategory Category
        {
            get { return _category; }
        }


        /// <summary>
        /// Создаёт сотрудника организации
        /// </summary>
        public Employee(string name, TaskCategory category)
        {
            _name = name;
            _category = category;
            Managers = new List<Employee>();
            Subordinates = new List<Employee>();
        }


        /// <summary>
        /// Добавляет непосредственного руководителя сотрудника
        /// </summary>
        public void AddManager(Employee manager)
        {
            if (manager == null || Managers.Contains(manager))
                return;

            Managers.Add(manager);
            manager.Subordinates.Add(this);
        }

        /// <summary>
        /// Проверяет, может ли сотрудник принять задачу от руководителя
        /// </summary>
        public bool CanAcceptTask(Employee manager, WorkTask task)
        {
            if (manager == null || task == null)
                return false;

            bool isDirectManager = Managers.Contains(manager);
            bool isCorrectCategory = _category == task.Category;

            return isDirectManager && isCorrectCategory;
        }


        /// <summary>
        /// Выводит информацию о сотруднике и его руководителях
        /// </summary>
        public void PrintInformation()
        {
            Console.WriteLine($"Сотрудник: {_name}");
            Console.WriteLine($"Подразделение: {_category}");

            if (Managers.Count == 0)
                Console.WriteLine("Руководитель: отсутствует");
            else
            {
                Console.Write("Руководители: ");

                for (int i = 0; i < Managers.Count; i++)
                {
                    Console.Write(Managers[i].Name);

                    if (i < Managers.Count - 1)
                        Console.Write(", ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
