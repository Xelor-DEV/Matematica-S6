using UnityEngine;
using TMPro;
public class UIManagerController : MonoBehaviour
{
    [SerializeField] private TMP_Text textoVida;
    [SerializeField] private TMP_Text textoPuntos;
    [SerializeField] private PlayerController jugador;
    private void OnDisable()
    {
        jugador.lifeChanged -= ActualizarUIVida;
    }
    public void ActualizarUIVida(int vida_actual)
    {
        textoVida.text = "Vida: " + vida_actual;
    }
}
