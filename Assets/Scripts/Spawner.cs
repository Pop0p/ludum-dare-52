using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefabMedium;
    [SerializeField] private GameObject _prefabSmall;
    public string Element;
    private float _timer;
    public int NavMeshAgentTypeID;

    // Start is called before the first frame update
    void Start()
    {
        _timer = Random.Range(5, 16);
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer <= 0)
        {
            GameObject cube = null;
            // Utiliser un pool ?? + Ajouter un max ???
            var rand = Random.value;
            if (rand <= 0.95)
            {
                cube = Instantiate(_prefabSmall);
            }
            else
            {
                cube = Instantiate(_prefabMedium);
            }
            cube.GetComponent<Poyoyoyo>().Spawn(Random.onUnitSphere);
            cube.GetComponent<Poyoyoyo>().Element = Element;
            cube.GetComponent<NavMeshAgent>().agentTypeID = NavMeshAgentTypeID;
            cube.transform.position = transform.position;
            _timer = Random.Range(12, 32);
        }

        _timer -= Time.deltaTime;
    }
}
