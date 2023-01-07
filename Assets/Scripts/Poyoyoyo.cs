using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using static UnityEngine.UI.GridLayoutGroup;

public class Poyoyoyo : MonoBehaviour
{
    private Outline _outline;
    private Rigidbody _rb;
    private SlimeScinde _scinde;

    public float AspirationTime = 0.15f;
    private float _currentTime = 0;
    private Vector3 _position;
    private bool _grabed = false;
    private Transform _owner;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _outline = GetComponent<Outline>();
        _scinde = GetComponent<SlimeScinde>();
    }

    // Start is called before the first frame update
    void Start()
    {
        IEnumerator Jump()
        {
            while(true) {
                yield return new WaitForSeconds(Random.Range(3, 25));
                _rb.AddForce(Vector3.up * Random.Range(2, 5), ForceMode.Impulse);
            }
        }
        StartCoroutine(Jump());
    }

    // Update is called once per frame
    void Update()
    {
        if (_grabed)
        {
            if (_currentTime == 0)
                _position = transform.position;
            if (_currentTime < AspirationTime)
            {
                transform.position = Vector3.Lerp(_position, _owner.position - Vector3.up, _currentTime / AspirationTime);
                _currentTime += Time.deltaTime;
            }
            else
            {
                transform.position = _owner.position;
            }
        } else
        {
            _currentTime = 0;
        }
    }

    public void OnArmIn()
    {
        _outline.OutlineWidth = 8;
    }
    public void OnArmOut()
    {
        _outline.OutlineWidth = 0;
    }
    public void OnGrabIn(Transform owner)
    {
        _scinde.Scinder();
        _rb.isKinematic = true;
        _grabed = true;
        _owner = owner;

    }
    public void OnGrabOut()
    {
        _rb.isKinematic = false;
        _grabed = false;
        _owner = null;
    }
    public void OnThrow()
    {
        _rb.isKinematic = false;
        _grabed = false;
        _owner = null;
        _rb.AddForce(transform.up * -10, ForceMode.Impulse);
        //gameObject.SetActive(false);
    }
    public void Spawn(Vector3 direction)
    {
        _rb.AddForce((Vector3.up * 3) + direction * Random.Range(4, 5), ForceMode.Impulse);

    }
}
