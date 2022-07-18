// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Effect/Distrotion"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _MainTex2 ("Sprite Texture2", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)
        _FlashColor ("Flash Color", Color) = (1,1,1,1)
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
    }

    SubShader
    {
        Tags
        { 
            "Queue"="Transparent" 
            "IgnoreProjector"="True" 
            "RenderType"="Transparent" 
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }
 
        Cull Off
        Lighting Off
        ZWrite Off
        Fog { Mode Off }
        Blend One OneMinusSrcAlpha
 
        Pass
        {
        CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile DUMMY PIXELSNAP_ON
            #include "UnityCG.cginc"
             
            struct appdata_t
            {
                float4 vertex   : POSITION;
                float4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
                float2 texcoord2  : TEXCOORD1;
            };
 
            struct v2f
            {
                float4 vertex   : SV_POSITION;
                fixed4 color    : COLOR;
                half2 texcoord  : TEXCOORD0;
                half2 texcoord2  : TEXCOORD1;
            };
             
            fixed4 _Color;
            fixed4 _FlashColor;

            v2f vert(appdata_t IN)
            {
                v2f OUT;
                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                OUT.texcoord = IN.texcoord;
                OUT.texcoord2 = IN.texcoord2;
                OUT.color = IN.color * _Color;
                #ifdef PIXELSNAP_ON
                OUT.vertex = UnityPixelSnap (OUT.vertex);
                #endif

                return OUT;
            }

            sampler2D _MainTex;
            sampler2D _MainTex2;

            fixed4 frag(v2f IN) : COLOR
            {
                fixed4 b = tex2D(_MainTex2,  float2(IN.texcoord2.x+ _Time.y * 0.1, IN.texcoord2.y + _Time.y * 0.2 ));
                fixed4 c = tex2D(_MainTex, IN.texcoord + b.r *0.2 - 0.1) * IN.color;
                // c.rgb = lerp(c.rgb,_FlashColor.rgb,_FlashAmount);
                c.rgb *= c.a;
            
                return c;
            }
        ENDCG
        }
    }
}