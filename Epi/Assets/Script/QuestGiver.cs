using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class QuestGiver : Interactable
{
    public Quest quest;

    public Text titleText;
    public Text descriptionText;
    public Text experianceText;
    public Text GoldText;
    public GameObject questWindow;
    public GameObject QuestButton;
    public GameObject QuestPick;

    public override void Interact() {
        base.Interact();
        if (Input.GetMouseButtonUp(0))
            onOpenQuest();
    }

    public override void QuitInteract() {
        base.QuitInteract();
        if (quest.isActive)
            questWindow.SetActive(false);
    }
    void onOpenQuest() {
        questWindow.SetActive(true);
        titleText.text = quest.title;
        descriptionText.text = quest.description;
        GoldText.text = "Gold: " + quest.goldReward.ToString();
        experianceText.text = "Exp: " + quest.expReward.ToString();
    }

    public void AcceptQuest() {
        questWindow.SetActive(false);
        QuestButton.SetActive(false);
        QuestPick.SetActive(true);
        quest.isActive = true;
        CharacterStat player = PlayerManager.instance.player.GetComponent<CharacterStat>();
        player.quest = quest;
    }

    public void DeclineQuest() {
        questWindow.SetActive(false);
    }
}
