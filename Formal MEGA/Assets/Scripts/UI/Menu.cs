using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private int HomeScene = 0;
    private int TutorialScene = 1;
    private int MenuScene = 2;
    [SerializeField] private GameObject GameModes;
    [SerializeField] private GameObject TrackMenu;
    [SerializeField] private GameObject CarMenu;
    [SerializeField] private GameObject CarModel;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void onStartClick()
    {
        SceneManager.LoadScene(MenuScene);
    }

    public void onTutorialClick()
    {
        SceneManager.LoadScene(TutorialScene);
    }
    public void onHomeClick()
    {
        SceneManager.LoadScene(HomeScene);
    }

    public void onTimeAttackClick()
    {
        GameModes.SetActive(false);
        CarMenu.SetActive(true);
        CarModel.SetActive(true);
    }
    public void onChampionshipClick()
    {
        GameModes.SetActive(false);
    }

    public void onFreeRaceClick()
    {
        GameModes.SetActive(false);
        CarMenu.SetActive(true);
        CarModel.SetActive(true);
    }

    public void onCarSetClick()
    {
        CarMenu.SetActive(false);
        CarModel.SetActive(false);
        TrackMenu.SetActive(true);
    }

    public void onTrackSetClick()
    {
        TrackMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
