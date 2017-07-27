using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class CardLogic: IIdentifiable
{
    public Player owner;
    public int UniqueCardID; 

	public ScriptableObject ca; // Card Asset
    public GameObject VisualRepresentation;

    //private int baseManaCost;
    //TODO public SpellEffect effect;

    public int ID
    {
        get{ return UniqueCardID; }
    }

    public int CurrentManaCost{ get; set; }

    public bool CanBePlayed
    {
        get
        {
			/* TODO
            bool ownersTurn = (TurnManager.Instance.whoseTurn == owner);
            // for spells the amount of characters on the field does not matter
            bool fieldNotFull = true;
            // but if this is a creature, we have to check if there is room on board (table)
            if (ca.MaxHealth > 0)
                fieldNotFull = (owner.table.CreaturesOnTable.Count < 7);
            //Debug.Log("Card: " + ca.name + " has params: ownersTurn=" + ownersTurn + "fieldNotFull=" + fieldNotFull + " hasMana=" + (CurrentManaCost <= owner.ManaLeft));
            return ownersTurn && fieldNotFull && (CurrentManaCost <= owner.ManaLeft);
            */
			return true;
        }
    }

	public CardLogic(ScriptableObject ca)
    {
        this.ca = ca;
        UniqueCardID = IDFactory.GetUniqueID();
        //UniqueCardID = IDFactory.GetUniqueID();
        //baseManaCost = ca.ManaCost;
        //ResetManaCost();
		/* TODO
        if (ca.SpellScriptName!= null && ca.SpellScriptName!= "")
        {
            effect = System.Activator.CreateInstance(System.Type.GetType(ca.SpellScriptName)) as SpellEffect;
        }
		*/
        CardsCreatedThisGame.Add(UniqueCardID, this);
    }

    // STATIC (for managing IDs)
    public static Dictionary<int, CardLogic> CardsCreatedThisGame = new Dictionary<int, CardLogic>();

}
