using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int totalRAM;
    // Start is called before the first frame update
    public struct towerGroups
    {
        public GameObject[] towers;
        public bool isCorrupted;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateRAMAmount(int newTotal)
    {
        totalRAM = newTotal;
    }
}
