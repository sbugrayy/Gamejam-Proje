using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 50f; // D�nd�rme h�z�

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        //transform.Rotate(Vector3.negativeInfinity * rotationSpeed * Time.deltaTime);
    }
}
