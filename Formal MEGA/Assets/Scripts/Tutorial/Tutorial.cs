using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private CarControllerV1 Car;
    [SerializeField] private GameObject[] UI;
    private PlayerControls controls;
    private int checkPoint = 0;
    private int MainMenuScene = 0;

    // Start is called before the first frame update
    void Start()
    {
        controls = Car.getControls();
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        controls.PlayerMap.Throttle.performed += ctx => Throttle();
        controls.PlayerMap.Turn.performed += ctx => Turn();
        controls.PlayerMap.Brake.performed += ctx => Brake();
        controls.PlayerMap.Accept.performed += ctx => Accept();
        controls.PlayerMap.CameraSwtich.performed += ctx => CameraSwap();
        controls.PlayerMap.Accept.performed += ctx => End();
    }

    void Throttle()
    {
        if (Time.timeScale == 0.0f)
        {
            if (checkPoint == 0)
            {
                UI[0].SetActive(false);
                Time.timeScale = 1.0f;
                checkPoint++;
            }
        }
    }

    void Turn()
    {
        if (Time.timeScale < 1)
        {
            if (checkPoint == 1)
            {
                UI[1].SetActive(false);
                Time.timeScale = 1.0f;
                checkPoint++;
            }
        }
    }

    void Brake()
    {
        if (Time.timeScale < 1)
        {
            if (checkPoint == 2)
            {
                UI[2].SetActive(false);
                Time.timeScale = 1.0f;
                checkPoint++;
            }
        }    
    }

    void Accept()
    {
        if (Time.timeScale < 1)
        {
            if (checkPoint == 3)
            {
                UI[3].SetActive(false);
                Time.timeScale = 1.0f;
                checkPoint++;
            }
        }
        UI[5].SetActive(false);
    }

    void CameraSwap()
    {
        if (Time.timeScale < 1)
        {
            if (checkPoint == 4)
            {
                UI[4].SetActive(false);
                Time.timeScale = 1.0f;
                checkPoint++;
            }
        }
    }

    void End()
    {
        if (Time.timeScale < 1)
        {
            if (checkPoint == 5)
            {
                SceneManager.LoadScene(MainMenuScene);
            }
        }
    }

}
