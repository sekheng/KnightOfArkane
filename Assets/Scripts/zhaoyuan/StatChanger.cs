using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;

public class StatChanger : MonoBehaviour {

    public character player;
    public Text text, textForAllocationPoints;


    public void addAttStat()
    {
        if(player.stat_points > 0)
        {
            player.temp_att += 1;
            player.stat_points -= 1;
            player.stat_points_used_att += 1;
            showPreviewStatTextForAftCfm();
        }
    }

    public void addDefStat()
    {
        if (player.stat_points > 0)
        {
            player.temp_def += 1;
            player.stat_points -= 1;
            player.stat_points_used_def += 1;
            showPreviewStatTextForAftCfm();
        }
    }

    public void addSpdStat()
    {
        if (player.stat_points > 0)
        {
            player.temp_spd += 1;
            player.stat_points -= 1;
            player.stat_points_used_spd += 1;
            showPreviewStatTextForAftCfm();
        }
    }

    public void minusAttStat()
    {
        if(player.stat_points_used_att > 0)
        {
            player.temp_att -= 1;
            player.stat_points += 1;
            player.stat_points_used_att -= 1;
            showPreviewStatTextForAftCfm();
        }
    }

    public void minusDefStat()
    {
        if (player.stat_points_used_def > 0)
        {
            player.temp_def -= 1;
            player.stat_points += 1;
            player.stat_points_used_def -= 1;
            showPreviewStatTextForAftCfm();
        }
    }


    public void minusSpdStat()
    {
        if (player.stat_points_used_spd > 0)
        {
            player.temp_spd -= 1;
            player.stat_points += 1;
            player.stat_points_used_spd -= 1;
            showPreviewStatTextForAftCfm();
        }
    }

    public void showPreviewStatTextForAftCfm()
    {
        StringBuilder str = new StringBuilder("Lvl:");
        str.Append(player.Level + ", ");
        str.Append("Att:" + (player.attack_stat + player.temp_att) + ", ");
        str.Append("Def:" + (player.defend_stat + player.temp_def) + ", ");
        str.Append("Spd:" + (player.speed_stat + player.temp_spd));

        text.text = str.ToString();

        StringBuilder str2 = new StringBuilder("Points Available:");
        str2.Append(player.stat_points+ " ");
        str2.Append("Points Used:");
        str2.Append((player.stat_points_used_att + player.stat_points_used_def + player.stat_points_used_spd));

        textForAllocationPoints.text = str2.ToString();
    }

    public void updatePlayerStats()
    {
        player.attack_stat += player.temp_att;
        player.defend_stat += player.temp_def;
        player.speed_stat += player.temp_spd;
        player.temp_att = 0;
        player.temp_def = 0;
        player.temp_spd = 0;
        player.stat_points_used_att = 0;
        player.stat_points_used_def = 0;
        player.stat_points_used_spd = 0;
        player.updateStatDisplay();
    }

    public void resetStatPointUses()
    {
        player.temp_att = 0;
        player.temp_def = 0;
        player.temp_spd = 0;
        player.stat_points += (player.stat_points_used_att + player.stat_points_used_def + player.stat_points_used_spd);
        player.stat_points_used_att = 0;
        player.stat_points_used_def = 0;
        player.stat_points_used_spd = 0;
        player.updateStatDisplay();
        showPreviewStatTextForAftCfm();
    }
    // Use this for initialization
    void Start () {

        
    }
	
	
}
