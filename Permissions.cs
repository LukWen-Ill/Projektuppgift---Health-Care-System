namespace HealthCareSystem
//logg in, logg ut, kontroll av permission, roller, användare
// Enum för olika rättigheter (permissions)

/*

Role innehåller namn och permissions.

User har användarnamn, lösenord, roll, och inloggningsstatus.

SecurityManager hanterar login, logout, registrering, och permission-kontroll.
Skapar roller (Admin, Personnel, Patient) med förklarade permissions.

Skapar användare och tilldelar roller.

Registrerar användare i SecurityManager.

Loggar in användare och testar permissions.

Visar alla användare i systemet.//////////////////

Roller (Admin, Personnel, Patient)

Permissions (lista-baserade, med kommentarer)

Users

SecurityManager med login/logout och permission-check

journal, schedule och appointment

Test av funktionalitet
*/
{
    // Permissions som vanlig enum
    public enum Permission
    {
    HandlePermissions,          // Tillåter att hantera andra användares rättigheter (ge/tar bort permissions)
    AssignAdminsToRegions,      // Tillåter att tilldela admin-användare till specifika regioner
    HandleRegistrations,        // Tillåter att godkänna eller neka patientregistreringar
    AddLocations,               // Tillåter att lägga till nya sjukhus/kliniker/platser i systemet
    CreatePersonnelAccounts,    // Tillåter att skapa konton för personal (läkare, sköterskor etc.)
    ViewPermissionsList,        // Tillåter att se vilka användare har vilka rättigheter
    ViewPatientJournal,         // Tillåter att läsa patientjournaler
    ModifyJournalPermissions,   // Tillåter att sätta olika läsrättigheter på journaler
    RegisterAppointments,       // Tillåter att registrera nya patientbokningar
    ModifyAppointments,         // Tillåter att ändra eller uppdatera befintliga bokningar
    ApproveAppointments,        // Tillåter att godkänna patienters bokningsförfrågningar
    ViewSchedule                // Tillåter att se schemat för en plats/klinik
}