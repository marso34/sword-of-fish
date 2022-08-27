using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : MonoBehaviour
{   //Knife
    public Sprite[] BasicKnife;
    public Sprite[] CandyKnife;
    public Sprite[] PanKnife_R;
    public Sprite[] SpearKnife;
    public Sprite[] XKnife;
    public Sprite[] Rager_R;
    //Body
    public Sprite[] FirstTailAnims;
    public Sprite[] SharkTailAnims;
    public Sprite[] WaileTailAnims_R;
    public Sprite[] BlowfishTailAnims;
    public Sprite[] OctopusTailAnims;
    public Sprite[] InkOctAnims_E;
    public Sprite[] DieAnims;
    public Sprite[] PupleAnims_E;
    public Sprite[] BornAnims_E;
    public Sprite[] Gabock_E;

    public Sprite[] Granpa_V;
    public Gradient outlineColor;
    // public Color outlineColor = Color.white;

    [Range(0, 1)]
    public float t;
    public bool Flag;

    public SpriteRenderer spriteRenderer;
    public bool outline;
    public int outlineSize = 0;

    // float timer = 0f;

    private void Start()
    {
        // spriteRenderer = GetComponent<SpriteRenderer>();
        // outline = false;
        // Flag = false;
        // t = 0f;
    }

    private void Update()
    {
        // t += Flag ? Time.deltaTime : 0f;

        // // if (timer >= 0.1f) { // ±ôºýÀÓ
        // //     timer = 0f;
        // //     outlineSize ^= 1;
        // // }

        // if (t >= 1f || !Flag)
        //     t = 0f;

        // UpdateOutline(outline);
    }

    void UpdateOutline(bool outline)
    {
        // MaterialPropertyBlock mpb = new MaterialPropertyBlock();
        // spriteRenderer.GetPropertyBlock(mpb);
        // mpb.SetFloat("_Outline", outline ? 1f : 0);
        // mpb.SetColor("_OutlineColor", outlineColor.Evaluate(t));
        // mpb.SetFloat("_OutlineSize", outlineSize);
        // spriteRenderer.SetPropertyBlock(mpb);
    }
}
