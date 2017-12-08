using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour {

    public string playerName = "William";

    //Stat Variables should normally be private.
    [Tooltip("Represents a player's 'level.' Can be a fractional amount.")]
    public float soulPower = 1;
    private float statBoost = 1.01f;//"Reflects a how a player's level affects their overall strength."

    //True Stats
    [Tooltip("Strength. Represents the ability to inflict physical damage and wear armor.")]
    public float STR_exp = 0;
    [Tooltip("Dextarity. Represents the overall agility of the character.")]
    public float DEX_exp = 0; 
    [Tooltip("Intelligence. Represents the ability to inflict magical damage and use certain spells and mystical tools.")]
    public float INT_exp = 0;
    [Tooltip("Luck. Represents the ability to extract good fortune. (Loot, critical hits, etc.)")]
    public float LUK_exp = 0;
    [Tooltip("Wisdom. Represents the ability to generate, store, and use mana.")]
    public float WIS_exp = 0;
    [Tooltip("Endurance. Represents the source of a user's stamina and ability to withstand attacks.")]
    public float END_exp = 0;

    private int maxHP = 100;
    private int currentHP = 100;
    private int maxMP = 100;
    private int currentMP = 100;
    private int maxStamina = 100;
    private int currentStamina = 100;

    //Equipment
    public Equps equips;

    //Skills
    public SkillManager skills;

    // Use this for initialization
    void Start () {
        equips = gameObject.GetComponent<Equps>();
        skills = gameObject.GetComponent<SkillManager>();
        updateStats();
        currentHP = maxHP;
        currentMP = maxMP;
        currentStamina = maxStamina;
	}
	
    /**
     * This method updates all stats, and is called, at minimum, when any one stat is updated.
     **/
    private void updateStats()
    {
        statBoost = 1.0f + (Mathf.Log(soulPower, 6)/15f);
        maxHP = (int) Mathf.Ceil(((100 + (Mathf.Floor(getBaseEND()) * 3) + Mathf.Floor(getBaseSTR())) * (1 + equips.multHP)) + equips.addHP);
        maxMP = (int) Mathf.Ceil(((100 + (Mathf.Floor(getBaseWIS()) * 3) + Mathf.Floor(getBaseINT())) * (1 + equips.multMP)) + equips.addMP);
        maxStamina = (int) Mathf.Ceil(((100 + (Mathf.Floor(getBaseEND()) * 4)) * (1 + equips.multStamina)) + equips.addStamina);
    }

    public float getStatBoost() { return statBoost; }
    public float getSoulPower() { return soulPower; }
    public int getHP() { return currentHP; }
    public int getMaxHP() { return maxHP; }
    public int getMP() { return currentMP; }
    public int getMaxMP() { return maxMP; }
    public int getStamina() { return currentStamina; }
    public int getMaxStamina() { return maxStamina; }

    public void healHP(int hp)
    {
        currentHP += hp;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }

    public void healMP(int mp)
    {
        currentMP += mp;
        if (currentMP > maxMP)
        {
            currentMP = maxMP;
        }
    }

    public void healStamina(int stam)
    {
        currentStamina += stam;
        if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }
    }

    //stat = {SP,STR,DEX,INT,LUK,WIS,END}
    public void train(string stat, float exp)
    {
        switch(stat)
        {
            case "SP": soulPower += exp; break;
            case "STR": STR_exp += exp; break;
            case "DEX": DEX_exp += exp; break;
            case "LUK": LUK_exp += exp; break;
            case "INT": INT_exp += exp; break;
            case "WIS": WIS_exp += exp; break;
            case "END": END_exp += exp; break;
            default:break;
        }

    }


    //Raw stats from stat EXP alone -------------------------------------------

    private float expToStat(float exp) { return Mathf.Log(exp+1, 1.11f) + 1f; }

    public float getRawSTR()
    {
        return expToStat(STR_exp);
    }

    public float getRawDEX()
    {
        return expToStat(DEX_exp);
    }

    public float getRawINT()
    {
        return expToStat(INT_exp);
    }

    public float getRawLUK()
    {
        return expToStat(LUK_exp);
    }

    public float getRawWIS()
    {
        return expToStat(WIS_exp);
    }

    public float getRawEND()
    {
        return expToStat(END_exp);
    }

    //Base Stats from EXP * Soul Power -----------------------------------------
    public float getBaseSTR()
    {
        return getRawSTR() * statBoost;
    }

    public float getBaseDEX()
    {
        return getRawDEX() * statBoost;
    }

    public float getBaseINT()
    {
        return getRawINT() * statBoost;
    }

    public float getBaseLUK()
    {
        return getRawLUK() * statBoost;
    }

    public float getBaseWIS()
    {
        return getRawWIS() * statBoost;
    }

    public float getBaseEND()
    {
        return getRawEND() * statBoost;
    }

    // Base stats + added Stats from equipment -------------------------
    public float getTotalSTR()
    {
        return (getBaseSTR() * (1+equips.multSTR)) + equips.addSTR;
    }

    public float getTotalDEX()
    {
        return (getBaseDEX() * (1+equips.multDEX)) + equips.addDEX;
    }

    public float getTotalINT()
    {
        return (getBaseINT() * (1+equips.multINT)) + equips.addINT;
    }

    public float getTotalLUK()
    {
        return (getBaseLUK() * (1 + equips.multLUK)) + equips.addLUK;
    }

    public float getTotalWIS()
    {
        return (getBaseWIS() * (1 + equips.multWIS)) + equips.addWIS;
    }

    public float getTotalEND()
    {
        return (getBaseEND() * (1 + equips.multEND)) + equips.addEND;
    }
}
