using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class control : MonoBehaviour
{

    private float _moveSpeed = 2f;
    private float _rotSpeed = 2f;

    private float _angle = 0f;

    private int _collected = 0;

    private PlayerInput playerInput;

    private GameObject _plane;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = playerInput.Horizontal;
        float moveVertical = playerInput.Vertical;

        //calculating new viewing angle and targeted direction
        _angle += moveHorizontal * _rotSpeed * Time.deltaTime;
        Vector3 targetDirection = new Vector3(Mathf.Sin(_angle), 0, Mathf.Cos(_angle));

        transform.position += transform.rotation * new Vector3(0, 0, moveVertical) * _moveSpeed * Time.deltaTime;
        
        transform.rotation = Quaternion.LookRotation(targetDirection);

    }
    private void OnCollisionEnter(Collision other){
        GameObject go = other.gameObject;
        
        //checks whether there is a collison with a collectible..
        if(go.name == "Cheese(Clone)") {
            Destroy(go);
            _collected += 1;
            Debug.Log("Collected: "+ _collected +" / "+ script._amount);
        } //or an enemy 
        else if(go.name == "Olive(Clone)") {
            Debug.Log("GAME OVER! time to fly :D");
            //Application.Quit();
            Destroy(this);
        }
    }
}
