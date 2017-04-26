using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Database.Sqlite;

namespace HMHY.Droid
{
    class DBHelper : SQLiteOpenHelper
    {
        
        new const string dbName = "HMHY.db";
        const int dbVersion = 1;

        public DBHelper(Context context) :base(context, dbName, null, dbVersion)
        {

        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            throw new NotImplementedException();
        }

        public override void OnCreate(SQLiteDatabase db)
        {
            
            // seed with data
            db.ExecSQL("INSERT INTO Goals (name) VALUES ('id')");
            db.ExecSQL("INSERT INTO Goals (name) VALUES ('title')");
            db.ExecSQL("INSERT INTO Goals (name) VALUES ('goalDescription')");
            db.ExecSQL("INSERT INTO Goals (name) VALUES ('StartTime')");
            db.ExecSQL("INSERT INTO Goals (name) VALUES ('EndTime')");
        }
    }
}