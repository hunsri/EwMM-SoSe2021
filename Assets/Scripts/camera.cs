using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    private Vector3 _cameraPosition;
    private Vector3 _endPosition;

    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _height = 1f;

    private float _distance = 2f;

    // Start is called before the first frame update
    void Start()
    {
        _cameraPosition =  new Vector3(_target.transform.position.x, 0, _target.transform.position.z) + new Vector3(0,0,-_distance);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R)){
            _height += 0.1f;
        }
        if(Input.GetKey(KeyCode.F)){
            _height -= 0.1f;
        }
        if(Input.GetKey(KeyCode.Plus) && _distance > 1f){
            _distance -= 0.1f;
        }
        if(Input.GetKey(KeyCode.Minus) && _distance < 10f){
            _distance += 0.1f;
        }


        _endPosition = new Vector3(_target.transform.position.x, 0, _target.transform.position.z) + _target.transform.rotation * new Vector3(0,0, -_distance);

        //transform.position = _target.transform.position + _target.transform.rotation * new Vector3(0, 1, -5);
        //_endPosition = _target.transform.position + _target.transform.rotation * new Vector3(0, 1, 5);

        //Debug.Log(_target.position);


        //transform.position = _target.transform.position + _target.transform.rotation * new Vector3(0, 1, -5);
        transform.LookAt(_target.transform.position);
        
        _cameraPosition = Vector3.Slerp(_cameraPosition, _endPosition, 0.05f);
        transform.LookAt(_target.transform.position);


        transform.position = _cameraPosition + new Vector3(0,_height,0);
    }
}
