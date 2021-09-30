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
    /// ����� ��������� �������� (�� ������) � ��������� ������ (�� ������).
    /// </summary>
    private void InstantiateInteractiveObjects()
    {
        //������������� ��������� ���������� �������� �� ������
        //� ���������� �� 3� �� ����� ������ ����� ������ (� ������ ������ �� 10)
        countInteractiveObjects = Random.Range(3, listPointsInstantiate.Count);

        for(int i = 0; i < countInteractiveObjects; i++)
        {
            int randomPosition = Random.Range(0, listPointsInstantiate.Count - 1);
            //������� ������� � �����
            Instantiate(interactiveObjects[Random.Range(0, 3)], listPointsInstantiate[randomPosition].transform);
            //������� ����� �� ������ ����� ������ ���� ������ �� ����������
            listPointsInstantiate.RemoveAt(randomPosition);
        }
    }
}
