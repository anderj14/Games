
namespace API.Dto
{
    public class GameDto
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Developer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string GamePictureUrl { get; set; }

        public string GameConsole { get; set; }
    }
}