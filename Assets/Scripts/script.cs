using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script : MonoBehaviour
{
    [SerializeField]
    private Transform _monster;
    [SerializeField]
    private Transform _myPrefab;

    private static readonly bool collisonTest = true;

    public static readonly int _amount = 8;
    private static readonly int _maxSearches = 100;
    private Vector3[] positions = new Vector3[_amount];

    // the combined radius of two collectables
    private float _combinedPrefabRadius = 0.2f;

    private Transform[] _collectables = new Transform[_amount];

    private GameObject _plane;

    // Start is called before the first frame update
    void Start()
    {   
        //locating the plane where everything is placed on
        _plane = GameObject.Find("Quad");

        //placing the collectables
        int searches;
        for(int i = 0; i < _amount; i++){
            searches = 0;
            Vector3 placingVector = new Vector3(RV(), 0.1f, RV());

            bool collided = true;
            //first prefab does not get checked for collissions
            if(i>0 && collisonTest){
                //searching for a new position until nothing collides
                while(collided && _maxSearches > searches){
                    searches++;

                    for(int ii = 0; ii < i; ii++){
                
                        float distance = Vector3.Distance(placingVector, positions[ii]);
                        
                        if(distance < _combinedPrefabRadius)
                        {
                            /* placingVector = placingVector + new Vector3(RV(), _plane.transform.position.y , RV()); */
                            placingVector = placingVector + new Vector3(RV(), 0, RV());
                            collided = true;
                            break;
                        } else
                        collided = false;

                        if(searches == _maxSearches){
                            Debug.Log("couldn't find a position :/ ");
                        }
                    }
                }
            }
            positions[i] = placingVector;

            _collectables[i] = Instantiate(_myPrefab, placingVector, Quaternion.Euler(0,0,0));
            _collectables[i].transform.SetParent(_plane.transform);

        }

        //placing the player with a little offset above the planes center
        //Instantiate(_player, new Vector3(0, 0.15f, 0), Quaternion.Euler(0,0,0)).transform.SetParent(_plane.transform);
        
        //placing the monsters
        Instantiate(_monster, new Vector3(1.5f, 0, 1.5f), Quaternion.Euler(0,0,0)).transform.SetParent(_plane.transform);
        Instantiate(_monster, new Vector3(-1.5f, 0, 1.5f), Quaternion.Euler(0,0,0)).transform.SetParent(_plane.transform);
        Instantiate(_monster, new Vector3(-1.5f, 0, -1.5f), Quaternion.Euler(0,0,0)).transform.SetParent(_plane.transform);
        Instantiate(_monster, new Vector3(1.5f, 0, -1.5f), Quaternion.Euler(0,0,0)).transform.SetParent(_plane.transform);
        
    }

    float RV(){
        float randomValue = UnityEngine.Random.Range(-1f, 1f);
        return randomValue;
    }

    // Update is called once per frame
    void Update()
    {
        //rotating the collectables
        for(int i = 0; i < _amount; i++) {
            
            float rotAngle = 90f * Time.deltaTime;

            if(_collectables[i] != null)
                _collectables[i].transform.rotation *= Quaternion.Euler(0, rotAngle, 0);
        }
    }
}
