namespace ASPApp.Models
{
    public class RequirementSearchResult
    {
        public string Value => _value;

        public SkillType Type => _type;

        private readonly string _value;

        private readonly SkillType _type;

        public RequirementSearchResult(string value, SkillType skillType)
        {
            _value = value;
            _type = skillType;
        }
}
}
