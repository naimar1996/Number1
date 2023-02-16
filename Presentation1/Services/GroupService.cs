using Core.Helper;
using Data.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation1.Services
{
    public class GroupService
    {
        private readonly GroupRepository _grouprepository;
        public GroupService()
        {
            _grouprepository = new GroupRepository();
        }

        public void GetAll()
        {

            var groups = _grouprepository.GetAll();

            ConsoleHelper.WriteWithColor("---All Groups---", ConsoleColor.Cyan);

            foreach (var group in groups)
            {
                ConsoleHelper.WriteWithColor($"Id: {group.Id},Name:{group.Name},Max size : {group.MaxSize},Start date: {group.StartDate.ToShortTimeString()},End date : {group.EndDate.ToShortTimeString()}", ConsoleColor.DarkYellow);
            }
        }
        public void Create()
        {
            ConsoleHelper.WriteWithColor("---Enter name, please---", ConsoleColor.Cyan);
            string name = Console.ReadLine();

        MaxSizeDes: ConsoleHelper.WriteWithColor("---Enter group max - size,please---", ConsoleColor.Cyan);
            int maxSize;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out maxSize);
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
                StartDate = startDate,
                EndDate = endDate,
            };

            _grouprepository.Add(group);

            ConsoleHelper.WriteWithColor($"The group succesfully created with Name:{group.Name},Max size : {group.MaxSize},Start date: {group.StartDate.ToShortTimeString()},End date : {group.EndDate.ToShortTimeString()}", ConsoleColor.DarkYellow);
        }
        public void Delete()
        {
            GetAll();

        IdDes: ConsoleHelper.WriteWithColor("Enter end date,please", ConsoleColor.Cyan);
            int id;
            bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("The ID is not a correct format!", ConsoleColor.Red);
                goto IdDes;
            }
            var dbGroup = _grouprepository.Get(id);
            if (dbGroup == null)
            {
                ConsoleHelper.WriteWithColor("There is not any in this ID!", ConsoleColor.Red);
            }
            else
            {
                _grouprepository.Delete(dbGroup);
                ConsoleHelper.WriteWithColor("The group successfully deleted!", ConsoleColor.Green);
            }

        }
        public void Exit()
        {
        AreyousureDesc: ConsoleHelper.WriteWithColor("Are you sure? \n a) yes \n b) no ", ConsoleColor.DarkYellow);
            char decision;
            bool isSucceeded = char.TryParse(Console.ReadLine(), out decision);
            if (!isSucceeded)
            {
                ConsoleHelper.WriteWithColor("Your choice is not a correct format!", ConsoleColor.Red);
            }
            if (!(decision == 'a' || decision == 'b'))
            {
                ConsoleHelper.WriteWithColor(" Your choice is not correct!", ConsoleColor.Red);
                goto AreyousureDesc;
            }
            if(decision == 'a')
            {
                return;
            }
           
        }


    }
}

