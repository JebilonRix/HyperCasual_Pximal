using UnityEngine;

public class CharacterState : MonoBehaviour
{
    private static CharacterState instance;
    [SerializeField] private CharState _state = CharState.None;

    public static CharacterState Instance { get => instance; private set => instance = value; }
    public CharState States { get => _state; set => _state = value; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        States = CharState.None;
    }
}
public enum CharState
{
    None,
    Finish
}