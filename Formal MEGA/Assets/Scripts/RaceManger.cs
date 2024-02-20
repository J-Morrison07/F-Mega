using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceManger : MonoBehaviour
{
    [SerializeField] private List<GameObject> RacePositions = new List<GameObject>();
    [SerializeField] private int Lap = 1;
    public void addCar(GameObject car)
    {
        for (int i = 0; i < RacePositions.Count; i++)
        {
            if (RacePositions[i] == car)
            {
                return;
            } 
        }
        RacePositions.Add(car);
    }
}
