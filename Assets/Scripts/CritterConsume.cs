using UnityEngine;

public class CritterConsume : MonoBehaviour 
{
    public void ConsumeOrganism(GameObject victim)
    {
        Destroy(victim);
    }
}
