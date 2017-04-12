using UnityEngine;

public class Metabolism : MonoBehaviour 
{
    // TODO: initial values should be set by genetics.
    public float energyQuantity;
    public float baseMetabolicRate;

    private void Update()
    {
        energyQuantity -= baseMetabolicRate * Time.deltaTime;
        DeathCheck();
    }

    public float GetEnergyQuantity()
    {
        return energyQuantity;
    }

    public void GainEnergy(float amount)
    {
        energyQuantity += amount;
    }

    public void LoseEnergy(float amount)
    {
        energyQuantity -= amount;
    }

    private void DeathCheck()
    {
        if(energyQuantity <= 0)
        {
            Destroy(gameObject);
        }
    }
}
