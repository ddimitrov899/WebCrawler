namespace WebCrawler.Views.GetCurentName
{
    public class GetImageName
    {
        //Get image name
        private string imageName;

        public GetImageName(string imgUrl)
        {
            this.Name = ImageName(imgUrl);
        }

        public string Name { get; set; }
        public string ImageName(string imgUrl)
        {
            string[] imageName = imgUrl.Split('/');
            return imageName[imageName.Length - 1];
        }
    }
}
