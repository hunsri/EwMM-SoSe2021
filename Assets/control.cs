using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{

    [SerializeField]
    private float _speed = 15f;
    private float _rotSpeed = 90f;

    private int _collected = 0;

    // Update is called once per frame
    void Update()
    {
        //Vector3 viewDir = transform.rotation.eulerAngles;
        
        //if(Input.GetKey(KeyCode.Return))
        //transform.position = Vector3.MoveTowards(transform.position, transform.position + viewDir , Time.deltaTime * _speed);

        float angleY = transform.eulerAngles.y;

        Vector3 targetDirection = new Vector3(Mathf.Sin(angleY), 0, Mathf.Cos(angleY));
        Quaternion q = Quaternion.LookRotation(targetDirection);


        if(Input.GetKey(KeyCode.W)){
            transform.position += transform.rotation * new Vector3(0,0,0.1f) * Time.deltaTime * _speed;
        }
        if(Input.GetKey(KeyCode.S)){
            transform.position -= transform.rotation * new Vector3(0,0,0.1f) * Time.deltaTime * _speed;
        }
        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * _rotSpeed, Space.World);
        }
        if(Input.GetKey(KeyCode.D)){
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * _rotSpeed, Space.World);
        }

    }
    private void OnCollisionEnter(Collision other){
        Debug.Log(other.gameObject.name);
        GameObject go = other.gameObject;
        
        if(go.name == "Cheese(Clone)") {
            Destroy(go);
            _collected += 1;
            Debug.Log("Collected: "+ _collected +" / "+ script._amount);
        } else if(go.name == "Olive(Clone)") {
            Debug.Log("GAME OVER!");
            //Application.Quit();
            Destroy(this);
        }
    }
}
