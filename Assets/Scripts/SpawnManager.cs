using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

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
    
    public void SpawnStart()
    {
        StartCoroutine(SpawnTriangleLeft(1f));
        StartCoroutine(SpawnTriangleRight(3f));
        StartCoroutine(SpawnRaindropTop(2f));
        StartCoroutine(fastenTheGame());
    }


    private IEnumerator SpawnTriangleLeft(float time)
    {
        yield return new WaitForSeconds(1f);
        while(true)
        {
            System.Random rand = new System.Random();

            List<int> randomList = new List<int>();
            int randCount = rand.Next(1, 5);
            for (int i = 0; i < randCount; i++)
            {
                int number = rand.Next(0, 7);
                while (randomList.Contains(number)) number = rand.Next(0, 7);
                randomList.Add(number);
            }

            foreach (int i in randomList)
            {
                Vector3 newPosition = spawnersLeft[i].transform.position;
                newPosition.z = -2;

                var spawnedTriangle = Instantiate(triangle, newPosition, Quaternion.identity, spawnersLeft[i].transform);

                spawnedTriangle.GetComponent<MoveTriangle>().direction = DIRECTION.RIGHT;
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
            int randCount = rand.Next(1, 5);
            for (int i = 0; i < randCount; i++)
            {
                int number = rand.Next(0, 7);
                while (randomList.Contains(number)) number = rand.Next(0, 7);
                randomList.Add(number);
            }

            foreach (int i in randomList)
            {
                Vector3 newPosition = spawnersRight[i].transform.position;
                newPosition.z = -2;

                var spawnedTriangle = Instantiate(triangle, newPosition, Quaternion.identity, spawnersRight[i].transform);

                spawnedTriangle.GetComponent<MoveTriangle>().direction = DIRECTION.LEFT;
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
            int randCount = rand.Next(3, 9);
            for (int i = 0; i < randCount; i++)
            {
                int number = rand.Next(0, 15);
                while (randomList.Contains(number)) number = rand.Next(0, 15);
                randomList.Add(number);
            }

            foreach (int i in randomList)
            {
                Vector3 newPosition = spawnersTop[i].transform.position;
                newPosition.z = -2;

                var spawnedTriangle = Instantiate(rainDrop, newPosition, Quaternion.identity, spawnersTop[i].transform);

                spawnedTriangle.GetComponent<MoveTriangle>().direction = DIRECTION.DOWN;
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
                raindropRate -= (1f / 20f);
            else
                raindropRate = capRainDropRate;

            if (triangleDropRate > capTriangledropRate)
                triangleDropRate -= (1f / 20f);
            else
                triangleDropRate = capTriangledropRate;

            if (raindropRate == capRainDropRate && triangleDropRate == capTriangledropRate)
                break;
        }
    }
}
