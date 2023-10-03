using System;
using UnityEngine;
using UnityEngine.InputSystem;
using omochio.Utility;

public class GameplayInputHandler : MonoBehaviour, DefaultInputAction.IGameplayActions, IDisposable
{
    IQuestionService _questionSvc;
    DefaultInputAction _iptAction;

    void Awake()
    {
        _questionSvc = this.FindObjectOfInterface<IQuestionService>();
        if (_questionSvc == null) Debug.LogError("QuestionService not found");
        _iptAction = new DefaultInputAction();
        _iptAction.Gameplay.SetCallbacks(this);
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
            _questionSvc.Answer(true);
    }

    public void OnFalse(InputAction.CallbackContext context)
    {
        if (context.performed)
            _questionSvc.Answer(false);
    }

    public void OnSkip(InputAction.CallbackContext context)
    {
        if (context.performed)
            _questionSvc.Skip();
    }
}