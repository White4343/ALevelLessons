using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace LessonOneFinalModuleHW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isNotExit = true;

            string[] taskArray = {};
            string[] finishedTaskArray = {};
            string[] datesOfFinishedTaskArray = {};

            while (isNotExit)
            {
                Console.WriteLine("Command list: \n add-item\n remove-item\n mark-as\n show\n exit");

                string userCommandStr = Console.ReadLine(); ;

                switch (userCommandStr)
                {
                    case "exit":
                        isNotExit = ExitFunc(isNotExit);
                        break;
                    case "add-item":
                        Console.WriteLine("Please write task-item:");
                        string userTask = Console.ReadLine();
                        taskArray = AddItemFunc(taskArray, userTask).ToArray();
                        continue;
                    case "remove-item":
                        Console.WriteLine("Please write task-item:");
                        string userTaskDelete = Console.ReadLine();

                        if (userTaskDelete == "*")
                        {
                            Array.Clear(taskArray);
                            Array.Clear(finishedTaskArray);
                            Array.Clear(datesOfFinishedTaskArray);

                            Console.WriteLine("To-Do list is cleaned.");
                        }
                        else
                        {
                            (taskArray, finishedTaskArray, datesOfFinishedTaskArray) = DeleteItemFunc(taskArray, finishedTaskArray, datesOfFinishedTaskArray, userTaskDelete);
                        }

                        continue;
                    case "show":
                        Console.WriteLine("Sub-command:\n1 - task done\n0 - task not done");
                        string userCmdLine = Console.ReadLine();
                        PrintArray(taskArray, finishedTaskArray, datesOfFinishedTaskArray, userCmdLine);
                        continue;
                    case "mark-as":
                        Console.WriteLine("Sub-command:\n1 - task done\n0 - task not done");
                        string userStatus = Console.ReadLine();
                        Console.WriteLine("Please write task-item:");
                        string userTaskLine = Console.ReadLine();

                        (taskArray, finishedTaskArray, datesOfFinishedTaskArray) =
                            MarkAsFunc(taskArray, finishedTaskArray, datesOfFinishedTaskArray, userTaskLine, userStatus);
                        continue;
                }
            }
        }

        static bool ExitFunc(bool value)
        {
            Console.WriteLine("Exiting program");
            value = false;
            return value;
        }

        static string[] AddItemFunc(string[] array, string value)
        {
            if (value == String.Empty)
            {
                Console.WriteLine("You're task-item is empty!");
            }

            else
            {
                array = Array.ConvertAll(array, x => x.ToLower()).ToArray();

                value = value.ToLower();

                string valueEmpty = Array.Find(array, i => i.StartsWith(value, StringComparison.Ordinal));

                if (valueEmpty != null && !DateTime.TryParse(value, out DateTime Temp))
                {
                    Console.WriteLine("You're task-item is already there!");
                }
                else
                {
                    array = array.Append(value).ToArray();
                    Console.WriteLine($"You're task-item '{value}' was added!");
                }
            }

            return array;
        }

        static (string[] taskArray, string[] finishedTaskArray, string[] dateArray) DeleteItemFunc(string[] taskArray, string[] finishedTaskArray, string[] dateArray, string value)
        {
            if (value == String.Empty)
            {
                Console.WriteLine("You're task-item is empty!");
            }

            else
            {
                string taskArrayEmpty = Array.Find(taskArray, i => i.StartsWith(value, StringComparison.Ordinal));
                string finishedTaskArrayEmpty = Array.Find(finishedTaskArray, i => i.StartsWith(value, StringComparison.Ordinal));

                if (taskArrayEmpty != null && finishedTaskArrayEmpty == null)
                {
                    taskArray = taskArray.Where(i => i != value).ToArray();
                }
                else if (finishedTaskArrayEmpty != null && taskArrayEmpty == null)
                {
                    int indexDate = Array.FindIndex(finishedTaskArray, i => i.StartsWith(value, StringComparison.Ordinal));
                    dateArray = dateArray.Where((source, index) => index != indexDate).ToArray();
                    finishedTaskArray = finishedTaskArray.Where(i => i != value).ToArray();
                    Console.WriteLine($"You're task-item '{value}' was deleted!");
                }
                else
                {
                    Console.WriteLine("You're task-item is not there!");
                }
            }

            return (taskArray, finishedTaskArray, dateArray);
        }

        static void PrintArray(string[] taskArray, string[] finishedTaskArray, string[] dateArray, string status)
        {
            if (status == "1")
            {
                Console.WriteLine("[Finished]");
                Console.WriteLine(" {0}", string.Join(" \n  ", finishedTaskArray));
                Console.WriteLine("[Date]");
                Console.WriteLine(" {0}", string.Join(" \n  ", dateArray));
            } 
            else if (status == "0")
            {
                Console.WriteLine("[Active]");
                Console.WriteLine(" {0} ", string.Join(" \n ", taskArray));

            }
            else if (status == String.Empty)
            {
                Console.WriteLine("[Active]");
                Console.WriteLine(" {0} ", string.Join(" \n  ", taskArray));
                Console.WriteLine("[Finished]");
                Console.WriteLine(" {0} ", string.Join(" \n  ", finishedTaskArray));
                Console.WriteLine("[Date]");
                Console.WriteLine(" {0} ", string.Join(" \n  ", dateArray));
            }
            else
            {
                Console.WriteLine("You're command input isn't valid");
            }
        }

        static (string[] taskArray, string[] finishedTaskArray, string[] dateArray) MarkAsFunc(string[] taskArray, string[] finishedTaskArray, string[] dateArray, string value, string status)
        {

            if (value == String.Empty)
            {
                Console.WriteLine("You're task-item is empty!");
            }

            else
            {
                if (int.TryParse(status, out int statusResult))
                {
                    if (statusResult == 0) // task is not finished
                    {
                        string valueEmpty = Array.Find(finishedTaskArray, i => i.StartsWith(value, StringComparison.Ordinal));

                        if (valueEmpty != null)
                        {
                            int indexDate = Array.FindIndex(finishedTaskArray, i => i.StartsWith(value, StringComparison.Ordinal));
                            (taskArray, finishedTaskArray, dateArray) = DeleteItemFunc(taskArray, finishedTaskArray, dateArray, value);
                            dateArray = dateArray.Where((source, index) => index != indexDate).ToArray();
                            taskArray = AddItemFunc(taskArray, value).ToArray();
                            Console.WriteLine("All data added!");
                        }
                        else
                        {
                            Console.WriteLine("You're task-item is not there!");
                        }

                    }
                    else if (statusResult == 1) // task is finished
                    {
                        string valueEmpty = Array.Find(taskArray, i => i.StartsWith(value, StringComparison.Ordinal));

                        if (valueEmpty != null)
                        {
                            Console.WriteLine("Please enter date in format DD.MM.YYYY:");
                            string userDateLine = Console.ReadLine();

                            if (userDateLine == String.Empty)
                            {
                                userDateLine = DateTime.Now.ToShortDateString();
                            }

                            if (DateTime.TryParse(userDateLine, out DateTime Temp))
                            {
                                (taskArray, finishedTaskArray, dateArray) = DeleteItemFunc(taskArray, finishedTaskArray, dateArray, value);
                                finishedTaskArray = AddItemFunc(finishedTaskArray, value).ToArray();
                                dateArray = AddItemFunc(dateArray, userDateLine).ToArray();

                                Console.WriteLine("All data added!");
                            }
                            else
                            {
                                Console.WriteLine("You're entered date is not in format DD/MM/YYYY:");
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("You're task-item is not there!");
                        }

                    }
                    else
                    {
                        Console.WriteLine("You're status doesn't in a range between [0;1]");
                    }
                }

                else
                {
                    Console.WriteLine("You're status is not a number");
                }
            }

            return (taskArray, finishedTaskArray, dateArray);
        }
    }
}