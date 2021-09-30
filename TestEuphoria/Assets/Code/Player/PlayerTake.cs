using UnityEngine;

public class PlayerTake : MonoBehaviour
{
    #region Fields
    [SerializeField] internal int idObj;
    [SerializeField] internal GameObject popUp;
    [SerializeField] private Transform pickUpPoint;

    internal FigureId figureID;
    internal Transform targetPickUp;
    private float speedTransform = 5.0f;
    private float distance = 5.0f;

    internal bool isPickups;
    #endregion

    private void Update()
    {
        PickupObjects();
    }

    private void LateUpdate()
    {
        if(isPickups)
        {
            targetPickUp.transform.position = Vector3.Lerp(targetPickUp.position, pickUpPoint.position, speedTransform);
        }
    }

    /// <summary>
    /// ��������� ��������� ���� ������, ���� ��� "pickup", �� �������� ��������� ��� ����� ������ �� F
    /// ��� ��������.
    /// </summary>
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

                //����� id ������ � ������� ����� ������� � ����������� �� id
                //� �������� ����������� enum'�
                figureID = targetPickUp.GetComponent<FigureId>();
                idObj = figureID.figure.GetHashCode();

                isPickups = true;
            }
        }
        else
        {
            popUp.SetActive(false);
        }
    }
}
