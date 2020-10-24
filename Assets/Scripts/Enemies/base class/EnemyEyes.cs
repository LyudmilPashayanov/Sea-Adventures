using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ViewType
{
    allAround,
    front
}

public abstract class BaseEnemyEyes : MonoBehaviour
{
    private float rangeOfView;
    private ViewType viewType;
    public float RangeOfView { get => rangeOfView; set => rangeOfView = value; }
    public ViewType ViewType { get => viewType; set => viewType = value; }

    public abstract bool CheckForPlayer();

    public abstract bool TargetInView(Transform target);
   
    public virtual void SetPairOfEyes(float rangeOfView, ViewType sideOfView)
    {
        RangeOfView = rangeOfView;
        ViewType = sideOfView;
    }
}
