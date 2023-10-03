using Cysharp.Threading.Tasks;

public interface IGameManagementService
{
    public int StartCountdownSec { get; }
    public void StartGame();
    public void GameOver();
    public UniTask Retry();
}