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
    public int Damage
    {
        get
        {
            return damage;
        }
    }
    private Rigidbody _compRigidbody;
    [SerializeField] private int damage;
    private Vector3 playerPosition;
    private Vector3 direction;
    [SerializeField] private float speed;
    [Header("Rotation Elements")]
    [SerializeField] private float rotationSpeed;
    private Vector3 angulos;
    private Quaternion qy = Quaternion.identity;
    private Quaternion qz = Quaternion.identity;
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

        angulos.z = angulos.z - (rotationSpeed * Time.deltaTime);
        angulos.z = angulos.z - 360 * Mathf.Floor(angulos.z / 360);

        anguloSen = Mathf.Sin((Mathf.PI / 180) * angulos.z * 1 / 2);
        anguloCos = Mathf.Cos((Mathf.PI / 180) * angulos.z * 1 / 2);
        qz.Set(0, 0, anguloSen, anguloCos);

        r = qy * Quaternion.identity * qz;
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