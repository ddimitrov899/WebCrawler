namespace WebCrawler
{
    using System;
    using System.Threading.Tasks;
    class WebCrawlerMain
    {
        private static Crawler crawler;
        private static void Main()
        {
            crawler = new Crawler();
            while (true)
            {
                string url = Console.ReadLine();
                if (url == String.Empty)
                {
                    throw new AggregateException("URL cannot be empty");
                }
                RunCrawl(url);
            }
        }

        static async void RunCrawl(string url)
        {
            await Task.Run(() =>
            {
                crawler.Craw(url, 0, 2);
            });
            Console.WriteLine("{0} has been complete.", url);
        }
    }
}
