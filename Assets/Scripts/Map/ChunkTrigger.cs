using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    MapController mc;
    public GameObject targetMap;

    void Start()
    {
        mc = Object.FindFirstObjectByType<MapController>();

        // targetMap otomatik olarak parent GameObject'e atanýyor
        if (targetMap == null)
        {
            targetMap = transform.parent != null ? transform.parent.gameObject : gameObject;
        }
    }


    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player") && targetMap != null)
        {
            if (mc.currentChunk == null ||
                Vector3.Distance(col.transform.position, targetMap.transform.position) <
                Vector3.Distance(col.transform.position, mc.currentChunk.transform.position))
            {
                mc.currentChunk = targetMap;
            }
        }
    }


    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (mc.currentChunk == targetMap)
            {
                mc.currentChunk = null;
            }
        }
    }
}
