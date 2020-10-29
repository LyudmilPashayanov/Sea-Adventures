using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public TutorialView m_view;
    public int currentNumber = 0;
    public void SetTutorialOff()
    {
        m_view.SetActiveShop(false);
    }

    public void SetTutorialActive()
    {
        m_view.SetActiveShop(true);
    }

    public void NextTutorial()
    {
        currentNumber++;
        m_view.SetPreviousActive(true);
        if (currentNumber+1 == m_view.m_AllTutorials.Count)
        {
            m_view.SetNextActive(false);
        }
        m_view.SetTutorialNumber(currentNumber);
    }

    public void PreviousTutorial()
    {
        currentNumber--;
        m_view.SetNextActive(true);
        if (currentNumber == 0)
        {
            m_view.SetPreviousActive(false);
        }
        m_view.SetTutorialNumber(currentNumber);
    }
}
