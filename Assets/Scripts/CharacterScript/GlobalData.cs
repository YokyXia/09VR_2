using System.Collections.Generic;
//using Unity.Mathematics;

public class GlobalData
{
    private GlobalData()
    {

    }

    private static GlobalData _instance;
    public static GlobalData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GlobalData();
            }
            return _instance;
        }
    }


    public float maxHealth { get; set; } = 100f;


    public float speed { get; set; } = 5f;

    public float attackSpeed { get; set; } = 1f;

    public bool berserker { get; set; } = false;

    public bool archer { get; set; } = false;

    public int lb { get; set; } = 100;

    public float x { get; set; } = -10f;

    public float y { get; set; } = -10f;

    public float z { get; set; } = -10f;

    public bool pos_flag { get; set; } = false;

    public bool done_flag { get; set;} = false;

    public bool sage { get; set; } = false;





}