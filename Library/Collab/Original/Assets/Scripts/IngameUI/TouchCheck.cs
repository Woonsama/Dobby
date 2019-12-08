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
    
    private Player player;

    static private TouchCheck global;

    void Awake()
    {
        global = this;
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        Debug.Log(player.name);
    }

    void Update()
    {
        isClickDown = isClickUp = false;
    }

    public void TouchUp_PointerDown()
    {
        isTouchUp = true;
        isClickUp = true;
        player.SetPlayerState(Player.PLAYER_STATE.ATTACK_UP);
//        Debug.Log("touch up pointer down");
    }

    public void TouchUp_PointerUp()
    {
        isTouchUp = false;
//        Debug.Log("touch up pointer up");
    }


    public void TochDown_PointerDown()
    {
        isTouchDown = true;
        isClickDown = true;
        player.SetPlayerState(Player.PLAYER_STATE.ATTACK_DOWN);
        //        Debug.Log("touch down pointer down");
    }

    public void TochDown_PointerUp()
    {
        isTouchDown = false;
//        Debug.Log("touch down pointer up");
    }

    public static TouchCheck Get()
    {
        return global;
    }
}
