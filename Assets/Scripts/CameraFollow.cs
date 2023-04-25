using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // El objeto a seguir

    public float smoothing = 5f; // La velocidad a la que la c�mara seguir� al objeto

    public Vector3 offset = new Vector3(0f, 0f, -10f); // La posici�n relativa de la c�mara al objeto

    public float minX; // La posici�n m�nima en x para la c�mara

    private void Start()
    {
        minX = transform.position.x; // Establecer la posici�n m�nima en x al inicio
    }

    private void LateUpdate()
    {

        minX = transform.position.x; // Establecer la posici�n m�nima en x al inicio

        // Establecer la posici�n de la c�mara
        Vector3 targetPosition = target.position + offset;
        targetPosition.y = transform.position.y; // No se desplaza hacia arriba en el eje y
        targetPosition.z = offset.z; // Mantener la misma posici�n z relativa

        // Limitar la posici�n en x de la c�mara
        if (targetPosition.x < minX)
        {
            targetPosition.x = minX;
        }

        // Suavizar el movimiento de la c�mara
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }
}
