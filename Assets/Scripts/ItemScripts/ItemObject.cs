using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData ItemData;

    public string GetInteractPrompt()
    {
        string str = $"{ItemData.itemName}\n\n{ItemData.description}";
        return str;
    }

    public void OnInteract()
    {
        CharacterManager.Instance.Player.itemData = this.ItemData;
        CharacterManager.Instance.Player.playerController.OnAddItem?.Invoke();
        Destroy(gameObject);
    }
}
