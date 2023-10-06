using UnityEngine;
using TrueOrFalse.GameState;

[CreateAssetMenu(menuName = "ScriptableObject/SceneInformation")]
public class SceneInformation : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeField]
    GameState _initState;

    [System.NonSerialized]
    public GameState InitState;

    public void OnAfterDeserialize()
    {
        InitState = _initState;
    }

    public void OnBeforeSerialize() { }
}