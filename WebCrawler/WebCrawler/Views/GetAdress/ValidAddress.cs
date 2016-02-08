namespace WebCrawler.Views.GetAdress
{
    public class ValidAddress
    {
        //Get address of anchor tag and image and validate the path
        private string validAddress ;
        public ValidAddress(string url, string path)
        {
            this.GetAddress = this.GetValidAddress(url, path);
        }

        public string GetAddress { get; set; }
        private string GetValidAddress(string url, string path)
        {
            if (path.StartsWith("http"))
            {
                return path;
            }
            else
            {
                return string.Format("{0}/{1}", url, path);
            }
        }
    }
}
