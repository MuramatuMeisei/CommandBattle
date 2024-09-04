using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSelectionUI : MonoBehaviour
{
    public Button[] itemButtons;
    public Button cancelButton;

    public void ShowItemSelection()
    {
        gameObject.SetActive(true);
    }

    public void HideItemSelection()
    {
        gameObject.SetActive(false);
    }

    public void SetItemButtons(string[] itemNames, System.Action<int> onItemSelected)
    {
        for(int i = 0; i < itemButtons.Length; i++)
        {
            if(i < itemNames.Length)
            {
                itemButtons[i].GetComponentInChildren<Text>().text = itemNames[i];
                int index = i;
                itemButtons[i].onClick.RemoveAllListeners();
                itemButtons[i].onClick.AddListener(() => onItemSelected(index));
                itemButtons[i].gameObject.SetActive(true);
            }

            else
            {
                itemButtons[i].gameObject.SetActive(false);
            }
        }
    }

    public void SetCancelButton(System.Action onCancel)
    {
        cancelButton.onClick.RemoveAllListeners();
        cancelButton.onClick.AddListener(() => onCancel());
    }
}
