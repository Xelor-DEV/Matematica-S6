using UnityEngine;

public class GarbageController : MonoBehaviour
{
    private PlayerController player;
    public PlayerController Player
    {
        get
        {
            return player;
        }
        set
        {
            player = value;
        }
    }
    private int damage;
    private Vector3 playerPosition;
    private Vector3 direction;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    private Rigidbody rb;
    void Start()
    {
        playerPosition = player.transform.position;
        rb = GetComponent<Rigidbody>();
        direction = (playerPosition - transform.position).normalized;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        rb.velocity = direction * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Eliminator")
        {
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            AttackPlayer();
            Destroy(this.gameObject);
        }
    }
    public void AttackPlayer()
    {
        player.Life = player.Life - damage;
    }
}