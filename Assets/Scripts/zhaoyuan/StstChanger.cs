using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;

public class StstChanger : MonoBehaviour {

    public character player;
    public Text text;


    public void addAttStat()
    {
        if(player.stat_points > 0)
        {
            player.temp_att += 1;
            player.stat_points -= 1;
            player.stat_points_used += 1;
        }
    }

    public void addDefStat()
    {
        if (player.stat_points > 0)
        {
            player.temp_def += 1;
            player.stat_points -= 1;
            player.stat_points_used += 1;
        }
    }

    public void addSpdStat()
    {
        if (player.stat_points > 0)
        {
            player.temp_spd += 1;
            player.stat_points -= 1;
            player.stat_points_used += 1;
        }
    }

    public void minusAttStat()
    {
        if(player.stat_points_used > 0)
        {
            player.temp_def -= 1;
            player.stat_points += 1;
            player.stat_points_used -= 1;
        }
    }

    public void minusDefStat()
    {
        if (player.stat_points_used > 0)
        {
            player.temp_def -= 1;
            player.stat_points += 1;
            player.stat_points_used -= 1;
        }
    }


    public void minusSpdStat()
    {
        if (player.stat_points_used > 0)
        {
            player.temp_spd -= 1;
            player.stat_points += 1;
            player.stat_points_used -= 1;
        }
    }

    public void showPreviewStatTextForAftCfm()
    {
        StringBuilder str = new StringBuilder("Lvl:");
        str.Append(player.Level + ", ");
        str.Append("Att:" + (player.attack_stat + player.temp_att) + ", ");
        str.Append("Def:" + (player.defend_stat + player.temp_def) + ", ");
        str.Append("Spd:" + (player.speed_stat + player.temp_spd));
    }
    // Use this for initialization
    void Start () {
	
	}
	
	
}
