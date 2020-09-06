Shader "Lyudmil/Particle Blended" 
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags 
		{
			"RenderType"="Transparent"
			"Queue"="Transparent" 
			"PreviewType"="Plane"
		}
		Blend SrcAlpha OneMinusSrcAlpha 
		ZWrite Off

		Pass
		{
			CGPROGRAM
			#include "UnityCG.cginc"
	
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_instancing

			sampler2D _MainTex;
			fixed4 _MainTex_ST;

			struct appdata 
			{
				float4 vertex : POSITION;
				fixed2 uv : TEXCOORD0;
				// fixed4 color : COLOR;
				fixed3 normal : NORMAL;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
			
			struct v2f 
			{
				float4 pos : SV_POSITION;
				fixed4 posWorld : TEXCOORD1;	
				fixed2 uv : TEXCOORD0;
				// fixed4 color : COLOR;
				fixed3 normal : NORMAL;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			v2f vert (appdata v)
			{
				v2f o;
				
				UNITY_SETUP_INSTANCE_ID(v);
				UNITY_TRANSFER_INSTANCE_ID(v, o);
				


				v.vertex = mul(unity_WorldToObject, v.vertex);
				
				o.pos = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.posWorld = mul(unity_ObjectToWorld, v.vertex);
				o.normal = mul (UNITY_MATRIX_MV, v.normal);
				// o.color = v.color;
				return o;
			}

			fixed4 frag(v2f i) : SV_TARGET
			{
				fixed4 mainTex = tex2D(_MainTex, i.uv);

				return mainTex;
			}

			ENDCG
		}
	}
	Fallback "Curved Unlit Surface"
}
