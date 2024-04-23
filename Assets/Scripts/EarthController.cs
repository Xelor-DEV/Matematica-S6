using UnityEngine;

public class EarthController : MonoBehaviour
{
    [SerializeField] private float velocidadDeRotacion;
    private Vector3 angulos;
    private Quaternion qx = Quaternion.identity;
    private Quaternion qy = Quaternion.identity;
    private Quaternion qz = Quaternion.identity;
    private Quaternion r = Quaternion.identity;
    private float anguloSen;
    private float anguloCos;
    private void FixedUpdate()
    {
        //Rotar x en base a la velocidad deseada
        angulos.x = angulos.x - (velocidadDeRotacion * Time.deltaTime);
        //Asegurarse de que el angulo x no sobrepase los 360 grados para evitar ir mas alla de los limites numericos de la variable
        //Se genera un loop
        angulos.x = angulos.x - 360 * Mathf.Floor(angulos.x / 360);
        anguloSen = Mathf.Sin((Mathf.PI / 180) * angulos.x * 1/2);
        anguloCos = Mathf.Cos((Mathf.PI / 180) * angulos.x * 1/2);
        qx.Set(anguloSen, 0, 0, anguloCos);
        anguloSen = Mathf.Sin((Mathf.PI / 180) * angulos.z * 1/2);
        anguloCos = Mathf.Cos((Mathf.PI / 180) * angulos.z * 1/2);
        qz.Set(0, 0, anguloSen, anguloCos);
        anguloSen = Mathf.Sin((Mathf.PI / 180) * angulos.y * 1/2);
        anguloCos = Mathf.Cos((Mathf.PI / 180) * angulos.y * 1/2);
        qy.Set(0, anguloSen, 0, anguloCos);
        r = qy * qx * qz;
        transform.rotation = r;
    }
}
