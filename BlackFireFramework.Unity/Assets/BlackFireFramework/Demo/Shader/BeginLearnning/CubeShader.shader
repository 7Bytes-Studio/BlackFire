// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/CubeShader"
{
    Properties
    {
        _Size ("Size",float) = 0
        _Color ("Color",Color)=(0.6,0.6,0.6,0.6)
    
    }

	SubShader
	{
	    pass
	    {
	    	CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			uniform float _Size;
			uniform fixed4 _Color;
			
			float4 vert(float4 v:POSITION):SV_POSITION
			{
			    return UnityObjectToClipPos(v*float(_Size));
			}
			
			fixed4 frag():SV_Target
			{
			    return fixed4(_Color);
			}
			
			ENDCG
	    }

	}
}
