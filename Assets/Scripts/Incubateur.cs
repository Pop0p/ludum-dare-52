using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Incubateur : MonoBehaviour
{
    public Transform[] Emplacements;
    public Transform Retour;
    public GameObject[] TypePoiein;

    private int _nbPoiein;
    private GameObject[] _poieinFusion;

    private void Start()
    {
        _poieinFusion = new GameObject[2];
        _nbPoiein = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.layer == 7 && (collision.transform.parent != Emplacements[0] && collision.transform.parent != Emplacements[1]))
        {
            collision.transform.position = Emplacements[_nbPoiein].position;
            _poieinFusion[_nbPoiein] = collision.gameObject;
            collision.transform.parent = Emplacements[_nbPoiein];
            ++_nbPoiein;
        }

        Debug.Log(_nbPoiein);
        if (_nbPoiein == 2)
        {
            Fusion();
        }
    }

    private void Fusion()
    {
        string element1 = _poieinFusion[0].GetComponent<Poyoyoyo>().Element;
        string element2 = _poieinFusion[1].GetComponent<Poyoyoyo>().Element;

        int index = 0;

        switch (element1)
        {
            case "Fire":
                if (element2 == "Ground")
                {
                    index = 4;
                }
                break;
            case "Water":
                if (element2 == "Ground")
                {
                    index = 3;
                }
                break;
            case "Ground":
                if (element2 == "Water")
                {
                    index = 3;
                }
                else if (element2 == "Fire")
                {
                    index = 4;
                }
                break;
            default:
                break;
        }

        GameObject g = Instantiate(TypePoiein[index]);
        g.transform.position = Retour.position;
        g.SetActive(true);

        _poieinFusion[0].SetActive(false);
        _poieinFusion[1].SetActive(false);
        _nbPoiein = 0;
    }
}