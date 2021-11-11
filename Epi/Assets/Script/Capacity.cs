using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Capacity", menuName = "Capacity/Capacity")]
public class Capacity : ScriptableObject {
    new public string name = "New Item";
    public Sprite icon = null;
    public int lvl = 0;
    public bool lvlup = false;

    public virtual void Use() {
        Debug.Log("Using "+ name);
    }
    public virtual void LvlUp() {
        CharacterStat c = PlayerManager.instance.player.GetComponent<CharacterStat>();
        if (c.capacityPoint > 0) {
            lvl += 1;
            Debug.Log("Lvl Up for "+ name);
            c.capacityPoint -= 1;
            lvlup = true;
        } else
            Debug.Log("don't have capacity point");
        //capacity power up
    }
}

