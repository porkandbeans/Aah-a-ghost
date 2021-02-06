using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigateNPC : MonoBehaviour
{
    public Transform[] navPoints;
    public NPCbehaviour npc;
    public int currentPoint = 0;

    private void Start()
    {
        if (npc != null)
        {
            npc.followingPath = true;
            npc.LookAtPoint(navPoints[currentPoint]);
        }
    }

    private void FixedUpdate()
    {
        if(npc != null)
            npc.LookAtPoint(navPoints[currentPoint]);
    }

    public void ReachedPoint()
    {
        currentPoint++;
        if (currentPoint >= navPoints.Length)
            currentPoint = 0;
        
        npc.LookAtPoint(navPoints[currentPoint]);
    }
}
