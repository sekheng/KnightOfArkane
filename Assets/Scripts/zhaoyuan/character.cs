using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;

public class character : MonoBehaviour {
    public int Level;
    public int attack_stat;
    public int defend_stat;
    public int speed_stat;
    public int stst_points;
    public Text display_stats;
    private int temp_att;
    private int temp_def;
    private int temp_spd;
   
    // Use this for initialization
    void Start () {
        
        temp_att = 0;
        temp_def = 0;
        temp_spd = 0;
        attack_stat += temp_att;
        defend_stat += temp_def;
        speed_stat += temp_spd;
        updateStatDisplay();
    }
	
    public void updateStatDisplay()
    {
        StringBuilder str = new StringBuilder("Lvl:");
        str.Append(Level + ", ");
        str.Append("Att:" + (attack_stat) + ", ");
        str.Append("Def:" + (defend_stat) + ", ");
        str.Append("Spd:" + (speed_stat));

        display_stats.text = str.ToString();
    }

    public void updateStatFromString(string str)
    {
        //Debug.Log(str);
        //Att:+0,Def:+10,Spd:-3

        string anotherString = str.Substring(4);
        int posofDelim = anotherString.IndexOf(",");
        int.TryParse(anotherString.Substring(0,posofDelim), out temp_att);
        
        anotherString = anotherString.Substring(posofDelim + 5);
        posofDelim = anotherString.IndexOf(",");
        int.TryParse(anotherString.Substring(0, posofDelim), out temp_def);

        anotherString = anotherString.Substring(posofDelim + 5);
        int.TryParse(anotherString, out temp_spd);

        attack_stat += temp_att;
        defend_stat += temp_def;
        speed_stat += temp_spd;
        updateStatDisplay();

    }
	
    public void removeItem(string str)
    {
        string anotherString = str.Substring(4);
        int posofDelim = anotherString.IndexOf(",");
        int.TryParse(anotherString.Substring(0, posofDelim), out temp_att);

        anotherString = anotherString.Substring(posofDelim + 5);
        posofDelim = anotherString.IndexOf(",");
        int.TryParse(anotherString.Substring(0, posofDelim), out temp_def);

        anotherString = anotherString.Substring(posofDelim + 5);
        int.TryParse(anotherString, out temp_spd);
        // Debug.Log(str);
        attack_stat -= temp_att;
        defend_stat -= temp_def;
        speed_stat -= temp_spd;
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
