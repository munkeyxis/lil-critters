using UnityEngine;

public class Metabolism : MonoBehaviour 
{
    private float energyQuantity;
    private float baseMetabolicRate;

    private void Start() 
    {
        // TODO: initial eneryQuantity should be set by genetics.
        energyQuantity = 50;
        baseMetabolicRate = 1;
    }

    private void Update()
    {
        energyQuantity -= baseMetabolicRate * Time.deltaTime;
    }

    public void GainEnergy(float amount)
    {
        energyQuantity += amount;
    }
}
