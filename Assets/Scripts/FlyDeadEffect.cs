using Unity.VisualScripting;
using UnityEngine;

public class FlyDeadEffect : MonoBehaviour
{
    public Animator dyingEffect;

    private void Effect()
    {
        if (transform.IsDestroyed())
        {
            Instantiate(dyingEffect, transform.position, Quaternion.identity);
        }
    }
}
