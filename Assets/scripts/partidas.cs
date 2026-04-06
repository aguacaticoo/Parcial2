using System;
using System.Collections.Generic;

// Representa UNA partida guardada
[System.Serializable]
public class Partida
{
    public string fecha;
    public int victorias;
    public int derrotas;
    public int empates;
}

// Contenedor para MUCHAS partidas (necesario para JSON en Unity)
[System.Serializable]
public class ListaPartidas
{
    public List<Partida> partidas = new List<Partida>();
}