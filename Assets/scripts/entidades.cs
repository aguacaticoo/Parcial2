using UnityEngine;

// define los 3 movimientos posibles del juego con su valor numerico
// rock=0, paper=1, scissors=2
public enum Move { Rock = 0, Paper = 1, Scissors = 2 }

// clase base abstracta: define la estructura que deben tener todos los jugadores
// no se puede instanciar directamente, solo sirve como plantilla
public abstract class JugadorBase
{
    // guarda el movimiento elegido en esta ronda
    // solo las clases hijas pueden modificarlo (protected set)
    public Move MovimientoActual { get; protected set; }

    // metodo obligatorio para las clases hijas: cada una lo implementa a su manera
    public abstract void ElegirMovimiento(Move mov);
}

// representa al jugador humano
public class JugadorHumano : JugadorBase
{
    // recibe el movimiento que eligio el jugador y lo guarda
    public override void ElegirMovimiento(Move mov)
    {
        MovimientoActual = mov;
    }
}

// representa a la computadora
public class Computadora : JugadorBase
{
    // ignora el parametro recibido y elige un movimiento al azar
    public override void ElegirMovimiento(Move mov)
    {
        MovimientoActual = (Move)Random.Range(0, 3);
    }
}