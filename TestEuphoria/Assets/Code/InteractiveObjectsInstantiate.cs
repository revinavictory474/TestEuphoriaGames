using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjectsInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject[] interactiveObjects;
    [SerializeField] private List<GameObject> listPointsInstantiate = new List<GameObject>();
    private int countInteractiveObjects;

    private void Start()
    {
        InstantiateInteractiveObjects();
    }

    private void InstantiateInteractiveObjects()
    {
        countInteractiveObjects = Random.Range(2, listPointsInstantiate.Count);

        for(int i = 0; i < countInteractiveObjects; i++)
        {
            int randomPosition = Random.Range(0, listPointsInstantiate.Count);
            Instantiate(interactiveObjects[i], listPointsInstantiate[randomPosition].transform);
            listPointsInstantiate.RemoveAt(randomPosition);
        }
    }


}
