using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El objeto a seguir

    public float smoothing = 5f; // La velocidad a la que la cámara seguirá al objeto

    public Vector3 offset = new Vector3(0f, 0f, -10f); // La posición relativa de la cámara al objeto

    public float minX; // La posición mínima en x para la cámara

    private void Start()
    {
        minX = transform.position.x; // Establecer la posición mínima en x al inicio
    }

    private void LateUpdate()
    {

        minX = transform.position.x; // Establecer la posición mínima en x al inicio

        // Establecer la posición de la cámara
        Vector3 targetPosition = target.position + offset;
        targetPosition.y = transform.position.y; // No se desplaza hacia arriba en el eje y
        targetPosition.z = offset.z; // Mantener la misma posición z relativa

        // Limitar la posición en x de la cámara
        if (targetPosition.x < minX)
        {
            targetPosition.x = minX;
        }

        // Suavizar el movimiento de la cámara
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }
}
