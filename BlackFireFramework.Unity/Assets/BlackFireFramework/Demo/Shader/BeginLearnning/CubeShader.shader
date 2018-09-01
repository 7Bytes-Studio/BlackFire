// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/CubeShader"
{
    Properties
    {
        _Size ("Size",float) = 1
    }

	SubShader
	{
		LOD 100

	    pass
	    {
	    	CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			struct a2v
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 texcoord:TEXCOORD0;
			};

			struct v2f
			{
				float4 pos:SV_POSITION;
				fixed3 color:COLOR0;
			};
			
			v2f vert(a2v i)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(i.vertex);
				o.color = i.normal*0.5+fixed3(0.5,0.5,0.5); //normal的分量为[-1,1]
				return o;
			}
			
			fixed4 frag(v2f i):SV_Target
			{
			    return fixed4(i.color,1.0);
			}
			
			ENDCG
	    }

	}
}
