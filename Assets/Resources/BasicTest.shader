Shader "Custom/BasicTest"
{
	Properties
	{}
	SubShader
	{
		Tags{ "Queue" = "Geometry" }
		//Blend SrcAlpha OneMinusSrcAlpha
		
		Pass
		{
			CGPROGRAM
			
			#pragma exclude_renderers ps3 xbox360 flash
			#pragma fragmentoption ARB_precision_hint_fastest
			
			#pragma vertex vert
			#pragma fragment frag
			
			#inlucde "UnityCG.cginc"
			
			uniform fixed4 _Color;
			
			struct vertexInput
			{
				float4 vertex : POSITION;
			};
			
			struct fragmentInput
			{
				float4 pos : SV_POSITION;
				float4 color : COLOR0;
			};
			
			fragmentInput vert( vertexInput i)
			{
				fragmentInput o;
				o.pos = mul( UNITY_MATRIX_MVP, i.vertex );
				o.color = _Color;
				
				return o;
			}
			
			halv4 frag( fragmentInput i) : COLOR
			{
				return half4( 0.0, 0.0, 1.0, 0.2);
				//return i.color;
			}			
			ENDCG
		}
	} 
	FallBack "Diffuse"
}
