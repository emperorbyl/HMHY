using System;
using Android.Database.Sqlite;
using System.Data;

public static class LoginPage
{
    static bool getUserCredentials(string username)
    {
        bool privledge = false;
        DataTable table = new DataTable("UserCredentials");
        DataRow[] rows;
        rows = table.Select(username);
        if(rows != null)
        {
            Boolean.TryParse(rows[2].ToString(), out privledge);
        }
        return privledge;
    }

    static void addNewGoal()
    {
        
    }
}