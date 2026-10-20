using UnityEngine;

public class ControlPulpo : MonoBehaviour
{

    [SerializeField] private int velocidad;
    [SerializeField] private Vector3 posicionFin;
    private Vector3 posicionInicio;
    [SerializeField] bool moviendoAFin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicionInicio = transform.position;
        moviendoAFin = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculamos la posición de destino
        Vector3 posicionDestino = (moviendoAFin) ? posicionFin : posicionInicio;

        // Movemos el enemigo
        transform.position = Vector3.MoveTowards(transform.position, posicionDestino, velocidad * Time.deltaTime);

        // Cambio de dirección
        float distanciaMinima = 0.01f;
        if (Vector3.Distance(transform.position, posicionFin) < distanciaMinima)
            moviendoAFin = false;
        if (Vector3.Distance(transform.position, posicionInicio) < distanciaMinima)
            moviendoAFin = true;
    }
}
