namespace BossAz
{
    public class Skill
    {
        public Skill(string? skillName)
        {
            SkillName = skillName;
        }

        public string? SkillName { get; set; } = "No skill";
    }
}