using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;
using TNRD;
using TrueOrFalse.GameState;

public class GameplayInputProvider : MonoBehaviour, IGameplayInputProvider, DefaultInputAction.IGameplayActions, IDisposable
{
    [SerializeField]
    SerializableInterface<IGameStateManager> _gameStateMgr;
    IGameStateManager GameStateMgr => _gameStateMgr.Value;

    DefaultInputAction _iptAction;

    ReactiveProperty<bool> _isTrueInvokedRP = new();
    public bool IsTrueInvoked
    {
        get => _isTrueInvokedRP.Value;
        set => _isTrueInvokedRP.Value = value;
    }
    public IObservable<bool> IsTrueInvokedObservable => _isTrueInvokedRP;

    ReactiveProperty<bool> _isFalseInvokedRP = new();
    public bool IsFalseInvoked
    {
        get => _isFalseInvokedRP.Value;
        set => _isFalseInvokedRP.Value = value;
    }
    public IObservable<bool> IsFalseInvokedObservable => _isFalseInvokedRP;

    ReactiveProperty<bool> _isSkipInvokedRP = new();
    public bool IsSkipInvoked
    {
        get => _isSkipInvokedRP.Value;
        set => _isSkipInvokedRP.Value = value;
    }
    public IObservable<bool> IsSkipInvokedObservable => _isSkipInvokedRP;

    void Awake()
    {
        _iptAction = new DefaultInputAction();
        _iptAction.Gameplay.SetCallbacks(this);
    }

    void Start()
    {
        _isTrueInvokedRP.AddTo(this);
        _isFalseInvokedRP.AddTo(this);
        _isSkipInvokedRP.AddTo(this);

        //_isTrueInvokedRP.DoOnCompleted(() => {
        //    IsTrueInvoked = false;
        //    Debug.Log("Crean");
        //    });
        //_isFalseInvokedRP.DoOnCompleted(() => {
        //    IsFalseInvoked = false;
        //    Debug.Log("Crean");
        //});
        //_isSkipInvokedRP.DoOnCompleted(() => { 
        //    IsSkipInvoked = false; 
        //    Debug.Log("Crean"); 
        //});

        GameStateMgr.CurrentGameStateObservable
            .Where(state => state == GameState.Gameplay)
            .Subscribe(_ => _iptAction.Gameplay.Enable());
        GameStateMgr.CurrentGameStateObservable
            .Where(state => state != GameState.Gameplay)
            .Subscribe(_ => _iptAction.Gameplay.Disable());
    }

    void OnEnable()
    {
        _iptAction.Gameplay.Enable();
    }

    void OnDisable()
    {
        _iptAction.Gameplay.Disable();
    }

    public void Dispose()
    {
        _iptAction.Dispose();
    }

    void OnDestroy()
    {
        Dispose();    
    }

    public void OnTrue(InputAction.CallbackContext context)
    {
        if (context.performed)
            IsTrueInvoked = true;
    }

    public void OnFalse(InputAction.CallbackContext context)
    {
        if (context.performed)
            IsFalseInvoked = true;
    }

    public void OnSkip(InputAction.CallbackContext context)
    {
        if (context.performed)
            IsSkipInvoked = true;
    }
}