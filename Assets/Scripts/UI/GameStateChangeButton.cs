using UnityEngine;
using UnityEngine.UI;
using TNRD;
using omochio.Utility;
using TrueOrFalse.GameState;

public class GameStateChangeButton : MonoBehaviour
{
    [SerializeField]
    GameState _nextState;

    [SerializeField]
    bool _isReload;

    Button _button;

    [SerializeField]
    SerializableInterface<IGameStateManager> _gameStateMgr;
    IGameStateManager GameStateMgr => _gameStateMgr.Value;

    void Awake()
    {
        this.TryGetComponentDebugError(out _button);
        _button.onClick.AddListener(() => 
        {
            if (_isReload)
            {
                GameStateMgr.SceneInfo.InitState = _nextState;
                GameStateMgr.Reload();
            }
            else
                GameStateMgr.CurrentGameState = _nextState;
        });
    }
}