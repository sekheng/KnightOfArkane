using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;

public class character : MonoBehaviour {
    public int Level;
    public int attack_stat;
    public int defend_stat;
    public int speed_stat;
    public int stat_points;
    public int stat_points_used;
    public Text[] display_stats;
    private int equip_att;
    private int equip_def;
    private int equip_spd;
    public int temp_att;
    public int temp_def;
    public int temp_spd;
   
    // Use this for initialization
    void Start () {

        equip_att = 0;
        equip_def = 0;
        equip_spd = 0;
        temp_att= 0;
        temp_def= 0;
        temp_spd = 0;
        stat_points_used = 0;
        attack_stat += equip_att;
        defend_stat += equip_def;
        speed_stat += equip_spd;
        updateStatDisplay();
    }
	
    public void updateStatDisplay()
    {
        StringBuilder str = new StringBuilder("Lvl:");
        str.Append(Level + ", ");
        str.Append("Att:" + (attack_stat) + ", ");
        str.Append("Def:" + (defend_stat) + ", ");
        str.Append("Spd:" + (speed_stat));

        foreach(Text temp in display_stats)
        {
            temp.text = str.ToString();
        }
        
    }

    public void updateStatFromString(string str)
    {
        //Debug.Log(str);
        //Att:+0,Def:+10,Spd:-3

        string anotherString = str.Substring(4);
        int posofDelim = anotherString.IndexOf(",");
        int.TryParse(anotherString.Substring(0,posofDelim), out equip_att);
        
        anotherString = anotherString.Substring(posofDelim + 5);
        posofDelim = anotherString.IndexOf(",");
        int.TryParse(anotherString.Substring(0, posofDelim), out equip_def);

        anotherString = anotherString.Substring(posofDelim + 5);
        int.TryParse(anotherString, out equip_spd);

        attack_stat += equip_att;
        defend_stat += equip_def;
        speed_stat += equip_spd;
        updateStatDisplay();

    }
	
    public void removeItem(string str)
    {
        string anotherString = str.Substring(4);
        int posofDelim = anotherString.IndexOf(",");
        int.TryParse(anotherString.Substring(0, posofDelim), out equip_att);

        anotherString = anotherString.Substring(posofDelim + 5);
        posofDelim = anotherString.IndexOf(",");
        int.TryParse(anotherString.Substring(0, posofDelim), out equip_def);

        anotherString = anotherString.Substring(posofDelim + 5);
        int.TryParse(anotherString, out equip_spd);
        // Debug.Log(str);
        attack_stat -= equip_att;
        defend_stat -= equip_def;
        speed_stat -= equip_spd;
        updateStatDisplay();
    }

    public int getAttStat()
    {
        return attack_stat;
    }
    public int getDefStat()
    {
        return defend_stat;
    }
    public int getSpdStat()
    {
        return speed_stat;
    }
}
