using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialView : MonoBehaviour
{
    public RectTransform m_TutorialMenu;
    public List<RectTransform> m_AllTutorials;
    public Button m_NextButton;
    public Button m_PreviousButton;

    public void SetActiveShop(bool active)
    {
        m_TutorialMenu.gameObject.SetActive(active);
    }

    public void SetTutorialNumber(int number)
    {
        foreach (RectTransform item in m_AllTutorials)
        {
            item.gameObject.SetActive(false);
        }
        m_AllTutorials[number].gameObject.SetActive(true);
    }

    public void SetNextActive(bool active)
    {
        m_NextButton.interactable = active;
    }

    public void SetPreviousActive(bool active)
    {
        m_PreviousButton.interactable = active;
    }
}
