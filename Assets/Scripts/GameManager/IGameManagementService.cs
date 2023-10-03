using System.Threading;
using Cysharp.Threading.Tasks;

public interface IGameManagementService
{
    public int StartCountdownSec { get; }
    public int RemainTimeLimitSec { get; }
    public UniTask StartGame(CancellationToken token);
    public UniTask GameOver();
    public UniTask Retry();
}