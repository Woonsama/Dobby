using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCheck : MonoBehaviour
{
    [Header("Touch Check")]
    public bool isTouchUp;
    public bool isTouchDown;
    public bool isClickUp;
    public bool isClickDown;
    public bool isUnClickUp;
    public bool isUnClickDown;

    static private TouchCheck global;

    private Player player;

    void Awake()
    {
        global = this;

        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        isClickDown = isClickUp = false;
        isUnClickDown = isUnClickUp = false;
    }

    public void TouchUp_PointerDown()
    {
        player.SetPlayerState(Player.PLAYER_STATE.ATTACK_UP);
        isTouchUp = true;
        isClickUp = true;
//        Debug.Log("touch up pointer down");
    }

    public void TouchUp_PointerUp()
    {
        player.SetPlayerState(Player.PLAYER_STATE.ATTACK_UP);
        isTouchUp = false;
        isUnClickUp = true;
//        Debug.Log("touch up pointer up");
    }


    public void TochDown_PointerDown()
    {
        player.SetPlayerState(Player.PLAYER_STATE.ATTACK_DOWN);
        isTouchDown = true;
        isClickDown = true;
//        Debug.Log("touch down pointer down");
    }

    public void TochDown_PointerUp()
    {
        player.SetPlayerState(Player.PLAYER_STATE.ATTACK_DOWN);
        isTouchDown = false;
        isUnClickDown = true;
//        Debug.Log("touch down pointer up");
    }

    public static TouchCheck Get()
    {
        return global;
    }
}
