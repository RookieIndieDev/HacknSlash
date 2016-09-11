﻿Shader "Custom/NightShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		PlayerPos("playerPosition", Float) = (0,0,0,0)
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

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			float4 playerPosition;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);

				float Radius = 100;


				if(distance(i.vertex, playerPosition) > Radius)
				{
					col.r = -0.2f;
					col.g -= 0.2f;
					col.b -= 0.1f;
				}
				//else
				//{
				//	col.r = -0.2f;
					//col.g -= 0.05f;
				//}
				return col;
			}
			ENDCG
		}
	}
}
