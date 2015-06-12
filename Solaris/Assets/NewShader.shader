Shader "Show Insides" {

	Properties{
		_MainTex ("Base (RGB) Trans (A)",2D) = "white" {}
	}

	
     SubShader {
       
       Tags { "RenderType" = "Transparent" }
       
       Cull Off
       
       CGPROGRAM
       
       #pragma surface surf Lambert vertex:vert alpha
       
       sampler2D _MainTex;
       
       void vert(inout appdata_full v)
       {
           v.normal.xyz = v.normal * -1;
       }
       
       struct Input {
           float4 color : COLOR;
           float2 uv_MainTex;
       };
       
       void surf (Input IN, inout SurfaceOutput o) {
       	fixed4 c = tex2D(_MainTex,IN.uv_MainTex);
           o.Albedo = 0.2;
           o.Alpha = c.a;
       }
       
       ENDCG
       
     }
     
     Fallback "Diffuse"
     
   }