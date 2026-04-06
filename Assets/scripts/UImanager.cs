using UnityEngine;
using TMPro;

// esta clase se encarga de actualizar la ui (pantalla)
public class UIManager : MonoBehaviour
{
    // referencia al texto donde se muestra el resultado (ganaste, perdiste, etc)
    public TextMeshProUGUI textoResultado;

    // referencia al texto donde se muestra la puntuacion
    public TextMeshProUGUI textoPuntuacion;

    public TextMeshProUGUI textoHistorial;

    // se ejecuta automaticamente cuando el objeto se activa
    private void OnEnable()
    {
        // nos suscribimos al evento del gamemanager
        // cada vez que termina una ronda, se llamara actualizarpantalla
        GameManager.OnRondaTerminada += ActualizarPantalla;
    }

    // se ejecuta cuando el objeto se desactiva
    private void OnDisable()
    {
        // nos desuscribimos del evento para evitar errores o duplicaciones
        GameManager.OnRondaTerminada -= ActualizarPantalla;
    }

    // este metodo recibe los datos del resultado de la ronda
    private void ActualizarPantalla(string res, int w, int l, int d)
    {
        // muestra el resultado (ej: "ganaste", "perdiste")
        textoResultado.text = res;

        // muestra la puntuacion con victorias, derrotas y empates
        textoPuntuacion.text = $"victorias: {w} | derrotas: {l} | empates: {d}";
    }
}