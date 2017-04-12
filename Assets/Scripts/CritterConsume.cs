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
        metabolism.GainEnergy(10); // TODO: amount gained should come from victim
        Destroy(victim);
    }
}
