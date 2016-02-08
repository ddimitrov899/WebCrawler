namespace WebCrawler.Views.GetCurentName
{
    class GetAnchorNameTags
    {
        private string anchorNameTag;
        public GetAnchorNameTags(string anchorNameTag)
        {
            this.AnchorNameTag = GetAnchorName(anchorNameTag);
        }

        public string AnchorNameTag { get; set; }

        private string GetAnchorName(string anchorNameTag)
        {
            string[] name = anchorNameTag.Split('/');
            return name[name.Length - 1];
        }
    }
}
