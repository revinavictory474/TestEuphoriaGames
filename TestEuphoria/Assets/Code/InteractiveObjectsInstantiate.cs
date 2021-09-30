using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjectsInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject[] interactiveObjects;
    [SerializeField] private List<GameObject> listPointsInstantiate = new List<GameObject>();
    [SerializeField] private List<GameObject> listInteractiveObjects = new List<GameObject>();
    private int countInteractiveObjects;

    private void Start()
    {
        InstantiateInteractiveObjects();
    }

   

    private void InstantiateInteractiveObjects()
    {
        //for (int i = 0; i < listInteractiveObjects.Count; i++)
        //{
        //    listInteractiveObjects.Add(interactiveObjects[i]);
        //}

        countInteractiveObjects = Random.Range(3, listPointsInstantiate.Count);

        for(int i = 0; i < countInteractiveObjects; i++)
        {
            int randomPosition = Random.Range(0, listPointsInstantiate.Count - 1);
            Instantiate(interactiveObjects[Random.Range(0, 2)], listPointsInstantiate[randomPosition].transform);
            listPointsInstantiate.RemoveAt(randomPosition);
        }
    }


}
