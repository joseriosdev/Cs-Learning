using BetterConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyACTIO.Entities;

namespace TinyACTIO.Utilities
{
    public class AppController
    {
        private static User _currentUser = DBMethods.GetCurrentUser();
        private static Workspace _currentWS = DBMethods.GetCurrentWorkspace();
        public static void Run()
        {
            string[] validValues = new string[] { "1", "2", "3", "4", "5", "6" };
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" ____________");
            Console.WriteLine("| Tiny ACTIO |");
            Console.WriteLine(" ------------");
            Console.ResetColor();
            Console.WriteLine("** select an option **");
            Console.WriteLine("[1] Create Event");
            Console.WriteLine("[2] Get existing Events");
            Console.WriteLine("[3] Update Event");
            Console.WriteLine("[4] Delete Event");
            Console.WriteLine("[5] Get session details");
            Console.WriteLine("[6] Exit");
            string? input = Console.ReadLine();
            input = InputCleaner.RemoveNull(input);
            InputValidatorWrapper validator = InputCleaner.IsValidValue(input, validValues);
            input = validator.NewInput == null ? input : validator.NewInput;
            if (validator.IsValid)
            {
                switch (input)
                {
                    case "1": CreateEvent(); break;
                    case "2": GetAllEvents(); break;
                    case "3": UpdateExistingEvent(); break;
                    case "4": DeleteEvent(); break;
                    case "5": GetSessionDetails(); break;
                    case "6": System.Environment.Exit(0); break;
                }
            }
        }
        public static void GetEventsByCurrentUserId()
        {
            List<Event> events = DBMethods.GetEventsByOrginizedId(_currentUser.Id);
            Table table = new Table("Id", "Event Name");
            table.Config = TableConfiguration.Markdown();
            foreach (Event e in events)
                table.AddRow(e.Id, e.Name);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(table);
            Console.ResetColor();
        }
        public static void CreateEvent()
        {
            Console.WriteLine("Event Name please:");
            var evt = new Event();
            string? evtName = Console.ReadLine();
            evtName = null == evtName ? "null" : evtName;
            evt.Name = evtName;
            evt.OrganizedById = _currentUser.Id;
            evt.WorkSpaceId = _currentWS.Id;
            evt.CreatedDate = DateTime.Now;
            DBMethods.InsertEvent(evt);
        }

        public static void GetAllEvents()
        {
            List<Event> events = DBMethods.GetAllEvents();
            Table table = new Table("#", "Event Name", "Orginized By", "Created Date");
            table.Config = TableConfiguration.UnicodeAlt();
            int index = 1;
            foreach (Event e in events)
            {
                table.AddRow(index, e.Name, e.OrganizedByName, e.CreatedDate);
                index++;
            }
            Console.WriteLine(table);
        }

        public static void UpdateExistingEvent()
        {
            GetEventsByCurrentUserId();
            Console.WriteLine("Type the Event ID to be selected");
            string? input = Console.ReadLine();
            input = InputCleaner.RemoveNull(input);
            int inputInt = InputCleaner.TransformToInt(input);
            Console.WriteLine("Type New Name:");
            input = Console.ReadLine();
            input = InputCleaner.RemoveNull(input);
            DBMethods.UpdateEvent(inputInt, input);
        }

        public static void DeleteEvent()
        {
            GetEventsByCurrentUserId();
            Console.WriteLine("Type the Event ID to be selected");
            string? input = Console.ReadLine();
            input = InputCleaner.RemoveNull(input);
            int inputInt = InputCleaner.TransformToInt(input);
            DBMethods.DeleteEvent(inputInt);
        }
        public static void GetSessionDetails()
        {
            Console.WriteLine(":------------------------------:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*** User for the current session ***");
            Console.WriteLine(_currentUser.Name + " => " + _currentUser.Email);
            Console.WriteLine("*** Current Workspace ***");
            Console.WriteLine(_currentWS.Name);
            Console.ResetColor();
            Console.WriteLine(":------------------------------:");
        }
    }
}
