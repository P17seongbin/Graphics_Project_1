// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/SimpleUnlitTexturedShader"
{
	Properties // 셰이더 속성 선언부, 이름과 타입이 일치해야 함
	{
		// Color property for material inspector, default to white
		_Color("Main Color", Color) = (1,1,1,1)
	}
	
	SubShader
	{
		Pass
		{

			CGPROGRAM

			#pragma vertex vert //vertex 프로그램은 vert 함수에 있습니다.
			#pragma fragment frag //fragment 프로그램은 frag 함수에 있습니다.
			#include "UnityCG.cginc"

			// vertex에서 fragment 로 전달하는 인자
			struct v2f {
				float4 pos : SV_POSITION;  // SV_POSITION 등의 대문자: "semantics": 의도를 명시함
				fixed3 color : COLOR0;
				float3 norm : NORMAL;
			};
			float square(float i) {
				return i / 5;
			}
			

			v2f vert(appdata_base v) // vertex shader 작성부
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.color = v.normal * square(0.5) + 0.5;
				o.norm = v.normal;
				return o;
			}


			fixed4 frag(v2f j) : SV_Target // fragment shader 작성부
			{
				return fixed4(j.color * j.norm, 1); // 
			}
			ENDCG
		}
	}
}