using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 30f;
    public float radius = 5f;
    public Vector3 rotationAxis = Vector3.up;

    void Update()
    {
        if (!player)
            player = GameObject.FindGameObjectWithTag("Player").transform;
        //// Nesneyi yeni pozisyona taþý
        transform.position = player.position;

        // Nesneyi döndür
        //transform.RotateAround(player.position, rotationAxis, rotationSpeed * Time.deltaTime);
        transform.Rotate(0, 0, transform.rotation.z + rotationSpeed * Time.deltaTime);
    }
}
