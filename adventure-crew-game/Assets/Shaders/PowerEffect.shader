Shader "Unlit/PowerEffect"
{
    Properties
    {
        _PowerColor ("Power Color", Color) = (1.0, 1.0, 1.0, 1.0)
        _Frequency ("Frequency", float) = 1.0
    }
    SubShader
    {
        Tags { 
            "RenderType"="Transparent"
            "Queue"="Transparent"
            }


        Pass
        {
            Cull Off
            ZWrite Off
            Blend One One

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag


            fixed4 _PowerColor;
            float _Frequency;
            struct appdata
            {
                float4 vertex : POSITION;
                float3 normals : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {

                float2 uv : TEXCOORD1;
                float3 normal : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };


            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = v.normals;
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float mask = sin(i.uv.y * _Frequency - _Time.y) * 0.5 + 0.5;
                mask *= 1-(abs(i.normal.y) > 0.999);
                mask *= 1-i.uv.y;
                return _PowerColor * mask;
            }
            ENDCG
        }
    }
}
