using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; } = new List<string>();

        static void Main(string[] args)
        {
            int menuSelected = 0;
            do
            {
             menuSelected = ShowMainMenu();
                if  ((Menu)menuSelected == Menu.Add)
                {
                    ShowMenuAdd();
                }
                else if  ((Menu)menuSelected == Menu.Remove)
                {
                    ShowMenuRemove();
                }
                else if  ((Menu)menuSelected == Menu.List)
                {
                    ShowMenuTaskList();
                }
            } while  ((Menu)menuSelected != Menu.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string numberTask = Console.ReadLine();
            return Convert.ToInt32(numberTask);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
                TaskListMethod();

                string numberTaskRemove = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(numberTaskRemove) - 1;

                if (indexToRemove>(TaskList.Count - 1) || indexToRemove < 0)
                Console.WriteLine("Numero de tarea seleccionado no es valido");
                else {
                    if (indexToRemove > -1 && TaskList.Count > 0)
                    {
                        string taskRemoved = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine($"Tarea {taskRemoved} eliminada");
                    }
                }
                /*ESTE CODIGO LO HICE YO, pero me manda al catch cuando no es correcto el numero
                if (indexToRemove > -1 && TaskList.Count > 0)
                {
                    string task = TaskList[indexToRemove];
                    TaskList.RemoveAt(indexToRemove);
                    Console.WriteLine("Tarea " + task + " eliminada");
                } else {
                    Console.WriteLine("Numero de tarea seleccionado no es valido");
                }*/
            }
            catch (Exception)
            {
                Console.WriteLine("Ha ocurrido un error al eliminar la tarea");
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string taskEnteredByUser = Console.ReadLine();
                if((string.IsNullOrEmpty(taskEnteredByUser))==true)
                    Console.WriteLine("Se requiere que ingrese una tarea");
                else
                {
                    TaskList.Add(taskEnteredByUser);
                    Console.WriteLine("Tarea registrada");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ha ocurrido un error al intentar escribir la tarea");
            }
        }

        public static void ShowMenuTaskList()
        {
            if (TaskList?.Count > 0)
            {
                TaskListMethod();
            } 
            else
            {
                Console.WriteLine("No hay tareas por realizar");
            }
        }

        public static void TaskListMethod()
        {
            Console.WriteLine("----------------------------------------");
            var indexTask = 0;
            TaskList.ForEach(p=> Console.WriteLine($"{++indexTask}. {p}"));
            Console.WriteLine("----------------------------------------");
        }
    }

    public enum Menu 
    {
        Add = 1,
        Remove = 2,
        List = 3,
        Exit =4
    }
}
