namespace VgsTiledMap.Ags
{
    using System;
    using System.Net;

    internal class KMLWebRequestStateObject
    {
        private System.Net.WebRequest webRequest;

        public KMLWebRequestStateObject(System.Net.WebRequest webRequest)
        {
            this.webRequest = webRequest;
        }

        public System.Net.WebRequest WebRequest
        {
            get
            {
                return this.webRequest;
            }
            set
            {
                this.webRequest = value;
            }
        }
    }
}

