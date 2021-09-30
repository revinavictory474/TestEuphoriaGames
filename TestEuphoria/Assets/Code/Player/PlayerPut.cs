using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPut : MonoBehaviour
{
    internal Test test;
    internal GameObject targetPut;

    [SerializeField] internal int id;
    private PlayerTake playerTake;
    private float distance = 5.0f;

    private void Start()
    {
        playerTake = GetComponent<PlayerTake>();
    }

    private void Update()
    {
        PutObjects();
    }

    private void PutObjects()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));

        if(Physics.Raycast(ray, out hit, distance) && hit.collider.tag == "puton")
        {
            playerTake.popUp.SetActive(true);

            if(Input.GetKeyDown(KeyCode.F) && playerTake.isPickups)
            {
                targetPut = hit.collider.gameObject;
                test = targetPut.GetComponent<Test>();
                id = test.figure.GetHashCode();
                if (id == playerTake.idObj)
                {
                    playerTake.targetPickUp.gameObject.SetActive(false);
                    Debug.Log("test");

                }

            }
        }
        else
        {
            playerTake.popUp.SetActive(false);
        }
    }
}
