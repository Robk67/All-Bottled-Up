Shader "Custom/NewImageEffectShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

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

            uniform float RedAmount;
            uniform float BlueAmount;
            uniform float YellowAmount;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;

			half4 frag (v2f i) : SV_Target
			{
				half4 texcol = tex2D(_MainTex, i.uv);
                float origRed = texcol.r;
                float origGreen = texcol.g;
                float origBlue = texcol.b;
                texcol.rgb = dot(texcol.rgb, float3(1, 1, 1)) / 3;
                texcol.r += (origRed - texcol.r) * RedAmount;
                texcol.g += (origGreen - texcol.g) * YellowAmount;
                texcol.b += (origBlue - texcol.b) * BlueAmount;


				return texcol;
			}
			ENDCG
		}
	}
}
