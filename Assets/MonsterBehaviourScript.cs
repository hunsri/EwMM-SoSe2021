using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviourScript : MonoBehaviour
{

    [SerializeField]
    private float _speed = 15f;
    // [SerializeField]
    private Transform _target;

         // Start is called before the first frame update
    void Start()
    {
        _target =  GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 destination = new Vector3(_target.transform.position.x, transform.position.y, _target.transform.position.z);

        transform.LookAt(destination);
        transform.position += transform.rotation * new Vector3(0,0,0.1f) * Time.deltaTime * _speed;
    }
}
