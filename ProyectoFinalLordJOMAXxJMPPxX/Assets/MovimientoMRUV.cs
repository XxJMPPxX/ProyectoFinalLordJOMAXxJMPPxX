using UnityEngine;

public class MRUVHorizontal : MonoBehaviour
{
    public float velocidadInicial = 5f; // Velocidad inicial en unidades de espacio por segundo
    public float aceleracion = 2f; // Aceleración constante en unidades de espacio por segundo al cuadrado

    private float velocidad; // Velocidad actual
    private float posicion; // Posición actual

    void Start()
    {
        // Inicializa la velocidad con la velocidad inicial
        velocidad = velocidadInicial;
        // Inicializa la posición en la posición actual del objeto
        posicion = transform.position.x;
    }

    void Update()
    {
        // Actualiza la velocidad usando la ecuación del MRUV: v = u + at
        velocidad += aceleracion * Time.deltaTime;

        // Actualiza la posición usando la ecuación del MRUV: x = x0 + v0t + 0.5at^2
        posicion += velocidadInicial * Time.deltaTime + 0.5f * aceleracion * Mathf.Pow(Time.deltaTime, 2);

        // Mueve el objeto a la nueva posición
        transform.position = new Vector3(posicion, transform.position.y, transform.position.z);
    }
}
