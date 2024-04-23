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
    public int Damage
    {
        get
        {
            return damage;
        }
    }
    private Vector3 playerPosition;
    private Vector3 direction;
    [SerializeField] private float speed;
    [Header("Rotation Elements")]
    [SerializeField] private float rotationSpeed;
    private Vector3 angulos;
    private Quaternion qy = Quaternion.identity;
    private Quaternion r = Quaternion.identity;
    private float anguloSen;
    private float anguloCos;
    void Start()
    {
        playerPosition = player.transform.position;
        _compRigidbody = GetComponent<Rigidbody>();
        direction = (playerPosition - transform.position).normalized;
    }
    private void FixedUpdate()
    {
        _compRigidbody.velocity = direction * speed;

        angulos.y = angulos.y - (rotationSpeed * Time.deltaTime);
        angulos.y = angulos.y - 360 * Mathf.Floor(angulos.y / 360);

        anguloSen = Mathf.Sin((Mathf.PI / 180) * angulos.y * 1 / 2);
        anguloCos = Mathf.Cos((Mathf.PI / 180) * angulos.y * 1 / 2);
        qy.Set(0, anguloSen, 0, anguloCos);

        r = qy * Quaternion.identity * Quaternion.identity;
        transform.rotation = r;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Eliminator")
        {
            Destroy(this.gameObject);
        }
    }
}