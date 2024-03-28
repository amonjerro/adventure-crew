Shader "Unlit/BattleProgress"
{
    Properties
    {
        _AllyVictoryPercentage ("Ally Victory", float) = 0.0
        _Color1 ("Color Ally", Color) = (1.0,1.0,1.0,1.0)
        _Color2 ("Color Enemy", Color) = (1.0, 1.0, 1.0, 1.0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float _AllyVictoryPercentage;
            fixed4 _Color1;
            fixed4 _Color2;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                float mask = i.uv.x <= _AllyVictoryPercentage;
                float invertedMask = i.uv.x > _AllyVictoryPercentage;
                float4 maskCol = float4(_Color1.rgb * mask, 1.0 );
                float4 inverseMaskCol = float4(_Color2.rgb * invertedMask, 1.0);
                fixed4 col = maskCol + inverseMaskCol;
                return col;
            }
            ENDCG
        }
    }
}
