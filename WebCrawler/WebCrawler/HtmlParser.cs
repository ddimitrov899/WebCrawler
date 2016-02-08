namespace WebCrawler
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class HtmlParser
    {
        private const string patternImage = "<img.+src=\"(.+?)\".*>";
        private const string patternAnchorTag = "<a.+href=\"(.+?)\".*>";
        private Regex imageRegex;
        private Regex anchorTagRegex;
        public HtmlParser()
        {
            this.imageRegex = new Regex(patternImage);
            this.anchorTagRegex = new Regex(patternAnchorTag);
        }


        public List<string> ParseImageTags(string html)
        {
            MatchCollection match = this.imageRegex.Matches(html);
            return match.Cast<Match>()
                .Select(m => m.Groups[1].Value)
                .ToList();
        }

        public List<string> ParseAnchorTag(string html)
        {
            MatchCollection match = this.anchorTagRegex.Matches(html);
            return match.Cast<Match>().Select(m => m.Groups[1].Value).ToList();
        }
    }
}
