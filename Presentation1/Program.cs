using Core.Constants;
using Core.Helper;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Presentation1
{
    public static class Program
    {
        static void Main()
        {
            ConsoleHelper.WriteWithColor("---Welcome!---", ConsoleColor.Cyan);
            while (true)
            {

                ConsoleHelper.WriteWithColor(" 1 - Create Group", ConsoleColor.Yellow);
                ConsoleHelper.WriteWithColor(" 2 - Update Group", ConsoleColor.Yellow);
                ConsoleHelper.WriteWithColor(" 3 - Delete Group", ConsoleColor.Yellow);
                ConsoleHelper.WriteWithColor(" 4 - Get All Group", ConsoleColor.Yellow);
                ConsoleHelper.WriteWithColor(" 5 - Get Group by ID", ConsoleColor.Yellow);
                ConsoleHelper.WriteWithColor(" 6 - Get Group by Name", ConsoleColor.Yellow);
                ConsoleHelper.WriteWithColor(" 0 - Exit", ConsoleColor.Yellow);
                ConsoleHelper.WriteWithColor(" Select one of the options above", ConsoleColor.Cyan);

                int number;
                bool isSucceeded = int.TryParse(Console.ReadLine(), out number);
                if (!isSucceeded)
                {
                    ConsoleHelper.WriteWithColor("The entered number is not a correct format!", ConsoleColor.Red);
                }
                else
                {
                    if (!(number >= 0 && number <= 6))
                    {
                        ConsoleHelper.WriteWithColor("There is not such a number in the list!", ConsoleColor.Red);
                    }
                    else
                    {
                        switch (number)
                        {
                            case (int)GroupOptions.CreateGroup:
                                ConsoleHelper.WriteWithColor("---Enter name, please---", ConsoleColor.Cyan);
                                string name = Console.ReadLine();

                            MaxSizeDes: ConsoleHelper.WriteWithColor("---Enter group max - size,please---", ConsoleColor.Cyan);
                                int maxSize;
                                isSucceeded = int.TryParse(Console.ReadLine(), out maxSize);
                                if (!isSucceeded)
                                {
                                    ConsoleHelper.WriteWithColor("Max size is not a correct format!", ConsoleColor.Red);
                                    goto MaxSizeDes;
                                }
                                if (maxSize > 18)
                                {
                                    ConsoleHelper.WriteWithColor("Max size must be less than or equal to 18", ConsoleColor.Red);
                                    goto MaxSizeDes;
                                }

                            StartDateDes: ConsoleHelper.WriteWithColor("Enter start date,please", ConsoleColor.Cyan);
                                DateTime startDate;
                                isSucceeded = DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);
                                if (!isSucceeded)
                                {
                                    ConsoleHelper.WriteWithColor("The start date is not a correct format!", ConsoleColor.Red);
                                    goto StartDateDes;
                                } 
                            EndDateDes: ConsoleHelper.WriteWithColor("Enter end date,please", ConsoleColor.Cyan);
                                DateTime endDate;
                                isSucceeded = DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);
                                if (!isSucceeded)
                                {
                                    ConsoleHelper.WriteWithColor("The end date is not a correct format!", ConsoleColor.Red);
                                    goto EndDateDes;
                                }
                                if (startDate > endDate)
                                {
                                    ConsoleHelper.WriteWithColor("The end date must be bigger than the start date", ConsoleColor.Red);
                                    goto EndDateDes;
                                }

                                var group = new Core.Entities.Group
                                {
                                    Name = name,
                                    MaxSize = maxSize,
                                    StartDate= startDate,
                                    EndDate= endDate,
                                };
                                break;
                            case (int)GroupOptions.UpdateGroup:
                                break;
                            case (int)GroupOptions.DeleteGroup:
                                break;
                            case (int)GroupOptions.GetAllGroup:
                                break;
                            case (int)GroupOptions.GetGroupbyID:
                                break;
                            case (int)GroupOptions.GetGroupbyName:
                                break;
                            case (int)GroupOptions.Exit:
                                break;
                            default:
                                break;
                        }
                    }


                }
            }

        }
    }
}