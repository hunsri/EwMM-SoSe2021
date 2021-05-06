using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{

    private float _moveSpeed = 2f;
    private float _rotSpeed = 2f;

    private float _angle = 0f;

    private int _collected = 0;

    // Update is called once per frame
    void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        _angle += moveHorizontal * _rotSpeed * Time.deltaTime;
        Vector3 targetDirection = new Vector3(Mathf.Sin(_angle), 0, Mathf.Cos(_angle));

        transform.position += transform.rotation * new Vector3(0, 0, moveVertical) * _moveSpeed * Time.deltaTime;
        
        transform.rotation = Quaternion.LookRotation(targetDirection);

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
