using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coin;
    [SerializeField] private GameObject leftWall, rightWall, upWall, botWall;
    private int minX, maxX, minY, maxY;

    private float SpawnCoinRate = 3f;

    private void Awake()
    {
        minX = (int)leftWall.transform.localPosition.x + 26;
        maxX = (int)rightWall.transform.localPosition.x - 26;
        maxY = (int)upWall.transform.localPosition.y - 26;
        minY = (int)botWall.transform.localPosition.y + 26;
    }

    public void Start()
    {
        StartCoroutine(SpawnCoin(SpawnCoinRate));    
    }

    private IEnumerator SpawnCoin(float time)
    {
        while (true)
        {
            if (Input.touchCount > 0)
            {
                while (true)
                {
                    yield return new WaitForSeconds(time);
                    System.Random rand = new System.Random();
                    float coinZ = -2;
                    float coinY = rand.Next(maxY - minY) + minY;
                    float coinX = rand.Next(maxX - minX) + minX;
                    Vector3 position = new Vector3(coinX, coinY, coinZ);
                    var obj = Instantiate(coin, position, Quaternion.identity, transform);
                    obj.transform.localPosition = position;
                    Destroy(obj, 1f);
                }
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
