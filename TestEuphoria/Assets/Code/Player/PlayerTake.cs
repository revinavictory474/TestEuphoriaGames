using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTake : MonoBehaviour
{
    internal Test test;
    [SerializeField] internal int idObj;
    [SerializeField] internal GameObject popUp;
    [SerializeField] private Transform pickUpPoint;
    internal Transform targetPickUp;
    internal bool isPickups;
    private float speedTransform = 1.0f;

    private float distance = 5.0f;

    
    private void Update()
    {
        PickupObjects();
    }

    private void FixedUpdate()
    {
        if(isPickups)
        {
            targetPickUp.transform.position = Vector3.Lerp(targetPickUp.position, pickUpPoint.position, speedTransform);
        }
    }

    private void PickupObjects()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0f));

        if(Physics.Raycast(ray, out hit, distance) && hit.collider.tag == "pickup")
        {
            popUp.SetActive(true);
            
            if(Input.GetKeyDown(KeyCode.F))
            {
                targetPickUp = hit.transform;

                test = targetPickUp.GetComponent<Test>();
                idObj = test.figure.GetHashCode();

                isPickups = true;
            }
        }
        else
        {
            popUp.SetActive(false);
        }
    }
}
