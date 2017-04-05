using System;

/// <summary>
/// This namespace will be used to house all business logic. UI specific logic should be placed in the individual UI projects. 
/// </summary>
namespace HMHY
{
    public class Core
    {
        public Core()
        {
            InitializeConnectionStrings();
        }

        #region Connection Names
        public string MainUserApiGetRequest;
        public string MainUserApiPutRequest;
        public string MainUserApiPostRequest;
        public string GoalApiGetRequest;
        public string GoalApiPutRequest;
        public string GoalApiPostRequest;
        public Uri ApiLocation;

        private void InitializeConnectionStrings()
        {
            ApiLocation = new Uri("http://ec2-54-67-67-41.us-west-1.compute.amazonaws.com/api/");
            MainUserApiGetRequest = "MainUser";
        }
        #endregion
    }


}

