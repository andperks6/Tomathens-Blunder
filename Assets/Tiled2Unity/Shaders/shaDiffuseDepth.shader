Shader "Tiled2Unity/Diffuse Depth"
{
	Properties
	{
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Color) = (1,1,1,1)
		_CutOff("Cut off", float) = 0.1
	}

	SubShader
	{
		Tags
		{
			"Queue"="Transparent"
			"IgnoreProjector"="True"
			"RenderType"="Transparent"
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}

		Cull Off
		Lighting Off
		ZWrite On
		ZTest LEqual
		Blend One OneMinusSrcAlpha

		CGPROGRAM
		#pragma surface surf Lambert vertex:vert nofog keepalpha
		#pragma shader_feature PIXELSNAP_ON
		#pragma multi_compile _ ETC1_EXTERNAL_ALPHA

		sampler2D _MainTex;
		fixed4 _Color;
		float _CutOff;
		sampler2D _AlphaTex;


		struct Input
		{
			float2 uv_MainTex;
			fixed4 color;
		};
		
		void vert (inout appdata_full v, out Input o)
		{
			#if defined(PIXELSNAP_ON)
			v.vertex = UnityPixelSnap (v.vertex);
			#endif
			
			UNITY_INITIALIZE_OUTPUT(Input, o);
			o.color = v.color * _Color;
		}

		fixed4 SampleSpriteTexture (float2 uv)
		{
			fixed4 color = tex2D (_MainTex, uv);

#if ETC1_EXTERNAL_ALPHA
			color.a = tex2D (_AlphaTex, uv).r;
#endif //ETC1_EXTERNAL_ALPHA

			return color;
		}

		void surf (Input IN, inout SurfaceOutput o)
		{
			fixed4 c = SampleSpriteTexture (IN.uv_MainTex) * IN.color;
			o.Albedo = c.rgb * c.a;
			o.Alpha = c.a;

			if (c.a < _CutOff)
				discard;
		}
		ENDCG
	}

Fallback "Transparent/VertexLit"
}
