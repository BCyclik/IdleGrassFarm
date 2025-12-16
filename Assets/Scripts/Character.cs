using UnityEngine.Events;
using UnityEngine;

[RequireComponent(typeof(Sickle))]
[RequireComponent(typeof(Inventory))]
[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{

    public CharacterController characterController => GetComponent<CharacterController>();
    public Inventory inventory => GetComponent<Inventory>();
    public Animator animator => GetComponent<Animator>();
    public Sickle sickle => GetComponent<Sickle>();
    [SerializeField] private int BaseSpeed = 3;
    public int Speed => BaseSpeed;
    private Vector3 boxSize => new Vector3(characterController.radius * distanceSickle, characterController.height, characterController.radius * distanceSickle);

    [SerializeField] private bool isMowing = false;
    private float timer = 0;
    private void Update()
    {
        PerformBoxCast();
    }
    private float distanceSickle => sickle.Distance;
    private float distance = 1;
    [SerializeField] private LayerMask grassLayer;
    private void PerformBoxCast() // эта функция должна быть в серпе
    {
        Vector3 forwardDirection = transform.forward;
        Vector3 startPoint = transform.position + characterController.center;

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
            isMowing = true;
            if (timer < sickle.Duration)
            {
                float t = timer / sickle.Duration;

                Quaternion startRotation = Quaternion.Euler(0, 0, -35);
                Quaternion endRotation = Quaternion.Euler(0, 0, 35);

                sickle.Obj.transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);

                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
                foreach (RaycastHit hit in hits)
                {
                    var grass = hit.collider.GetComponent<Grass>();
                    grass.Cut(this);
                }
            }
        }
        else
        {
            isMowing = false;
            timer = 0;
        }

        sickle.Obj.SetActive(isMowing);
    }

    private void OnDrawGizmos()
    {
        Vector3 startPoint = transform.position + characterController.center;

        Gizmos.color = isMowing ? Color.green : Color.red; // Меняем цвет в зависимости от состояния
        Gizmos.DrawRay(startPoint, transform.forward * distance);

        Vector3 hitPoint = startPoint + transform.forward * distance;
        Gizmos.DrawWireCube(hitPoint, boxSize);
    }
    public void LevelUp()
    {
        animator.SetTrigger("Win");
    }
    public void Wave()
    {
        animator.SetTrigger("Wave");
    }
}