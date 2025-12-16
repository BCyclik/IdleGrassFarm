using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
public class Sickle : MonoBehaviour
{
    public UnityEvent EventChangeLevel = new();

    [SerializeField] private GameObject obj;
    public GameObject Obj => obj;
    [SerializeField] private int level = 1;
    public int Level => level;
    public float Duration => DataBase.BaseDurationSickle - DataBase.AdditionalSpeedSicklePerLevel * level;
    public float Distance => DataBase.BaseDistanceSickle + level * DataBase.AdditionalDistancePerLevel;

    public void LevelUp(int value)
    {
        level += value;
        EventChangeLevel?.Invoke();

    }
}