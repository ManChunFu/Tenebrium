Shader "Unlit/MotionBlurShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Radius("Radius", Range(0, 0.2)) = 0
	}
		SubShader
		{
			Tags{ "Queue" = "Transparent" }
			LOD 100
			
			Pass
			{
				 Tags{ "LightMode" = "Always" }
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				//#pragma fragmentoption ARB_precision_hint_fastest
				#include "UnityCG.cginc"
				struct appdata
				{
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct v2f
				{
					float2 uv : TEXCOORD0;
					UNITY_FOG_COORDS(1)
					float4 vertex : SV_POSITION;
				};

				sampler2D _MainTex;
				float4 _MainTex_ST;
				float _Radius;

				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = TRANSFORM_TEX(v.uv, _MainTex);
					UNITY_TRANSFER_FOG(o,o.vertex);
					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{
					float screenPos = _ScreenParams.y / _ScreenParams.x;
					float4 col = 0;
					for (float index = 0; index < 10; index++)
					{
						float2 uv = i.uv + float2((index / 9 - 0.5) * _Radius * screenPos, 0);
						col += tex2D(_MainTex, uv);
					}
					col = col / 10;
					UNITY_APPLY_FOG(i.fogCoord, col);
					return col;
				}
				ENDCG
			}
		}
}
