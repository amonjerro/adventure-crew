/*
This shader is from tutorial https://www.youtube.com/watch?v=_UBuZXG-B_0 
*/
Shader "HealthBar/HealthBarShader"
{
    Properties
    {
        _Health("Health", Range(0, 1)) = 0
        _LowColor("Low Health Color", Color) = (1,0,0,0.5)
        _HighColor("High Health Color", Color) = (0,1,0,0.5)
    }
    SubShader
    {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        Cull front 
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

            float _Health;
            fixed4 _LowColor;
            fixed4 _HighColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                if(i.uv.x > _Health){
                    return (0,0,0,0);
                }
                return lerp(_LowColor, _HighColor, _Health);
            }
            ENDCG
        }
    }
}
