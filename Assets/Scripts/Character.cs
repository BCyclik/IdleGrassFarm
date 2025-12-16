using UnityEngine;

[RequireComponent(typeof(Sickle))]
[RequireComponent(typeof(Inventory))]
[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    public CharacterController characterController => GetComponent<CharacterController>();
    public Inventory inventory => GetComponent<Inventory>();
    public Sickle sickle => GetComponent<Sickle>();
    [SerializeField] private int BaseSpeed = 3;
    public int Speed => BaseSpeed;
    private Vector3 boxSize => new Vector3(characterController.radius * distanceSickle, characterController.height, characterController.radius * distanceSickle);

    private void Awake()
    {
    }
    [SerializeField] private bool isMowing = false;
    [SerializeField] private float Delay = 1;
    private float timer = 0;
    private void Update()
    {
        PerformBoxCast();
    }
    private float distanceSickle => sickle.Distance;
    private float distance = 1;
    [SerializeField] private LayerMask grassLayer;
    private void PerformBoxCast()
    {
        Vector3 forwardDirection = transform.forward;
        Vector3 startPoint = transform.position;

        var hits = Physics.BoxCastAll(
            startPoint,
            boxSize / 2,
            forwardDirection,
            transform.rotation,
            distance,
            grassLayer
        );

        if (hits.Length > 0)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                timer = Delay;
                foreach (RaycastHit hit in hits)
                {
                    var grass = hit.collider.GetComponent<Grass>();
                    grass.Cut(this);
                }
            }
        }
        else
        {
            timer = Delay;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = isMowing ? Color.green : Color.red; // Меняем цвет в зависимости от состояния
        Gizmos.DrawRay(transform.position, transform.forward * distance);

        Vector3 hitPoint = transform.position + transform.forward * distance;
        Gizmos.DrawWireCube(hitPoint, boxSize);
    }
}