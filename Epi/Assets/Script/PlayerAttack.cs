using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;


[System.Serializable]
public class PlayerAttack : MonoBehaviour
{
    public Camera cam;
    public Interactable focus;

    //move
    public CharacterController controller;
    public Transform thing;
    public float s = 6f;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;

    public bool isGrounded;
    private Vector3 playerVelocity;
    private float jumpHeight = 2.0f;
    private float gravityValue = -9.81f;

    void Start()
    {
    }

    // Update is called once per frame
    void Update() {
        //move
        isGrounded = controller.isGrounded;
        if (isGrounded && playerVelocity.y < 0) {
            playerVelocity.y = -1f;
        }
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h , 0f, v).normalized;
       
        if (dir.magnitude >= 0.1f) {
           float targetA = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + thing.eulerAngles.y;
           float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetA, ref turnSmoothVelocity, turnSmoothTime);
           transform.rotation = Quaternion.Euler(0f, angle, 0f);
           Vector3 movedir = Quaternion.Euler(0f, targetA, 0f) * Vector3.forward;
           controller.Move(movedir.normalized * s * Time.deltaTime);
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        CharacterStat stat = PlayerManager.instance.player.GetComponent<CharacterStat>();
        stat.GainLvl();
        if (stat.quest.isActive) {
            if (stat.quest.questGoal.goalType == GoalType.LvlNbr && stat.quest.questGoal.IsReachedLvl()) {
                stat.GainXP(stat.quest.expReward);
                stat.gold += stat.quest.goldReward;
                stat.quest.Complete();
            } if (stat.quest.questGoal.goalType == GoalType.PickObject && stat.quest.questGoal.IsReachedItem()) {
                stat.GainXP(stat.quest.expReward);
                stat.gold += stat.quest.goldReward;
                stat.quest.Complete();
            }
        }
    }

    public void SavePlayer() {
        SaveSystem.SavePlayer(PlayerManager.instance.player.GetComponent<CharacterStat>());
        Debug.Log("Save");
    }

    
    void SetFocus(Interactable newFocus) {
        focus = newFocus;
        newFocus.OnFocused(transform);
    }
}
