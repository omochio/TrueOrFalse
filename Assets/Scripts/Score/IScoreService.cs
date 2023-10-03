using Cysharp.Threading.Tasks;

public interface IScoreService
{
    public int Score { get; set; }
    public int HighScore { get; }
    public UniTask UpdateHighScore();
}