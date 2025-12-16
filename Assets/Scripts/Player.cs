using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player local = null;
    [SerializeField] private Character myCharacter;
    public Character character => myCharacter;
    [SerializeField] private int redCoins = 0;
    public int RedCoins
    {
        get => redCoins;
        set => redCoins = value;
    }
    [SerializeField] private int yellowCoins = 0;
    public int YellowCoins
    {
        get => yellowCoins;
        set => yellowCoins = value;
    }
    private void Awake()
    {
        local = this; 
    }
    public void Move(Vector3 direct)
    { 
        if (direct.magnitude == 0) return;

        character.characterController.Move(direct * character.Speed * Time.deltaTime);

        character.transform.forward = direct;
    }
    private void Update()
    {
        character.characterController.Move(9.8f * Vector3.down * Time.deltaTime);
    }
}