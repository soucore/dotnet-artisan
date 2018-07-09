namespace Artisan.App.Core
{
    public class Command
    {
        public string Name { get; }
        public string NameClass { get; private set; }
        public string NameInterface { get; private set; }

        public Command(string name)
        {
            Name = name;
            SetAttributes();
        }

        private void SetAttributes()
        {
            NameClass = Name.Substring(0, 1).ToUpper() + Name.Substring(1);
            NameInterface = $"I{NameClass}";
        }
    }
}