using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace App;

class RoleMenuService
{
    public static void ShowMenu(User user)
    {
        switch (user.UserRole)
        {
            case Role.Admin:
                Console.Write("permissions: ");

                Console.WriteLine("Handle the permission system, in fine granularity");
                ShowMenu2(user);
                break;

            case Role.Staff:
                ShowMenu2(user);
                break;

            case Role.Patient:
                ShowMenu2(user,);
                break;
        }
    }

    public static void ShowMenu2(User admin,)
    {
        Console.Clear();
        Console.WriteLine($"You are logged in as {admin.Username} ({User.Role.Admin})");
        Console.WriteLine("=== Admin Menu ===");
        Console.WriteLine("1) View all users");
        Console.WriteLine("2) Approve patient registrations");
        Console.WriteLine("3) Create staff account");
        Console.WriteLine("4) Logout");
        Console.Write("Select an option: ");
        var input = Console.ReadLine();

        switch (input)
        {
            case "1":
                foreach (var user in users)
                    Console.WriteLine($"- {user.Id}: {user.Username} ({user.UserRole})");
                break;
            case "2":
                Console.WriteLine("Approving patient registrations...");
                break;
            case "3":
                Console.WriteLine("Creating staff account...");
                break;
            case "4":
                EventLog.Eventlogger(admin, EventLog.EventType.UserLogout);
                Program.active_user = null;
                return;
            default:
                Console.WriteLine("Invalid option");
                break;
        }
        Pause();
    }

    private void ShowStaffMenu(User staff)
    {
        Console.Clear();
        Console.WriteLine($"You are logged in as {staff.Username} ({User.Role.Staff})");
        Console.WriteLine("=== Staff Menu ===");
        Console.WriteLine("1) View Patient Journal");
        Console.WriteLine("2) Register appointment");
        Console.WriteLine("3) View schedule");
        Console.WriteLine("4) Logout");
        Console.Write("Select an option: ");
        var input = Console.ReadLine();

        switch (input)
        {
            case "1": Console.WriteLine("Opening patient journal..."); break;
            case "2": Console.WriteLine("Registering appointment..."); break;
            case "3": Console.WriteLine("Showing schedule..."); break;
            case "4":
                EventLog.Eventlogger(staff, EventLog.EventType.UserLogout);
                Program.active_user = null;
                return;
        }
        Pause();
    }

    private void ShowUserMenu(User user)
    {
        Console.Clear();
        Console.WriteLine($"You are logged in as {user.Username} ({User.Role.User})");
        Console.WriteLine("=== User Menu ===");
        Console.WriteLine("1) Request patient registration");
        Console.WriteLine("2) Logout");
        var input = Console.ReadLine();

        switch (input)
        {
            case "1":
                Console.WriteLine("Registration request sent...");
                EventLog.Eventlogger(user, EventLog.EventType.RegistrationRequested);
                break;
            case "2":
                EventLog.Eventlogger(user, EventLog.EventType.UserLogout);
                Program.active_user = null;
                return;
        }
        Pause();
    }

    private void ShowPatientMenu(User patient)
    {
        Console.Clear();
        Console.WriteLine($"You are logged in as {patient.Username} ({User.Role.Patient})");
        Console.WriteLine("=== Patient Menu ===");
        Console.WriteLine("1) View Appointments");
        Console.WriteLine("2) Logout");
        var input = Console.ReadLine();

        switch (input)
        {
            case "1":
                Console.WriteLine("Listing your appointments...");
                break;
            case "2":
                EventLog.Eventlogger(patient, EventLog.EventType.UserLogout);
                Program.active_user = null;
                return;
        }
        Pause();
    }

    private void Pause()
    {
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}
}