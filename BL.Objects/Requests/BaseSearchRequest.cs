namespace BL.Objects.Requests
{
    public abstract class BaseSearchRequest
    {
        public int SearchType { get; set; }
        public int Skip { get; set; }
        public int Top { get; set; }
        public abstract object ToDbRequest(int? searchType = null);
    }
}
