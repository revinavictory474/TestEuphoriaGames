using UnityEngine;
using UnityEngine.UI;

public class PlayerPut : MonoBehaviour
{
    #region Fields
    #region Text
    [SerializeField] private Text cubeTxt;
    [SerializeField] private Text sphereTxt;
    [SerializeField] private Text capsuleTxt;

    [SerializeField] private Text cubeTxtPopUp;
    [SerializeField] private Text sphereTxtPopUp;
    [SerializeField] private Text capsuleTxtPopUp;
    #endregion
    #region Reference
    [SerializeField] private InteractiveObjectsInstantiate interactiveObj;
    [SerializeField] private SceneController sceneController;
    [SerializeField] private GameObject popUpMenu;
    [SerializeField] private GameObject uiPanel;
    #endregion
    #region  NumberFields
    [SerializeField] internal int id;
    internal int scoreCube;
    internal int scoreSphere;
    internal int scoreCapsule;
    internal int countDeactiveObjects;
    private float distance = 5.0f;
    #endregion

    internal Text[] textScore;
    internal FigureId figureID;
    internal GameObject targetPut;
    private PlayerTake playerTake;

    #endregion

    private void Start()
    {
        Time.timeScale = 1;
        playerTake = GetComponent<PlayerTake>();
    }

    private void Update()
    {
        PutObjects();
    }

    /// <summary>
    /// Проверяем рейкастом попали ли в коллайдер с тэгом "puton".
    /// </summary>
    private void PutObjects()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));

        if(Physics.Raycast(ray, out hit, distance) && hit.collider.tag == "puton" && playerTake.isPickups)
        {
            if(Input.GetKeyDown(KeyCode.F) && playerTake.isPickups)
            {
                targetPut = hit.collider.gameObject;

                //Берем id фигуры в которую попал рэйкаст и присваиваем ей id
                //в числовом эквиваленте enum'а
                figureID = targetPut.GetComponent<FigureId>();
                id = figureID.figure.GetHashCode();

                if (id == playerTake.idObj)
                {
                    //Если id таблички и id фигуры совпадают, отключаем фигуру
                    //и прибавляем очко в пользу отключенной фигуры, 
                    //к счётчику деактивированных фигур прибавляем очко
                    playerTake.targetPickUp.gameObject.SetActive(false);
                    TextScore(id);
                    countDeactiveObjects++;


                    //Если количество деактивированных фигур и количество застауненных
                    //фигур на сцене совпадает
                    if(countDeactiveObjects == interactiveObj.countInteractiveObjects)
                    {
                        //Переносим заработанные очки с таблички сверху на всплывающее окно
                        cubeTxtPopUp.text = cubeTxt.text;
                        sphereTxtPopUp.text = sphereTxt.text;
                        capsuleTxtPopUp.text = capsuleTxt.text;

                        //Деактивируем верхнюю табличку и ставим игру на паузу
                        sceneController.PauseGame();
                        popUpMenu.SetActive(true);
                        uiPanel.SetActive(false);
                    }
                }
            }
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
