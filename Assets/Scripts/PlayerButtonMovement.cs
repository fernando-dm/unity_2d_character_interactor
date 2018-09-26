using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerButtonMovement : MonoBehaviour
{
    private string _buttonPress;
    [SerializeField] private PlayerController2 player;


    public void OnMouseDown()
    {
        _buttonPress = EventSystem.current.currentSelectedGameObject.name;
//        print("OnMouseDown " + _buttonPress);
        player.MovingDirection = _buttonPress;
    }

    public void OnMouseUp()
    {
        _buttonPress = EventSystem.current.currentSelectedGameObject.name;
        player.MovingDirection = "Idle";

//        print("OnMouseUp " + _buttonPress);
    }

}