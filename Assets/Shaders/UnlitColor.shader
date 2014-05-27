Shader "Custom/UnlitColor" {
	Properties {
		_Color ("Color", Color) = (1,0,1,1)
	}
	SubShader {
		Tags {"Queue" = "Transparent" }
		Pass {
		Blend SrcAlpha OneMinusSrcAlpha 
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#include "UnityCG.cginc"	
		float4 _Color;
		struct v2f {
		    float4  pos : SV_POSITION;
		    float2  uv : TEXCOORD0;
		};
		struct Input {
			float2 uv_MainTex;
		};
		float4 _MainTex_ST;	
		v2f vert (appdata_base v){
		    v2f o;
		    o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
		    o.uv = TRANSFORM_TEX (v.texcoord, _MainTex);
		    return o;
		}	
		
		half4 frag (v2f i) : COLOR{		
			return _Color;
		}
		ENDCG
		}
	} 
	FallBack "Diffuse"
}