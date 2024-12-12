using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    public GameObject currentChunk;
    PlayerMovement pm;

    [Header("Optimization")]
    public List<GameObject> spawnedChunks;
    public GameObject latestChunk;
    public float maxOpDist;
    float opDist;
    float optimizerCooldown;
    public float optimizerCooldownDur;

    void Start()
    {
        pm = Object.FindFirstObjectByType<PlayerMovement>();
    }

    void Update()
    {
        ChunkChecker();
        ChunkOptimizer();
    }

    void ChunkChecker()
    {
        if (!currentChunk) return;

        // Chunk pozisyonlarýný bir dizi olarak tanýmla
        string[] directions = { "Right", "Left", "Up", "Down",
                            "Right Up", "Right Down",
                            "Left Up", "Left Down" };

        // Tüm yönleri kontrol et
        foreach (string dir in directions)
        {
            Transform checkPoint = currentChunk.transform.Find(dir);

            if (checkPoint != null &&
                !Physics2D.OverlapCircle(checkPoint.position, checkerRadius, terrainMask))
            {
                noTerrainPosition = checkPoint.position;
                SpawnChunk();
            }
        }

        /*
        if (!currentChunk)
        {
            return;
        }

        if(pm.moveDir.x > 0 && pm.moveDir.y == 0)   //right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y == 0)   //left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask)) 
            {
                noTerrainPosition = currentChunk.transform.Find("Left").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x == 0 && pm.moveDir.y > 0)   //up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask)) 
            {
                noTerrainPosition = currentChunk.transform.Find("Up").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x == 0 && pm.moveDir.y < 0)   //down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask)) 
            {
                noTerrainPosition = currentChunk.transform.Find("Down").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x > 0 && pm.moveDir.y > 0)   //right up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right Up").position, checkerRadius, terrainMask)) 
            {
                noTerrainPosition = currentChunk.transform.Find("Right Up").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x > 0 && pm.moveDir.y < 0)   //right down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right Down").position, checkerRadius, terrainMask)) 
            {
                noTerrainPosition = currentChunk.transform.Find("Right Down").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y > 0)   //left up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left Up").position, checkerRadius, terrainMask)) 
            {
                noTerrainPosition = currentChunk.transform.Find("Left Up").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y < 0)   //left down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left Down").position, checkerRadius, terrainMask)) 
            {
                noTerrainPosition = currentChunk.transform.Find("Left Down").position;
                SpawnChunk();
            }
        }
        */
    }

    void SpawnChunk()
    {
        int rand = Random.Range(0, terrainChunks.Count);
        latestChunk = Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);

        // ChunkTrigger component kontrolü
        if (latestChunk.GetComponent<ChunkTrigger>() == null)
        {
            latestChunk.AddComponent<ChunkTrigger>();
            latestChunk.GetComponent<ChunkTrigger>().targetMap = latestChunk;
        }

        spawnedChunks.Add(latestChunk);
    }

    void ChunkOptimizer()
    {
        optimizerCooldown -= Time.deltaTime;

        if (optimizerCooldown <= 0f)
        {
            optimizerCooldown = optimizerCooldownDur;
        }
        else
        {
            return;
        }

        for (int i = spawnedChunks.Count - 1; i >= 0; i--)
        {
            GameObject chunk = spawnedChunks[i];
            opDist = Vector3.Distance(player.transform.position, chunk.transform.position);
            if (opDist > maxOpDist)
            {
                Destroy(chunk);
                spawnedChunks.RemoveAt(i);
            }
            else
            {
                chunk.SetActive(true);
            }
        }

        // Aþaðýdaki kod dizini yeni mapleri aktif/pasif hale getiriyor. Yukarýdaki ise mapi silerek optimize ediyor.

        //foreach (GameObject chunk in spawnedChunks)
        //{
        //    opDist = Vector3.Distance(player.transform.position, chunk.transform.position);
        //    if(opDist > maxOpDist)
        //    {
        //        chunk.SetActive(false);
        //    }
        //    else
        //    {
        //        chunk.SetActive(true);
        //    }
        //}
    }
}
