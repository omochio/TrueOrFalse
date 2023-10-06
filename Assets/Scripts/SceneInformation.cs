using UnityEngine;
using TrueOrFalse.GameState;

[CreateAssetMenu(menuName = "ScriptableObject/SceneInformation")]
public class SceneInformation : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField]
    GameState _initState;
    public GameState InitState
    {
        get => _initState;
        set => _initState = value;
    }

    public void OnAfterDeserialize()
    {
        InitState = _initState;
    }

    public void OnBeforeSerialize() { }
}