using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPut : MonoBehaviour
{
    [SerializeField] private Text cubeTxt;
    [SerializeField] private Text sphereTxt;
    [SerializeField] private Text capsuleTxt;

    [SerializeField] private Text cubeTxtPopUp;
    [SerializeField] private Text sphereTxtPopUp;
    [SerializeField] private Text capsuleTxtPopUp;

    [SerializeField] private InteractiveObjectsInstantiate interactiveObj;
    [SerializeField] private GameObject popUpMenu;
    [SerializeField] private GameObject uiPanel;

    [SerializeField] private SceneController sceneController;

    internal int scoreCube;
    internal int scoreSphere;
    internal int scoreCapsule;
    internal int countDeactiveObjects;

    internal Text[] textScore;
    internal Test test;
    internal GameObject targetPut;

    [SerializeField] internal int id;
    private PlayerTake playerTake;
    private float distance = 5.0f;

    private void Start()
    {
        Time.timeScale = 1;
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
                    TextScore(id);
                    countDeactiveObjects++;

                    if(countDeactiveObjects == interactiveObj.countInteractiveObjects)
                    {
                        
                        cubeTxtPopUp.text = cubeTxt.text;
                        sphereTxtPopUp.text = sphereTxt.text;
                        capsuleTxtPopUp.text = capsuleTxt.text;

                        sceneController.PauseGame();

                        popUpMenu.SetActive(true);

                        uiPanel.SetActive(false);
                    }
                }

            }
        }
        else
        {
            playerTake.popUp.SetActive(false);
        }
    }

    private void TextScore(int id)
    {
        switch(id)
        {
            case 0:
                scoreCube++;
                cubeTxt.text = scoreCube.ToString();
                break;

            case 1:
                scoreSphere++;
                sphereTxt.text = scoreSphere.ToString();
                break;

            case 2:
                scoreCapsule++;
                capsuleTxt.text = scoreCapsule.ToString();
                break;

        }
    }
}
