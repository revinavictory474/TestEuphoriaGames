using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjectsInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject[] interactiveObjects;
    [SerializeField] private List<GameObject> listPointsInstantiate = new List<GameObject>();
    internal int countInteractiveObjects;

    private void Start()
    {
        InstantiateInteractiveObjects();
    }

   
    /// <summary>
    /// Спаун рандомных объектов (из списка) в рандомных точках (из списка).
    /// </summary>
    private void InstantiateInteractiveObjects()
    {
        //Устанавливаем рандомное количество объектов из списка
        //в количестве от 3х до конца списка точек спауна (в данном случае до 10)
        countInteractiveObjects = Random.Range(3, listPointsInstantiate.Count);

        for(int i = 0; i < countInteractiveObjects; i++)
        {
            int randomPosition = Random.Range(0, listPointsInstantiate.Count - 1);
            //Спауним объекты в точки
            Instantiate(interactiveObjects[Random.Range(0, 3)], listPointsInstantiate[randomPosition].transform);
            //Удаляем точку из списка чтобы никого туда больше не заспаунить
            listPointsInstantiate.RemoveAt(randomPosition);
        }
    }
}
