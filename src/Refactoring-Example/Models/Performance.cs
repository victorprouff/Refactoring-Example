namespace Refactoring_Example.Models
{
    public class Performance
    {
        public Performance(string playId, int audience)
        {
            PlayId = playId;
            Audience = audience;
        }
        
        public string PlayId { get; }
        public int Audience { get; }
    }
}