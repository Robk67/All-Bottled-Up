using UnityEngine;
using System.Collections;

public class ColorShaderScript : MonoBehaviour {

    public Material mat;
    private float PlayerRed;
    private float PlayerBlue;
    private float PlayerYellow;
    private PowerupStateHandler playerPower;

    public GameObject player;

    void Start()
    {
        playerPower = player.GetComponent<PowerupStateHandler>();
        PlayerRed = playerPower.m_RedBottleAmount;
        PlayerBlue = playerPower.m_BlueBottleAmount;
        PlayerYellow = playerPower.m_YellowBottleAmount;
    }

    void Update()
    {
        PlayerRed = playerPower.m_RedBottleAmount;
        PlayerBlue = playerPower.m_BlueBottleAmount;
        PlayerYellow = playerPower.m_YellowBottleAmount;
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        mat.SetFloat("RedAmount", PlayerRed);
        mat.SetFloat("BlueAmount", PlayerBlue);
        mat.SetFloat("YellowAmount", PlayerYellow);
        Graphics.Blit(src, dest, mat);
    }
}
