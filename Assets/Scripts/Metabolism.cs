using UnityEngine;

public class Metabolism : MonoBehaviour 
{
    private float energyQuantity;
    private float baseMetabolicRate;

    private void Start() 
    {
        // TODO: initial values should be set by genetics.
        energyQuantity = 50;
        baseMetabolicRate = 1;
    }

    private void Update()
    {
        energyQuantity -= baseMetabolicRate * Time.deltaTime;
        DeathCheck();
    }

    public void GainEnergy(float amount)
    {
        energyQuantity += amount;
    }

    private void DeathCheck()
    {
        if(energyQuantity <= 0)
        {
            Destroy(gameObject);
        }
    }
}
