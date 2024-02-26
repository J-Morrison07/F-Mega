using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Scenes
    private int HomeScene = 0;
    private int TutorialScene = 1;
    private int MenuScene = 2;
    private int Track = 3;

    private int Car = 1;

    private int GameModeIndex = 0;
    [SerializeField] private GameObject GameModes;
    [SerializeField] private GameObject TrackMenu;
    [SerializeField] private GameObject CarMenu;
    [SerializeField] private GameObject CarModel;
    [SerializeField] private GameObject HoloTable;
    [SerializeField] private GameObject[] CarModels;
    [SerializeField] private GameObject[] RaceBalls;
    [SerializeField] private GameObject[] GameMadeSettings;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {

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
        GameModeIndex = 0;
    }
    public void onChampionshipClick()
    {
        GameModes.SetActive(false);
        GameModeIndex = 1;
    }

    public void onFreeRaceClick()
    {
        GameModes.SetActive(false);
        CarMenu.SetActive(true);
        CarModel.SetActive(true);
        GameModeIndex = 2;
    }

    public void onCarSetClick()
    {
        CarMenu.SetActive(false);
        CarModel.SetActive(false);
        TrackMenu.SetActive(true);
        HoloTable.SetActive(true);
    }

    public void onTrackSetClick()
    {
        TrackMenu.SetActive(false);
        HoloTable.SetActive(false);
        GameMadeSettings[GameModeIndex].SetActive(true);
    }

    //Cars
    public void onCar01Click()
    {
        for(int i = 0; i < CarModels.Length; i++) {
            CarModels[i].SetActive(false);
        }
        CarModels[0].SetActive(true);
        Car = 1;
        StaticData.Car = Car;
    }
    public void onCar02Click()
    {
        for (int i = 0; i < CarModels.Length; i++)
        {
            CarModels[i].SetActive(false);
        }
        CarModels[1].SetActive(true);
        Car = 2;
        StaticData.Car = Car;
    }
    public void onCar03Click()
    {
        for (int i = 0; i < CarModels.Length; i++)
        {
            CarModels[i].SetActive(false);
        }
        CarModels[2].SetActive(true);
        Car = 3;
        StaticData.Car = Car;
    }

    // Tracks
    public void onTrack01Click()
    {
        for (int i = 0; i < RaceBalls.Length; i++)
        {
            RaceBalls[i].SetActive(false);
        }
        RaceBalls[0].SetActive(true);
        Track = 3;
    }

    public void onTrack02Click()
    {
        for (int i = 0; i < RaceBalls.Length; i++)
        {
            RaceBalls[i].SetActive(false);
        }
        RaceBalls[1].SetActive(true);
        Track = 4;
    }

    public void onTrack03Click()
    {
        for (int i = 0; i < RaceBalls.Length; i++)
        {
            RaceBalls[i].SetActive(false);
        }
        RaceBalls[2].SetActive(true);
        Track = 5;
    }

    public void OnGoClicked()
    {
        SceneManager.LoadScene(Track);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
