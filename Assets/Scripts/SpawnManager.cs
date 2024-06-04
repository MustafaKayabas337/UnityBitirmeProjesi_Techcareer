using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Linq;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject triangle;
    [SerializeField] private GameObject rainDrop;
    [SerializeField] private GameObject[] spawnersLeft;
    [SerializeField] private GameObject[] spawnersRight;
    [SerializeField] private GameObject[] spawnersTop;

    private float raindropRate = 4f;
    private float triangleDropRate = 5f;
    private float capRainDropRate = 2f;
    private float capTriangledropRate = 2.5f;

    private int maxTriangle = 4 + 1;
    private int minTriangle = 1;
    private int maxRaindrop = 8 + 1;
    private int minRaindrop = 3;

    private int spawnersLeftSize;
    private int spawnersRightSize;
    private int spawnersTopSize;

    private int spawnerRandomizerMax = 30;

    private float rainDropIncreaseRate = 1f / 20f;
    private float triangleIncreaseRate = 1f / 20f;

    private void Awake()
    {
        spawnersLeftSize = spawnersLeft.Count();
        spawnersRightSize = spawnersRight.Count();
        spawnersTopSize = spawnersTop.Count();
    }

    public void SpawnStart()
    {
        StartCoroutine(SpawnTriangleLeft(1f));
        StartCoroutine(SpawnTriangleRight(3f));
        StartCoroutine(SpawnRaindropTop(2f));
        StartCoroutine(fastenTheGame());
    }

    private IEnumerator SpawnGameObject(GameObject gameObject, Vector3 newPosition, Transform spawnerTransform, DIRECTION direction, float time)
    {
        yield return new WaitForSeconds(time / 100f); //wait for miliseconds
        var spawnedObject = Instantiate(gameObject, newPosition, Quaternion.identity, spawnerTransform);
        spawnedObject.GetComponent<MoveTriangle>().direction = direction;
    }

    private IEnumerator SpawnTriangleLeft(float time)
    {
        yield return new WaitForSeconds(1f);
        while(true)
        {
            System.Random rand = new System.Random();

            List<int> randomList = new List<int>();
            int randCount = rand.Next(minTriangle, maxTriangle);
            for (int i = 0; i < randCount; i++)
            {
                int number = rand.Next(0, spawnersLeftSize);
                while (randomList.Contains(number)) number = rand.Next(0, spawnersLeftSize);
                randomList.Add(number);
            }

            foreach (int i in randomList)
            {
                Vector3 newPosition = spawnersLeft[i].transform.position;
                newPosition.z = -2;

                float randTime = (float)rand.Next(0, spawnerRandomizerMax);

                StartCoroutine(SpawnGameObject(triangle, newPosition, spawnersLeft[i].transform, DIRECTION.RIGHT, randTime));
            }

            yield return new WaitForSeconds(5f);
        }
    }

    private IEnumerator SpawnTriangleRight(float time)
    {
        yield return new WaitForSeconds(3f);
        while (true)
        {
            System.Random rand = new System.Random();

            List<int> randomList = new List<int>();
            int randCount = rand.Next(minTriangle, maxTriangle);
            for (int i = 0; i < randCount; i++)
            {
                int number = rand.Next(0, spawnersRightSize);
                while (randomList.Contains(number)) number = rand.Next(0, spawnersRightSize);
                randomList.Add(number);
            }

            foreach (int i in randomList)
            {
                Vector3 newPosition = spawnersRight[i].transform.position;
                newPosition.z = -2;


                float randTime = (float)rand.Next(0, spawnerRandomizerMax);
                StartCoroutine(SpawnGameObject(triangle, newPosition, spawnersRight[i].transform, DIRECTION.LEFT, randTime));
            }
            yield return new WaitForSeconds(triangleDropRate);
        }
    }

    private IEnumerator SpawnRaindropTop(float time)
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            System.Random rand = new System.Random();

            List<int> randomList = new List<int>();
            int randCount = rand.Next(minRaindrop, maxRaindrop);
            for (int i = 0; i < randCount; i++)
            {
                int number = rand.Next(0, spawnersTopSize);
                while (randomList.Contains(number)) number = rand.Next(0, spawnersTopSize);
                randomList.Add(number);
            }

            foreach (int i in randomList)
            {
                Vector3 newPosition = spawnersTop[i].transform.position;
                newPosition.z = -2;

                float randTime = (float)rand.Next(0, spawnerRandomizerMax);
                StartCoroutine(SpawnGameObject(rainDrop, newPosition, spawnersTop[i].transform, DIRECTION.DOWN, randTime));
            }
            yield return new WaitForSeconds(raindropRate);
        }
    }

    private IEnumerator fastenTheGame()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (raindropRate > capRainDropRate)
                raindropRate -= rainDropIncreaseRate;
            else
                raindropRate = capRainDropRate;

            if (triangleDropRate > capTriangledropRate)
                triangleDropRate -= triangleIncreaseRate;
            else
                triangleDropRate = capTriangledropRate;

            if (raindropRate == capRainDropRate && triangleDropRate == capTriangledropRate)
                break;
        }
    }
}
