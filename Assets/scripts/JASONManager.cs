using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class JSONManager : MonoBehaviour
{
    private string rutaArchivo;

    // Ahora usamos lista de partidas
    public ListaPartidas baseDatos = new ListaPartidas();

    void Awake()
    {
        rutaArchivo = Application.persistentDataPath + "/partidas.json";
        Cargar();
    }

    // 💾 Guardar UNA partida nueva (no sobrescribe)
    public void GuardarPartida(int w, int l, int e)
    {
        Partida nueva = new Partida();
        nueva.fecha = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        nueva.victorias = w;
        nueva.derrotas = l;
        nueva.empates = e;

        baseDatos.partidas.Add(nueva);

        string json = JsonUtility.ToJson(baseDatos, true);
        File.WriteAllText(rutaArchivo, json);

        Debug.Log("💾 Partida guardada correctamente");
    }

    // 📂 Cargar todas las partidas
    public void Cargar()
    {
        if (File.Exists(rutaArchivo))
        {
            string contenido = File.ReadAllText(rutaArchivo);

            if (!string.IsNullOrEmpty(contenido))
            {
                baseDatos = JsonUtility.FromJson<ListaPartidas>(contenido);
                Debug.Log("📂 Partidas cargadas: " + baseDatos.partidas.Count);
            }
        }
        else
        {
            baseDatos = new ListaPartidas();
            Debug.Log("🆕 No hay archivo, creando base nueva");
        }
    }
}