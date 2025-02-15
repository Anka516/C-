using System;

class Program
{
    static void Main(string[] args)
    {
        string[] courses = new string[10];
        string[,] students = new string[10, 15];
        string[,] studentIds = new string[10, 5];
        int courseCount = 1;

        while (true)
        {
            Console.WriteLine("1)Добавить курс");
            Console.WriteLine("2)Записать студента");
            Console.WriteLine("3)Показать студентов на курсе");
            Console.WriteLine("4)Удалить студента");
            Console.WriteLine("5)Выход");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    if (courseCount < 10)
                    {
                        Console.Write("Введите название курса: ");
                        courses[courseCount] = Console.ReadLine();
                        courseCount++;
                        Console.WriteLine("Данный курс имеет номер {0}", courseCount-1);
                        Console.WriteLine("Курс добавлен.");
                    }
                    else
                    {
                        Console.WriteLine("Максимальное количество курсов достигнуто.");
                    }
                    break;

                case "2":
                    Console.Write("Введите номер курса (0 - {0}): ", courseCount-1);
                    int courseIndex = int.Parse(Console.ReadLine());

                    if (courseIndex >= 0 && courseIndex < courseCount)
                    {
                        Console.Write("Введите имя студента: ");
                        string studentName = Console.ReadLine();

                        Console.Write("Введите ID студента: ");
                        string studentId = Console.ReadLine();

                        for (int i = 0; i < 5; i++)
                        {
                            if (students[courseIndex, i] == null)
                            {
                                students[courseIndex, i] = studentName;
                                studentIds[courseIndex, i] = studentId;
                                Console.WriteLine("Студент добавлен.");
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный номер курса.");
                    }
                    break;

                case "3":
                    Console.Write("Введите номер курса (0 - {0}): ", courseCount-1);
                    int displayCourseIndex = int.Parse(Console.ReadLine());

                    if (displayCourseIndex >= 0 && displayCourseIndex < courseCount)
                    {
                        Console.WriteLine("Студенты на курсе {0}:", courses[displayCourseIndex]);
                        for (int i = 0; i < 15; i++)
                        {
                            if (students[displayCourseIndex, i] != null)
                            {
                                Console.WriteLine("Имя: {0}, ID: {1}", students[displayCourseIndex, i], studentIds[displayCourseIndex, i]);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный номер курса.");
                    }
                    break;

                case "4":
                    Console.Write("Введите номер курса (0 - {0}): ", courseCount - 1);
                    int removeCourseIndex = int.Parse(Console.ReadLine());

                    if (removeCourseIndex >= 0 && removeCourseIndex < courseCount)
                    {
                        Console.Write("Введите имя студента для удаления: ");
                        string studentToRemove = Console.ReadLine();

                        for (int i = 0; i < 15; i++)
                        {
                            if (students[removeCourseIndex, i] == studentToRemove)
                            {
                                students[removeCourseIndex, i] = null;
                                studentIds[removeCourseIndex, i] = null;
                                Console.WriteLine("Студент удален.");
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный номер курса.");
                    }
                    break;

                case "5":
                    Console.WriteLine("Выход из программы.");
                    return;

                default:
                    Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}