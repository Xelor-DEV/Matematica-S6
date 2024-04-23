using UnityEngine;
using TMPro;
public class UIManagerController : MonoBehaviour
{
    [SerializeField] private TMP_Text textoVida;
    [SerializeField] private TMP_Text textoPuntos;
    [SerializeField] private GameObject deadScreen;
    [SerializeField] private PlayerController player;
    private void OnDisable()
    {
        player.lifeChanged -= ActualizarUIVida;
        player.isDied -= ShowDeadScreen;
    }
    public void ActualizarUIVida(int vida_actual)
    {
        textoVida.text = "Vida: " + vida_actual;
    }
    public void ActualizarUIPuntos(int puntos_actuales)
    {
        textoPuntos.text = "Puntos: " + puntos_actuales;
    }
    public void ShowDeadScreen()
    {
        deadScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
