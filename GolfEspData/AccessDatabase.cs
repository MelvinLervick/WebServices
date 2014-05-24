namespace GolfEspData
{
    public class AccessDatabase : Database
    {
        /// <summary>
        ///////////////////////////////////////////////////////////////////////
        /// AccessDatabase.cs - Contains all database access functions for MS Access
        /// Copyright (c) 2014, golfESP
        /// Created for .NET by Melvin Lervick 
        ///////////////////////////////////////////////////////////////////////
        /// </summary>
        public AccessDatabase( string provider, string dsn )
        {
            var strConnection = provider + dsn;
            OpenConnection( strConnection );
        }
    }
}