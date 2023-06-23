using UnityEngine;
using System;

[Serializable]
public class PlayerInstantCard : MonoBehaviour
{
	public string CardName;
	public string TimeCost;
	public string AlertCost;
	public string CardClass;
	public string CardType;
	public string CardSubtype;
	public string TargetingType;
	public string ProgressGenerated;
	public string DamageGenerated;
	public string CardDescription;
	public int SpriteIndex;
	
	bool play(GameObject target) {
		// attempt to target 'target' with this card. Returns true if is a valid target and casts succesfully. returns false if invalid target
		return false;
	}
	
	
    // Start is called before the first frame update
    void Start()
    {

	}

    // Update is called once per frame
    void Update()
    {
        // TODO: calculate CURRENT timecost/alert cost and update visual IF IT IS DIFFERENT FROM BASE
		// TODO and change color based on whether its more or less
    }
}
