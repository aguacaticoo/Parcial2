using UnityEngine;

public class GameManager : MonoBehaviour
{
    private JugadorHumano jugador = new JugadorHumano();
    private Computadora pc = new Computadora();

    private int wins = 0, draws = 0, losses = 0;

    [SerializeField] private JSONManager jsonDB;

    public delegate void ActualizarUI(string mensaje, int w, int l, int d);
    public static event ActualizarUI OnRondaTerminada;

    void Awake()
    {
        if (jsonDB == null)
        {
            jsonDB = FindFirstObjectByType<JSONManager>();
        }
    }

    void Start()
    {
        OnRondaTerminada?.Invoke("Nueva partida", wins, losses, draws);
    }

    public void Jugar(int seleccionHumano)
    {
        jugador.ElegirMovimiento((Move)seleccionHumano);
        pc.ElegirMovimiento((Move)Random.Range(0, 3));

        EvaluarRonda();
    }

    private void EvaluarRonda()
    {
        Move j = jugador.MovimientoActual;
        Move c = pc.MovimientoActual;
        string msj = "";

        if (j == c)
        {
            draws++;
            msj = "Empate";
        }
        else if ((j == Move.Rock && c == Move.Scissors) ||
                 (j == Move.Paper && c == Move.Rock) ||
                 (j == Move.Scissors && c == Move.Paper))
        {
            wins++;
            msj = "Ganaste";
        }
        else
        {
            losses++;
            msj = "Perdiste";
        }

        string resultadoFinal = $"Tú: {j} | CPU: {c}\n{msj}";
        OnRondaTerminada?.Invoke(resultadoFinal, wins, losses, draws);
    }

    // 💾 BOTÓN GUARDAR
    public void GuardarPartidaManual()
    {
        Debug.Log("🔥 BOTON FUNCIONA");

        if (jsonDB != null)
        {
            jsonDB.GuardarPartida(wins, losses, draws);
        }
        else
        {
            Debug.LogError("❌ JSONManager no encontrado");
        }
    }

    public void ReiniciarJuego()
    {
        wins = 0;
        losses = 0;
        draws = 0;

        OnRondaTerminada?.Invoke("Nueva partida", wins, losses, draws);
    }

    public void MostrarTop10()
    {
        Debug.Log("=== HISTORIAL DE PARTIDAS ===");

        if (jsonDB != null)
        {
            foreach (var partida in jsonDB.baseDatos.partidas)
            {
                Debug.Log($"{partida.fecha} | W:{partida.victorias} L:{partida.derrotas} D:{partida.empates}");
            }
        }
    }
}