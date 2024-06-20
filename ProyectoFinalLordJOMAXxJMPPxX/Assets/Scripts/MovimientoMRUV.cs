using UnityEngine;

public class MovimientoMRUV : MonoBehaviour
{
    public float velocidadInicial = 5f; 
    public float aceleracion = 2f; 

    private float velocidad; 
    private float posicion;

    void Start()
    {
        
        velocidad = velocidadInicial;
        posicion = transform.position.x;
    }

    void Update()
    {
        
        velocidad += aceleracion * Time.deltaTime;  
        posicion += velocidadInicial * Time.deltaTime + 0.5f * aceleracion * Mathf.Pow(Time.deltaTime, 2);
        transform.position = new Vector3(posicion, transform.position.y, transform.position.z);
    }
}
