using UnityEngine;

public class Sickle : MonoBehaviour
{
    [SerializeField] private int level = 1;
    [SerializeField] private float InitDistance = 1;
    public int Level => level;

    public float Distance => InitDistance + level * DataBase.AdditionalDistancePerLevel;

    public void LevelUp(int value)
    {
        level += value;
    }
}