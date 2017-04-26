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
using Android.Database;
using Android.Net;
using Android.Database.Sqlite;


namespace HMHY.Droid
{
    class DBContentViewer : ContentProvider
    {
        public const string AUTHORITY = "com.xamarin.sample.DBContentViewer";
        static string BASE_PATH = "Goals";
        public static readonly Android.Net.Uri CONTENT_URI = Android.Net.Uri.Parse("content://" + AUTHORITY + "/" + BASE_PATH);

        // MIME types used for getting a list, or a single goal
        public const string GOALS_MIME_TYPE = ContentResolver.CursorDirBaseType + "/vnd.com.xamarin.sample.Goals";
        public const string GOAL_MIME_TYPE = ContentResolver.CursorItemBaseType + "/vnd.com.xamarin.sample.Goals";

        // Column names
        public new static class InterfaceConsts
        {
            public const string Id = "_id";
            public const string Name = "name";
        }

        DBHelper goalDB;

        public override bool OnCreate()
        {
            goalDB = new DBHelper(Context);
            return true;
        }

        const int GET_ALL = 0; // return code when a list of Vegetables is requested
        const int GET_ONE = 1; // return code when a single Vegetable is requested
        static UriMatcher uriMatcher = BuildUriMatcher();
        static UriMatcher BuildUriMatcher()
        {
            var matcher = new UriMatcher(UriMatcher.NoMatch);

            // to get data...
            matcher.AddURI(AUTHORITY, BASE_PATH, GET_ALL); // all goals
            matcher.AddURI(AUTHORITY, BASE_PATH + "/#", GET_ONE); // specific goal by numeric ID

            return matcher;
        }

        public override string GetType(Android.Net.Uri uri)
        {
            switch (uriMatcher.Match(uri))
            {
                case GET_ALL:
                    return GOALS_MIME_TYPE; // list
                case GET_ONE:
                    return GOAL_MIME_TYPE; // single item
                default:
                    throw new Java.Lang.IllegalArgumentException("Unknown Uri: " + uri);
            }
        }

        public override Android.Net.Uri Insert(Android.Net.Uri uri, ContentValues values)
        {
            throw new NotImplementedException();
        }

        public override int Delete(Android.Net.Uri uri, string selection, string[] selectionArgs)
        {
            throw new NotImplementedException();
        }

        public override ICursor Query(Android.Net.Uri uri, string[] projection, string selection, string[] selectionArgs, string sortOrder)
        {
            switch (uriMatcher.Match(uri))
            {
                case GET_ALL:
                    return GetFromDatabase();
                case GET_ONE:
                    //if (selectionArgs == null) {
                    //    throw new Java.Lang.IllegalArgumentException(
                    //      "selectionArgs must be provided for the Uri: " + uri);
                    //}
                    var id = uri.LastPathSegment;
                    return GetFromDatabase(id);
                //                return Search(selectionArgs[0]);
                default:
                    throw new Java.Lang.IllegalArgumentException("Unknown Uri: " + uri);
            }
        }

        Android.Database.ICursor GetFromDatabase()
        {
            return goalDB.ReadableDatabase.RawQuery("SELECT id, name FROM Goals", null);
        }

        Android.Database.ICursor GetFromDatabase(string id)
        {
            return goalDB.ReadableDatabase.RawQuery("SELECT id, name FROM Goals WHERE id = " + id, null);
        }

        public override int Update(Android.Net.Uri uri, ContentValues values, string selection, string[] selectionArgs)
        {
            throw new NotImplementedException();
        }
    }
}