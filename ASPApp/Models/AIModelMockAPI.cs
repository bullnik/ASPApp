namespace ASPApp.Models
{
    public class AIModelMockAPI : IAIModelAPI
    {
        public IEnumerable<DirectionSearchResult> GetDirections(string request)
        {
            Thread.Sleep(1500);
            return new List<DirectionSearchResult>()
            {
                new(request, SkillType.Skill),
                new("Jiba2", SkillType.Knowledge),
                new("Jiba3", SkillType.Knowledge),
                new("Jiba4", SkillType.Skill),
                new("Jiba5", SkillType.Knowledge),
            };
        }

        public IEnumerable<RequirementSearchResult> GetRequirements(string request)
        {
            Thread.Sleep(1500);
            return new List<RequirementSearchResult>()
            {
                new(request, SkillType.Skill),
                new("Jiba2", SkillType.Skill),
                new("Jiba3", SkillType.Skill),
                new("Jiba4", SkillType.Skill),
                new("Jiba5", SkillType.Skill),
                new("Jiba6", SkillType.Skill),
                new("Jiba7", SkillType.Skill),
                new("Jiba8", SkillType.Knowledge),
                new("Jiba9", SkillType.Knowledge),
                new("Jiba0", SkillType.Knowledge),
                new("Jiba12", SkillType.Knowledge),
                new("Jiba23", SkillType.Knowledge),
                new("Jiba443", SkillType.Knowledge),
            };
        }
    }
}
