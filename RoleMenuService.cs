using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace App;

class RoleMenuService
{
    public static void ShowMenuOption(User user, Permission permission, int optionNumber, string text)
    // writing: testing if the user has the permission to view option, else it shows permission required.

    {
        if (user.TryPermission(permission))
            Console.WriteLine($"{optionNumber}) {text}");
        else
            Console.WriteLine($"{optionNumber}) Permission required...");
    }
    public static void ShowPermissionMenu_Staff(User activeUser)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine($"Logged in as {activeUser.UserRole}: {activeUser.Username}");
            Console.WriteLine("Select an action:\n");

            ShowMenuOption(activeUser, Permission.ViewPatientJournalEntries, 1, "View a patient's journal entries");
            ShowMenuOption(activeUser, Permission.SetHiddenEntries, 2, "Mark journal entries as sensitive / non-sensitive");
            ShowMenuOption(activeUser, Permission.RegisterAppointments, 3, "Register a new appointment");
            ShowMenuOption(activeUser, Permission.ModifyAppointments, 4, "Modify an existing appointment");
            ShowMenuOption(activeUser, Permission.ApproveAppointmentRequests, 5, "Approve appointment requests");
            ShowMenuOption(activeUser, Permission.ViewLocationSchedule, 6, "View the schedule of a location");

            Console.WriteLine("0) Logout");
            Console.Write("\nSelect an option: ");
            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    // ViewPatientJournalEntries()
                    Console.WriteLine("Viewing patient journals...");
                    break;

                case "2":
                    // MarkJournalEntrySensitivity()
                    Console.WriteLine("Marking journal entry sensitivity...");
                    break;

                case "3":
                    // RegisterAppointments()
                    Console.WriteLine("Registering a new appointment...");
                    break;

                case "4":
                    // ModifyAppointments()
                    Console.WriteLine("Modifying an appointment...");
                    break;

                case "5":
                    // ApproveAppointmentRequests()
                    Console.WriteLine("Approving appointment request...");
                    break;

                case "6":
                    // ViewLocationSchedule()
                    Console.WriteLine("Viewing location schedule...");
                    break;

                case "0":
                    Console.WriteLine("Logging out...");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid selection. Press Enter to continue.");
                    Console.ReadLine();
                    break;
            }
        }
    }
    public static void ShowPermissionMenu_Admin(User activeUser, List<User> users, string path)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine($"Logged in as {activeUser.UserRole}: {activeUser.Username}");
            Console.WriteLine("Select an action:\n");
            ShowMenuOption(activeUser, Permission.HandlePermissionSystem, 1, "Handle the permission system (fine granularity)");
            ShowMenuOption(activeUser, Permission.AssignAdminsToRegions, 2, "Assign admins to certain regions");
            ShowMenuOption(activeUser, Permission.HandleRegistrations, 3, "Handle registrations");
            ShowMenuOption(activeUser, Permission.AddLocations, 4, "Add new locations");
            ShowMenuOption(activeUser, Permission.CreatePersonnelAccounts, 5, "Create accounts for personnel");
            ShowMenuOption(activeUser, Permission.ViewPermissionOverview, 6, "View who has permission to what");

            Console.WriteLine("0) Logout");

            Console.Write("\nSelect an option: ");
            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.WriteLine("Opening Permission System...");
                    // PermissionManager.ManagePermissions(activeUser);
                    break;

                case "2":
                    Console.WriteLine("Assigning Admins to Regions...");
                    // RegionManager.AssignAdminToRegion(activeUser);
                    break;

                case "3":
                    if (activeUser.TryPermission(Permission.HandleRegistrations))
                    {
                        Permissions.HandleRegistrations(activeUser, users, path);
                    }
                    else
                    {
                        Console.WriteLine("Permission denied...");
                    }
                    break;

                case "4":
                    Console.WriteLine("Adding new Location...");
                    // LocationManager.AddLocation(activeUser);
                    break;

                case "5":
                    Console.WriteLine("Creating Personnel Account...");
                    // PersonnelManager.CreatePersonnel(activeUser);
                    break;

                case "6":
                    Console.WriteLine("Viewing Permission Overview...");
                    // PermissionViewer.ShowOverview(activeUser);
                    break;

                case "0":
                    running = false;
                    Console.WriteLine("Logging out...");
                    activeUser = null;
                    break;

                default:
                    Console.WriteLine("Invalid selection. Press Enter to continue.");
                    Console.ReadLine();
                    break;
            }
            if (running)
            {
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
            else break;
        }
    }
    public static void ShowPermissionMenu_Patient(User activeUser)
    {
        bool running = true;

        while (running)
        {
            ShowMenuOption(activeUser, Permission.ViewJournal, 1, "View my own journal");
            ShowMenuOption(activeUser, Permission.RequestAppointment, 2, "Request an appointment");
            ShowMenuOption(activeUser, Permission.ViewSchedule, 3, "View my schedule");

            Console.WriteLine("0) Logout");

            Console.Write("\nSelect an option: ");
            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    if (activeUser.TryPermission(Permission.ViewJournal))
                    {
                        Console.WriteLine("Opening your personal journal...");
                        JournalManager.ViewJournal(activeUser);
                    }
                    else
                    {
                        Console.WriteLine("You do not have permission to view your journal.");
                    }
                    break;

                case "2":
                    if (activeUser.TryPermission(Permission.RequestAppointment))
                    {
                        Console.WriteLine("Requesting an appointment...");
                        AppointmentManager.RequestAppointment(activeUser);
                    }
                    else
                    {
                        Console.WriteLine("You do not have permission to request an appointment.");
                    }
                    break;

                case "3":
                    if (activeUser.TryPermission(Permission.ViewSchedule))
                    {
                        Console.WriteLine("Viewing your schedule...");
                        ScheduleManager.ViewOwnSchedule(activeUser);
                    }
                    else
                    {
                        Console.WriteLine("You do not have permission to view your schedule.");
                    }
                    break;

                case "0":
                    running = false;
                    Console.WriteLine("Logging out...");
                    break;

                default:
                    Console.WriteLine("Invalid selection. Press Enter to continue.");
                    Console.ReadLine();
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }

    }
}


// ----------- PATIENT-METODER --------------

// Dessa 3 metoder anropas från RoleMenuService när patienten
// väljer ett alternativ i menyn.
// Hanterar allt som har med patientens journal att göra
class JournalManager
{
    public static void ViewJournal(User activeUser)
    {
        Console.WriteLine($"Showing journal for {activeUser.Username}...");
        // Här kan du senare läsa från en fil eller databas där journaler sparas
        // Exempel: just nu skriver vi bara ut en enkel text.
        Console.WriteLine("No journal entries found yet.");
    }
}

// Hanterar patientens tidsbokningar
class AppointmentManager
{
    public static void RequestAppointment(User activeUser)
    {
        Console.WriteLine($"{activeUser.Username} is requesting an appointment...");

        // TODO: Här kan man lägga logik som sparar patientens önskade tid till en CSV-fil.
        // Exempelvis:
        // File.AppendAllText("Appointments.csv", $"{activeUser.Username},requested,{DateTime.Now}\n");

        Console.WriteLine("Your appointment request has been sent to staff.");
    }
}

// Hanterar patientens schema
class ScheduleManager
{
    public static void ViewOwnSchedule(User activeUser)
    {
        Console.WriteLine($"Viewing schedule for {activeUser.Username}...");

        // TODO: Här kan vi senare läsa patientens tider från filen "Appointments.csv"
        // Just nu visar vi bara exempeltext
        Console.WriteLine("You have no upcoming appointments.");
    }
}