using UnityEngine;

public class CritterConsume : MonoBehaviour 
{
    private Metabolism metabolism;
    private void Start()
    {
        metabolism = GetComponent<Metabolism>();
    }

    public void ConsumeOrganism(GameObject victim)
    {
        float victimsEnergy = victim.GetComponent<Metabolism>().GetEnergyQuantity();
        // TODO: reduce energy amount gained by some formula
        // Some energy is lost in the process of digestion, this is determined by genetics
        // Food types would allow for more variety in digestion forumla
        metabolism.GainEnergy(victimsEnergy);
        Destroy(victim);
    }
}
