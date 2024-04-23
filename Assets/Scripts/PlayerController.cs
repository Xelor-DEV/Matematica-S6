using UnityEngine;
using System;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody _compRigidbody;
    [SerializeField] private UIManagerController uiManager;
    private Vector2 movementInput;
    private Quaternion qx = Quaternion.identity;
    private Quaternion qy = Quaternion.identity;
    private Quaternion qz = Quaternion.identity;
    private Quaternion r = Quaternion.identity;
    private float sinAngle;
    private float cosAngle;
    [SerializeField] private int life;
    public event Action<int> lifeChanged;
    public event Action isDied;
    public int Life
    {
        get
        {
            return life;
        }
        set
        {
            life = value;
            lifeChanged?.Invoke(life);
        }
    }
    private void Awake()
    {
        _compRigidbody = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        lifeChanged += uiManager.ActualizarUIVida;
        isDied += uiManager.ShowDeadScreen;
    }
    private void Start()
    {
        uiManager.ActualizarUIVida(life);
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>() * speed;
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementInput.x, movementInput.y, 0) * speed * Time.deltaTime;
        _compRigidbody.velocity = movement;

        if (movement != Vector3.zero)
        {
            if (movementInput.x != 0)
            {
                float zRotation;
                if (movementInput.x > 0)
                {
                    zRotation = -35;
                }
                else
                {
                    zRotation = 35;
                }
                sinAngle = Mathf.Sin((Mathf.PI / 180) * zRotation * 1 / 2);
                cosAngle = Mathf.Cos((Mathf.PI / 180) * zRotation * 1 / 2);
                qz.Set(0, 0, sinAngle, cosAngle);
            }
            else
            {
                qz = Quaternion.identity;
            }
            if (movementInput.y != 0)
            {
                float xRotation;
                if (movementInput.y > 0)
                {
                    xRotation = -35;
                }
                else
                {
                    xRotation = 35;
                }
                sinAngle = Mathf.Sin((Mathf.PI / 180) * xRotation * 1 / 2);
                cosAngle = Mathf.Cos((Mathf.PI / 180) * xRotation * 1 / 2);
                qx.Set(sinAngle, 0, 0, cosAngle);
            }
            else
            {
                qx = Quaternion.identity;
            }

            r = qx * qy * qz;
            transform.rotation = r;
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Asteroide")
        {
            AsteroideController asteroide = other.gameObject.GetComponent<AsteroideController>();
            if (life > 1)
            {
                Life = Life - asteroide.Damage;
                Destroy(other.gameObject);
            }
            else
            {
                isDied?.Invoke();
            }

        }
        else if (other.gameObject.tag == "Garbage")
        {
            GarbageController garbage = other.gameObject.GetComponent<GarbageController>();
            if (life > 1)
            {
                Life = Life - garbage.Damage;
                Destroy(other.gameObject);
            }
            else
            {
                isDied?.Invoke();
            }
        }
    }
}
