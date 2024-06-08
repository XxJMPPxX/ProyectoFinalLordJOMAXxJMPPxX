using UnityEngine;

public class MRUVHorizontal : MonoBehaviour
{
    public float velocidadInicial = 5f; // Velocidad inicial en unidades de espacio por segundo
    public float aceleracion = 2f; // Aceleraci�n constante en unidades de espacio por segundo al cuadrado

    private float velocidad; // Velocidad actual
    private float posicion; // Posici�n actual

    void Start()
    {
        // Inicializa la velocidad con la velocidad inicial
        velocidad = velocidadInicial;
        // Inicializa la posici�n en la posici�n actual del objeto
        posicion = transform.position.x;
    }

    void Update()
    {
        // Actualiza la velocidad usando la ecuaci�n del MRUV: v = u + at
        velocidad += aceleracion * Time.deltaTime;

        // Actualiza la posici�n usando la ecuaci�n del MRUV: x = x0 + v0t + 0.5at^2
        posicion += velocidadInicial * Time.deltaTime + 0.5f * aceleracion * Mathf.Pow(Time.deltaTime, 2);

        // Mueve el objeto a la nueva posici�n
        transform.position = new Vector3(posicion, transform.position.y, transform.position.z);
    }
}
