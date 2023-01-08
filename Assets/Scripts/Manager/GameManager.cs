using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool InPause;


    public GameObject NeutreEau;
    public GameObject NeutreFeu;
    public GameObject NeutreVegetal;
    public GameObject NeutreRock;
    public GameObject NeutreSoil;

    public GameObject EauTerre; // CHECK
    public GameObject EauVegetal;

    public GameObject FeuTerre; // CHECK
    public GameObject FeuVegetal; // CHECK

    public GameObject RocheEau; // CHECK
    public GameObject RocheTerre; // CHECK
    public GameObject RocheVegetal; // CHECK

    public GameObject TerreVegetal; // CHECK


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            InPause = !InPause;
            if (InPause)
                MenuManager.Instance.OnPause();
            else
                MenuManager.Instance.OnPlay();
        }
    }
}
