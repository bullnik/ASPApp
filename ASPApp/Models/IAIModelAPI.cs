namespace ASPApp.Models
{
    public interface IAIModelAPI
    {
        public IEnumerable<DirectionSearchResult> GetDirections(string request);
        public IEnumerable<RequirementSearchResult> GetRequirements(string request);
    }
}
