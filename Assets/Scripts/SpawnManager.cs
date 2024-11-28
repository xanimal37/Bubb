using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager spawnManager { get; private set; }
    public GameObject player { get; private set; }

    private void Awake()
    {
        spawnManager = this;
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(BubbleSpawn());
        StartCoroutine(FishSpawn());
    }

    IEnumerator BubbleSpawn()
    {
        while (true)
        {
            int bubbleType = Random.Range(0, 3);
            Spawnable bubble = null;
            
            if (bubbleType == 0)
            {
                bubble = PoisonBubblePool.Pool.Get();
                
            }
            else
            {
                bubble = NormalBubblePool.Pool.Get();
            }
            if (bubble != null)
            {
                bubble.transform.position = GenerateSpawnPosition(bubble);
                Bubble bub = bubble as Bubble;
                bub.size = GenerateScale();
                bub.speed = GenerateScale();
            }
            yield return new WaitForSeconds(2);
        }
    }

    IEnumerator FishSpawn()
    {
        while (true)
        {
            Spawnable f = FishPool.Pool.Get();
            if (f != null)
            {
                f.transform.position = GenerateSpawnPosition(f);
            }
            yield return new WaitForSeconds(6);
        }
    }

    Vector3 GenerateSpawnPosition(Spawnable spawnable)
    {
        if(spawnable is Bubble)
        {
            float xPos = Random.Range(-20,21);
            float yPos = player.transform.position.y - 10;
            return new Vector3(xPos, yPos, -2);
        }
        if (spawnable is Fish)
        {
            float xPos = -18.0f;
            float yPos = player.transform.position.y + 4;
            return new Vector3 (xPos, yPos, -2);

        }
       
        return Vector3.zero;
    }

    float GenerateScale()
    {
        float randomScale = Random.Range(.5f, 5.5f);
        return randomScale;
    }
}
