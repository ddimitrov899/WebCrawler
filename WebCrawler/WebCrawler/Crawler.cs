namespace WebCrawler
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using Views.GetAdress;
    using Views.GetCurentName;

    public class Crawler
    {
        private long id;
        private ConcurrentBag<string> downloadedImages;
        private ConcurrentBag<string> visitedUrls;
        public Crawler()
        {
            this.Parser = new HtmlParser();
            this.downloadedImages = new ConcurrentBag<string>();
            this.visitedUrls = new ConcurrentBag<string>();
            this.id = 0;
        }

        public HtmlParser Parser { get; set; }

        public void Craw(string url, int curentLevel, int maxLevel)
        {
            this.visitedUrls.Add(url);
            //Download HTML
            string html = string.Empty;

            using (var client = new WebClient())
            {
                html = client.DownloadString(url);
            }


            //Get all image tags (and their source URL)
            List<string> imgUrls = this.Parser.ParseImageTags(html);

            //Download all images from parsed tags
            Parallel.ForEach(imgUrls, (imgUrl, loopState) =>
            {
                using (var client = new WebClient())
                {
                    var imageName = new GetImageName(imgUrl);
                    var address = new ValidAddress(url, imgUrl);
                    if (!this.downloadedImages.Contains(address.GetAddress))
                    {
                        try
                        {
                            client.DownloadFile(address.GetAddress, "../../img/" + this.id + "" + imageName.Name);
                            id++;
                            this.downloadedImages.Add(address.GetAddress);
                        }
                        catch (WebException wex)
                        {
                            Console.WriteLine(wex.Message);
                        }
                    }


                }
            });
            if (curentLevel <= maxLevel)
            {
                //Get all anchor tag (and their source URL)
                List<string> anchorUrls = this.Parser.ParseAnchorTag(html);
                try
                {
                    foreach (var anchorUrl in anchorUrls)
                    {
                        //Recursion
                        var checkTag = new ValidAddress(url, anchorUrl);
                        curentLevel++;
                        if (!this.visitedUrls.Contains(checkTag.GetAddress)) ;
                        {
                            this.Craw(checkTag.GetAddress, curentLevel, maxLevel);
                        }
                    }
                }
                catch (WebException wex)
                {
                    Console.WriteLine(wex.Message);
                }

            }

        }
    }
}
