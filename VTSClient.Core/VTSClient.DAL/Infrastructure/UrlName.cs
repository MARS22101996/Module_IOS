﻿namespace VTSClient.DAL.Infrastructure
{
    public class UrlName
    {
        public static string GetApiUrl()
        {
            const string hostUrl = "http://localhost:5000";

            const string vacationUrl = hostUrl + "/vts/workflow";

            return vacationUrl;
        }
    }
}
