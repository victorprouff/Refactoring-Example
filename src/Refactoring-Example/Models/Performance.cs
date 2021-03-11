namespace Refactoring_Example.Models
{
    public class Performance
    {
        public Performance(Play play, string playId, int audience)
        {
            Play = play;
            PlayId = playId;
            Audience = audience;
        }

        public Play Play { get; }
        public string PlayId { get; }
        public int Audience { get; }
    }
}