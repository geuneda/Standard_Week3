using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObject : MonoBehaviour
{
    public Transform player;
    public List<Transform> cubes;
    public float radius = 3f;
    public float rotationSpeed = 30f;

    private bool isRotating = false;

    public void ArrangeInCircle()
    {
        List<Transform> shuffledCubes = new List<Transform>(cubes);
        ShuffleList(shuffledCubes);

        float angleStep = 360f / shuffledCubes.Count;

        for (int i = 0; i < shuffledCubes.Count; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;
            Vector3 position = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            shuffledCubes[i].position = player.position + position;
        }
    }

    public void StartRotation()
    {
        isRotating = true;
    }

    public void StopRotation()
    {
        isRotating= false;
    }

    private void Update()
    {
        if (isRotating)
        {
            foreach (var cube in cubes)
            {
                cube.RotateAround(player.position, Vector3.up, rotationSpeed * Time.deltaTime);
            }
        }
    }

    private void ShuffleList(List<Transform> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(0, list.Count);
            Transform temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
