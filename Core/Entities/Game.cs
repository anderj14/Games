
namespace Core.Entities
{
    public class Game : BaseEntity
    {
        public string GameName { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Developer { get; set; }
        public DateTime RelaseDate { get; set; }
        public string GamePictureUrl { get; set; }
        
        public int GameConsoleId { get; set; }
        public GameConsole GameConsole { get; set; }
    }
}