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

    public void SpawnStart()
    {
        InvokeRepeating("SpawnTriangleLeft", 1f, 5f);
        InvokeRepeating("SpawnTriangleRight", 3f, 5f);
        InvokeRepeating("SpawnRaindropTop", 2f, 4f);
    }


    private void SpawnTriangleLeft()
    {
        System.Random rand = new System.Random();

        List<int> randomList = new List<int>();
        int randCount = rand.Next(1, 5);
        for(int i = 0; i < randCount; i++)
        {
            int number = rand.Next(0, 7);
            while (randomList.Contains(number)) number = rand.Next(0, 7);
            randomList.Add(number);
        }

        foreach (int i in randomList)
        {
            Vector3 newPosition = spawnersLeft[i].transform.position;
            newPosition.z = -2;

            GameObject spawnedTriangle = Instantiate(triangle, newPosition, spawnersLeft[i].transform.localRotation, spawnersLeft[i].transform) as GameObject;

            spawnedTriangle.GetComponent<MoveTriangle>().direction = DIRECTION.RIGHT;
        }

    }

    private void SpawnTriangleRight()
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
    }

    private void SpawnRaindropTop()
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
    }

}
