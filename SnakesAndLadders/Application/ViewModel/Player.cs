namespace Application.ViewModel
{
    public class Player
    {
        public int Id { get; set; }
        public int Position { get; set; }

        public Player(int id)
        {
            Id = id;
            Position = 0;
        }
    }
}