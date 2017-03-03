using System;
using System.Data;
using System.Data.SqlClient;

namespace HMHY.Droid
{
    public static class LoginPage
    {
        public static bool getUserCredentials(string username)
        {
            bool privledge = false;
            DataTable table = new DataTable("UserCredentials");
            DataRow[] rows;
            rows = table.Select(username);
            if (rows != null)
            {
                Boolean.TryParse(rows[2].ToString(), out privledge);
            }
            return privledge;
        }

        public static UserEventInfo addNewGoal(string titleA, string descriptionA, DateTime startTimeA, DateTime endTimeA)
        {
            //string query = @"INSERT INTO Goals
            //Values(id, @title, @description, @startTime, @endTime, reminderId)";
            //SqlConnection connect = new SqlConnection("hmhy-global.database.windows.net");
            //SqlParameter @title = new SqlParameter(titleA, SqlDbType.VarChar);
            //SqlParameter @description = new SqlParameter(descriptionA, SqlDbType.VarChar);
            //SqlParameter @startTime = new SqlParameter("startTime", startTimeA);
            //SqlParameter @endTime = new SqlParameter("endTime", endTimeA);
            //SqlCommand cmd = new SqlCommand(query, connect);
            //SqlDataReader reader;
            //reader = cmd.ExecuteReader();
            //connect.Close();
            AndroidCalendar userCalendar = new AndroidCalendar();
            userCalendar.AddEvent("0", titleA, startTimeA, endTimeA,descriptionA);
            UserEventInfo info = new UserEventInfo();
            info.Id = "0";
            info.Title = titleA;
            info.StartDate = startTimeA;
            info.EndDate = endTimeA;

            return info;
        }
    }
}