using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace App;

class RoleMenuService
{
    public static void ShowMenuOption(User user, Permission permission, int optionNumber, string text)
    {
        if (user.TryPermission(permission))
            Console.WriteLine($"{optionNumber}) {text}");
        else
            Console.WriteLine($"{optionNumber}) Permission required...");
    }
    public static void ShowPermissionMenu(User activeUser)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine($"Logged in as {activeUser.UserRole}: {activeUser.Username}");
            Console.WriteLine("Select an action:\n");
            if (activeUser.UserRole == Role.Staff)
            {
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
                        running = false;
                        Console.WriteLine("Logging out...");
                        break;

                    default:
                        Console.WriteLine("Invalid selection. Press Enter to continue.");
                        Console.ReadLine();
                        break;
                }
            }
            else if (activeUser.UserRole == Role.Admin)
            {
                ShowMenuOption(activeUser, Permission.HandlePermissionSystem, 1, "Handle the permission system (fine granularity)");
                ShowMenuOption(activeUser, Permission.AssignAdminsToRegions, 2, "Assign admins to certain regions");
                ShowMenuOption(activeUser, Permission.HandleRegistrations, 3, "Handle registrations");
                ShowMenuOption(activeUser, Permission.AddLocations, 4, "Add new locations");
                ShowMenuOption(activeUser, Permission.CreatePersonnelAccounts, 5, "Create accounts for personnel");
                ShowMenuOption(activeUser, Permission.ViewPermissionOverview, 6, "View who has permission to what");
                ShowMenuOption(activeUser, Permission.AcceptPatientRegistrations, 7, "Accept user registration as patients");
                ShowMenuOption(activeUser, Permission.DenyPatientRegistrations, 8, "Deny user registration as patients");

                Console.WriteLine("0) Logout");

                Console.Write("\nSelect an option: ");
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Opening Permission System...");
                        Permissions.ManagePermissions(activeUser);
                        break;

                    case "2":
                        Console.WriteLine("Assigning Admins to Regions...");
                        // Permissions.AssignAdminToRegion(activeUser);
                        break;

                    case "3":
                        Console.WriteLine("Handling Registrations...");
                        // Permissions.HandleRegistrations(activeUser);
                        break;

                    case "4":
                        Console.WriteLine("Adding new Location...");
                        // Permissions.AddLocation(activeUser);
                        break;

                    case "5":
                        Console.WriteLine("Creating Personnel Account...");
                        // Permissions.CreatePersonnel(activeUser);
                        break;

                    case "6":
                        Console.WriteLine("Viewing Permission Overview...");
                        // Permissions.ShowOverview(activeUser);
                        break;

                    case "7":
                        Console.WriteLine("Accepting Patient Registration...");
                        // Permissions.AcceptRegistration(activeUser);
                        break;

                    case "8":
                        Console.WriteLine("Denying Patient Registration...");
                        // Permissions.DenyRegistration(activeUser);
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
            else if (activeUser.UserRole == Role.Patient)
            {

            }
            if (running)
            {
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}