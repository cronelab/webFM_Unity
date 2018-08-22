Shader "Unlit/SpecialFX/Cool Hologram"
{

	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Color (RGB) Alpha (A)", 2D) = "white" {}
		_Transparency("Transparency", Range(0.0,1.0)) = 1.0
	}
	SubShader{
		Tags{ "Queue" = "Transparent" "IgnoreProjector"="True" "RenderType" = "Transparent" }
		LOD 200

		Pass {
			ZWrite On
			ColorMask 0
		}

		CGPROGRAM
#pragma surface surf Lambert alpha

		sampler2D _MainTex;


	struct Input {
		float2 uv_MainTex;
	};

	half _Glossiness;
	half _Metallic;
	half _Transparency;
	fixed4 _Color;



	UNITY_INSTANCING_BUFFER_START(Props)
		// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf(Input IN, inout SurfaceOutput o) {
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;

			o.Alpha = tex2D(_MainTex, IN.uv_MainTex).a * _Transparency;
		}
	ENDCG
	}
		FallBack "Diffuse"
}
