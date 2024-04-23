using UnityEngine;

public class AsteroideController : MonoBehaviour
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
    private Rigidbody _compRigidbody;
    [SerializeField] private int damage;
    private Vector3 playerPosition;
    private Vector3 direction;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    void Start()
    {
        playerPosition = player.transform.position;
        _compRigidbody = GetComponent<Rigidbody>();
        direction = (playerPosition - transform.position).normalized;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        _compRigidbody.velocity = direction * speed;
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
    protected void AttackPlayer()
    {
        player.Life = player.Life - damage;
    }
}