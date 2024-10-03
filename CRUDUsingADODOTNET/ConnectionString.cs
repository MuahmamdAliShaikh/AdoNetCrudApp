namespace CRUDUsingADODOTNET
{
    public static class ConnectionString
    {
        private static string cs = "Data Source=ALISHAIKH;Database=CrudADOdb;Trusted_Connection=True;TrustServerCertificate=True;";
        public static string dbcs { get => cs; }
    }
}
