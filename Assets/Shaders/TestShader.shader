Shader "Custom/TestShader" {

SubShader {
    Pass{

        CGPROGRAM

        #pragma exclude_renderers gles
        #pragma fragment frag

        #include "UnityCG.cginc"
		#pragma vertex vert
		v2f_img vert (appdata_base v) {
		    v2f_img o;
		    o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
		    o.uv = v.texcoord;
		    return o;
		}
        uniform sampler2D _MainTex;

        fixed4 frag(v2f_img i) : COLOR{
            fixed4 currentPixel = tex2D(_MainTex, i.uv);

            fixed grayscale = Luminance(currentPixel.rgb);
            fixed4 output = currentPixel;

            output.rgb = grayscale;
            output.a = currentPixel.a;

            //output.rgb = 0;

            return output;
        }

        ENDCG
    }

}

FallBack "VertexLit"
}