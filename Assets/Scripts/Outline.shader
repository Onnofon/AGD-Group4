Shader "Unlit/Outline"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_OutlineColor("Outline color", Color) = (255,69,0,1)
		_OutlineWidth("Outline width", Range(1.0,5.0)) = 1.0
		_Speed("Speed", Range(1.0,5.0)) = 1.0
		_Color("Main color", Color) = (255,255,255,1)
    }

		CGINCLUDE
#include "UnityCG.cginc"

		struct appdata 
	{
		float4 vertex : POSITION;
		float3 normal : NORMAL;
	};

	struct v2f 
	{
		float4 pos : POSITION;
		float3 normal : NORMAL;
	};

	float _OutlineWidth;
	float4 _OutlineColor;
	float _Speed;

	//Expand every pixel on the normal
	v2f vert(appdata v) 
	{
		float _MoveAmount = 0.3;
		float _Distance = .03;
		
		v.vertex.xyz *= _OutlineWidth;
		//v.vertex.y += sin(_Time.y * _Speed + v.vertex.x * _MoveAmount) * _Distance;
		v2f o;
		o.pos = UnityObjectToClipPos(v.vertex);
		return o;
	}

		ENDCG

    SubShader
    {
        Tags { "Queue"="Transparent" }
        LOD 100

        Pass //Outline
        {
			ZWrite Off

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag

			half4 frag(v2f i) : COLOR
		{
			return _OutlineColor;
		}
			ENDCG
        }

			Pass //Normal render
		{
			ZWrite On
			Material
		{
			Diffuse[_Color]
			Ambient[_Color]
}
Lighting On

SetTexture[_MainTex]
		{
			ConstantColor[_Color]
}
SetTexture[_MainText]
		{
			Combine previous * primary DOUBLE
}
}
    }
}
