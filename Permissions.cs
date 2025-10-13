namespace App;

class Permission
{
    public List<Permission> permissions = new List<Permission>();

}
public enum StaffPermission
{
    ViewPatientJournalEntries = 1,  // View a patient's journal entries
    MarkSensitiveEntries,           // Mark journal entries with IsSensitive = true/false
    ViewSensitiveEntries,           // Can view entries marked as sensitive

    RegisterAppointments,           // Register appointments
    ModifyAppointments,             // Modify appointments
    ApproveAppointmentRequests,     // Approve appointment requests
    ViewLocationSchedule,           // View the schedule of a location
}
public enum AdminPermission
{
    AcceptPatientRegistrations = 1, // Accept user registration as patients
    DenyPatientRegistrations,       // Deny user registration as patients
    HandleRegistrations,            // Handle registrations
    CreatePersonnelAccounts,        // Create accounts for personnel
    AddLocations,                   // Add locations
    AssignAdminsToRegions,          // Assign admins to certain regions
    ViewPermissionOverview,         // View a list of who has permission to what
    HandlePermissionSystem,         // Handle the permission system, in fine granularity
}