using UnityEngine.Events;
using UnityEngine;

public class Player : MonoBehaviour
{
    public UnityEvent<int> EventChangeRedCoins = new();
    public UnityEvent<int> EventChangeYellowCoins = new();
    public static Player local = null;
    [SerializeField] private Character myCharacter;
    public Character character => myCharacter;
    [SerializeField] private int redCoins = 0;
    public int RedCoins
    {
        get => redCoins;
        set
        {
            redCoins = value;
            EventChangeRedCoins?.Invoke(redCoins);
        }
    }
    [SerializeField] private int yellowCoins = 0;
    public int YellowCoins
    {
        get => yellowCoins;
        set
        {
            yellowCoins = value;
            EventChangeYellowCoins?.Invoke(yellowCoins);
        }
    }
    private void OnEnable()
    {
        local = this;
    }
    public void Move(Vector3 direct)
    {
        character.animator.SetFloat("MoveSpeed", direct.magnitude); // лучше убрать в character
        if (direct.magnitude == 0) return;

        character.characterController.Move(direct * character.Speed * Time.deltaTime);

        character.transform.forward = direct;

    }
    private void Update()
    {
        character.characterController.Move(9.8f * Vector3.down * Time.deltaTime);
    }
}