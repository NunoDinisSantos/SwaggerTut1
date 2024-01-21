using System.Text.Json.Serialization;

namespace RPG_Game_Test.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RPGClass
    {
        Knight = 1,        
        Mage = 2,
        DarkCleric = 3
    }
}
