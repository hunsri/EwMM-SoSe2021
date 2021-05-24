using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class PlayerInput : MonoBehaviour
{
  public float Horizontal { get; private set; }
  public float Vertical { get; private set; }

  private readonly string[] _buttonNames = new string[] { "forward", "left", "backward", "right" };

  //holds a value representing the wanted direction once a Virtual Button is pressed
  //necessary to later add this value on top of the movement value which is based on the axes  
  private float _vbHorizontal, _vbVertical = 0f;
  //the speed at which the player moves if there is a virtual button input
  private readonly float _vbSpeed = 0.5f;



     public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("Button pressed: " + vb.VirtualButtonName);
        
        string name = vb.VirtualButtonName;

        if(name == _buttonNames[0])
        {
            _vbVertical = _vbSpeed;
        }
        else if (name == _buttonNames[1])
        {
            _vbHorizontal = -_vbSpeed;
        }
        else if(name == _buttonNames[2])
        {
            _vbVertical = -_vbSpeed;
        }
        else if (name == _buttonNames[3])
        {
            _vbHorizontal = _vbSpeed;
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        string name = vb.VirtualButtonName;

        if(name == _buttonNames[0] || name == _buttonNames[2])
        {
            _vbVertical = 0f;
        }
        else if(name == _buttonNames[1] || name == _buttonNames[3])
        {
            _vbHorizontal = 0f;
        }
    }

    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        Horizontal = Horizontal + _vbHorizontal;
        Vertical = Vertical + _vbVertical;
    }

}
