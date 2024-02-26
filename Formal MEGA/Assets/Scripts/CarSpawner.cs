using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] Cars;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Cars[StaticData.Car-1]);
    }
}
