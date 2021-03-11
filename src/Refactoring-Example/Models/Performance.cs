namespace Refactoring_Example.Models
{
    public class Performance
    {
        public Performance(Play play, int audience)
        {
            Play = play;
            Audience = audience;
        }

        public Play Play { get; }
        public int Audience { get; }
    }
}