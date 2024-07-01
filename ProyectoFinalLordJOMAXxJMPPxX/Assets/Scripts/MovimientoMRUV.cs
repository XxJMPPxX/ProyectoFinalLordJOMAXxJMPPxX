using UnityEngine;

public class MovimientoMRUV : MonoBehaviour
{
    public float velocidadInicial = 5f;
    public float aceleracion = 2f;
    private GameObject objetoDeDestruccion;

    private float velocidad;
    private Vector3 direccion;
    private float tiempoTranscurrido;

    void Start()
    {
        velocidad = velocidadInicial;
        direccion = Camera.main.transform.forward;
        tiempoTranscurrido = 0f;

        objetoDeDestruccion = GameObject.Find("VFX_Fire_01_Big_Smoke");
    }

    void Update()
    {
        tiempoTranscurrido += Time.deltaTime;
        velocidad = velocidadInicial + aceleracion * tiempoTranscurrido;
        Vector3 nuevaPosicion = transform.position + direccion * (velocidadInicial * Time.deltaTime + 0.5f * aceleracion * Mathf.Pow(Time.deltaTime, 2));
        transform.position = nuevaPosicion;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 posicion = transform.position;
        Quaternion rotacion = Quaternion.identity;
        Instantiate(objetoDeDestruccion, posicion, rotacion);
        Destroy(gameObject);
    }
}
