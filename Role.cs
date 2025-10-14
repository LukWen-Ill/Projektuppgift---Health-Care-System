using System.Security;
using System.Security.Cryptography.X509Certificates;
/*
        HandlePermissions,          // Tillåter att hantera andra användares rättigheter (ge/tar bort permissions)
        AssignAdminsToRegions,      // Kan tilldela admin-användare till specifika regioner
        HandleRegistrations,        // Kan godkänna/ neka patientregistreringar
        AddLocations,               // Tillåter att lägga till nya sjukhus/kliniker/platser i systemet
        CreatePersonnelAccounts,    // Tillåter att skapa konton för personal (läkare, sköterskor etc.)
        ViewPermissionsList,        // Kan se vilka användare har vilka rättigheter
        ViewPatientJournal,         // kan läsa patientjournaler
        ModifyJournalPermissions,   // Tillåter att sätta olika läsrättigheter på journaler
        RegisterAppointments,       // Tillåter att registrera nya patientbokningar
        ModifyAppointments,         // Tillåter att ändra eller uppdatera befintliga bokningar
        ApproveAppointments,        // Tillåter att godkänna patienters bokningsförfrågningar
        ViewSchedule     
        */
public class Role //detta är en klass som rapresenterar en roll på systemet, "Admin", "Patient" eller "Personnel"
{
    public string name;// namn på rollen ("patient, "Dr." eller "Ptient")
    public List<Permission> permissions;// vi skapar en lista med alla rättigheter som denna roll har. För exampel, en Admin kan ha Addlokation, Handle permission etc..

    public Role(string roleName)
    {
        n
    }
}