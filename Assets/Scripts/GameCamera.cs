using UnityEngine;

public class GameCamera : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private Vector3 Offset = new(0, 10, -10);
    private void Update()
    {
        transform.position = Target.position + Offset;
    }
}