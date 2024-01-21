namespace RPG_Game_Test.Models
{
    public class Character
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = "Nuno";
        
        public int Health { get; set; }

        public int Defense { get; set; }

        public int Strength { get; set; }

        public int Intelligence { get; set; }

        public RPGClass Class { get; set; }
    }
}
