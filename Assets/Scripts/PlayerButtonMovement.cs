using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerButtonMovement : MonoBehaviour
{
    [SerializeField] private PlayerController2 player;
    private string _buttonPress;


    public void OnMouseDown()
    {
        _buttonPress = EventSystem.current.currentSelectedGameObject.name;
        print("OnMouseDown " + _buttonPress);
        MovingActionsPlayer(_buttonPress);
    }

    public void OnMouseUp()
    {
        _buttonPress = EventSystem.current.currentSelectedGameObject.name;
        player.Flag = "Idle";
        print("OnMouseUp " + _buttonPress);
    }

    private void MovingActionsPlayer(string button)
    {
        _buttonPress = button;
        if (_buttonPress.Equals("Right"))
        {
            player.Flag = "Right";
        }

        if (_buttonPress.Equals("Left"))
        {
            player.Flag = "Left";
        }

        if (_buttonPress.Equals("Jump"))
        {
            player.Flag = "Jump";
        }
    }
}