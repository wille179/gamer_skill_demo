using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateStatsWindow : MonoBehaviour {

    CharStats player;
    Text playerName;
    Text statMultiplier;
    Text soulPower;
    Text STR;
    Text DEX;
    Text INT;
    Text LUK;
    Text WIS;
    Text END;
    Slider HPSlider;
    Text HP;
    Slider MPSlider;
    Text MP;
    Slider StaminaSlider;
    Text Stamina;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharStats>();
        playerName = GameObject.Find("Character Name").GetComponent<Text>();
        statMultiplier = GameObject.Find("Stat Multiplier").GetComponent<Text>();
        soulPower = GameObject.Find("SoulPower").GetComponent<Text>();
        STR = GameObject.Find("STR").GetComponent<Text>();
        DEX = GameObject.Find("DEX").GetComponent<Text>();
        INT = GameObject.Find("INT").GetComponent<Text>();
        LUK = GameObject.Find("LUK").GetComponent<Text>();
        WIS = GameObject.Find("WIS").GetComponent<Text>();
        END = GameObject.Find("END").GetComponent<Text>();
        HP = GameObject.Find("HP").GetComponent<Text>();
        MP = GameObject.Find("MP").GetComponent<Text>();
        Stamina = GameObject.Find("Stamina").GetComponent<Text>();
        HPSlider = GameObject.Find("HPSlider").GetComponent<Slider>();
        MPSlider = GameObject.Find("MPSlider").GetComponent<Slider>();
        StaminaSlider = GameObject.Find("StaminaSlider").GetComponent<Slider>();

    }

    // Update is called once per frame
    private string formatTxt(string stat, float raw, float baseStat, float total)
    {
        return stat + ": " + total.ToString("0.##") + " (" + raw.ToString("0.##") + "+" + (baseStat - raw).ToString("0.##") + "+" + (total - baseStat).ToString("0.##") + ")";
    }
	void Update () {
        playerName.text = "Character Name: " + player.playerName;
        statMultiplier.text = "Stat Multiplier: " + player.getStatBoost();
        soulPower.text = "Soul Power: " + player.getSoulPower();
        STR.text = formatTxt("STR", player.getRawSTR(), player.getBaseSTR(), player.getTotalSTR());
        DEX.text = formatTxt("DEX", player.getRawDEX(), player.getBaseDEX(), player.getTotalDEX());
        INT.text = formatTxt("INT", player.getRawINT(), player.getBaseINT(), player.getTotalINT());
        LUK.text = formatTxt("LUK", player.getRawLUK(), player.getBaseLUK(), player.getTotalLUK());
        WIS.text = formatTxt("WIS", player.getRawWIS(), player.getBaseWIS(), player.getTotalWIS());
        END.text = formatTxt("END", player.getRawEND(), player.getBaseEND(), player.getTotalEND());
        HPSlider.value = (float) player.getHP() / player.getMaxHP();
        HP.text = "HP: " + player.getHP() + " / " + player.getMaxHP();
        MPSlider.value = (float) player.getMP() / player.getMaxMP();
        MP.text = "MP: " + player.getMP() + " / " + player.getMaxMP();
        StaminaSlider.value = (float) player.getStamina() / player.getMaxStamina();
        Stamina.text = "Stamina: " + player.getStamina() + " / " + player.getMaxStamina();

    }
}
