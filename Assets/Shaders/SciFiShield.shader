// Shader created with Shader Forge v1.40 
// Shader Forge (c) Freya Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.40;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,cpap:True,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0,fgcg:0,fgcb:0,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:True,fnfb:True,fsmp:False;n:type:ShaderForge.SFN_Final,id:4795,x:33736,y:32351,varname:node_4795,prsc:2|emission-5303-OUT,alpha-6395-OUT,voffset-8990-OUT;n:type:ShaderForge.SFN_Tex2d,id:6074,x:31824,y:31994,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3a5a96df060a5cf4a9cc0c59e13486b7,ntxv:0,isnm:False;n:type:ShaderForge.SFN_VertexColor,id:2053,x:32717,y:32256,varname:node_2053,prsc:2;n:type:ShaderForge.SFN_Color,id:797,x:31824,y:31778,ptovrint:True,ptlb:Color,ptin:_TintColor,varname:_TintColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.9433962,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_NormalVector,id:5361,x:30891,y:32712,prsc:2,pt:False;n:type:ShaderForge.SFN_Transform,id:2355,x:31079,y:32712,varname:node_2355,prsc:2,tffrom:0,tfto:1|IN-5361-OUT;n:type:ShaderForge.SFN_ComponentMask,id:3615,x:31255,y:32712,varname:node_3615,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-2355-XYZ;n:type:ShaderForge.SFN_RemapRange,id:5783,x:31447,y:32712,varname:node_5783,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-3615-OUT;n:type:ShaderForge.SFN_Rotator,id:4380,x:31651,y:32712,varname:node_4380,prsc:2|UVIN-5783-OUT,ANG-3004-OUT;n:type:ShaderForge.SFN_Multiply,id:4526,x:31599,y:32951,varname:node_4526,prsc:2|A-3004-OUT,B-3121-T;n:type:ShaderForge.SFN_Time,id:3121,x:31287,y:33090,varname:node_3121,prsc:2;n:type:ShaderForge.SFN_ValueProperty,id:3004,x:31287,y:32967,ptovrint:False,ptlb:Noise Speed,ptin:_NoiseSpeed,varname:_NoiseSpeed,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Panner,id:2269,x:31903,y:32775,varname:node_2269,prsc:2,spu:0.5,spv:0.25|UVIN-4380-UVOUT,DIST-4526-OUT;n:type:ShaderForge.SFN_Tex2d,id:1442,x:32110,y:32775,ptovrint:False,ptlb:Noise,ptin:_Noise,varname:_Noise,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:28c7aad1372ff114b90d330f8a2dd938,ntxv:0,isnm:False|UVIN-2269-UVOUT;n:type:ShaderForge.SFN_Multiply,id:8990,x:32310,y:32993,varname:node_8990,prsc:2|A-1442-A,B-2119-OUT,C-5361-OUT;n:type:ShaderForge.SFN_ValueProperty,id:2119,x:32110,y:33004,ptovrint:False,ptlb:Vertex Offset,ptin:_VertexOffset,varname:_VertexOffset,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0.2;n:type:ShaderForge.SFN_Fresnel,id:1676,x:31747,y:32567,varname:node_1676,prsc:2|EXP-1294-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:2568,x:31981,y:32544,ptovrint:False,ptlb:Use of Fresnel,ptin:_UseofFresnel,varname:_UseofFresnel,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-4536-OUT,B-1676-OUT;n:type:ShaderForge.SFN_Vector1,id:4536,x:31788,y:32486,varname:node_4536,prsc:2,v1:0;n:type:ShaderForge.SFN_Multiply,id:9114,x:32334,y:32686,varname:node_9114,prsc:2|A-797-A,B-1442-A,C-6074-R;n:type:ShaderForge.SFN_Add,id:6284,x:32510,y:32524,varname:node_6284,prsc:2|A-2568-OUT,B-9114-OUT;n:type:ShaderForge.SFN_Clamp01,id:7653,x:32723,y:32524,varname:node_7653,prsc:2|IN-6284-OUT;n:type:ShaderForge.SFN_Multiply,id:6395,x:32966,y:32522,varname:node_6395,prsc:2|A-7653-OUT,B-4998-OUT,C-2053-A,D-8324-A;n:type:ShaderForge.SFN_Slider,id:4998,x:32566,y:32709,ptovrint:False,ptlb:Opacity,ptin:_Opacity,varname:_Opacity,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Multiply,id:2565,x:32274,y:31868,varname:node_2565,prsc:2|A-797-RGB,B-6074-R,C-1442-RGB;n:type:ShaderForge.SFN_Multiply,id:1809,x:32330,y:32026,varname:node_1809,prsc:2|A-8324-RGB,B-1676-OUT;n:type:ShaderForge.SFN_Color,id:8324,x:31824,y:31537,ptovrint:False,ptlb:Fresnels Color,ptin:_FresnelsColor,varname:_FresnelsColor,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.122597,c2:0.4518364,c3:0.8962264,c4:1;n:type:ShaderForge.SFN_Add,id:6619,x:32551,y:31900,varname:node_6619,prsc:2|A-2565-OUT,B-1809-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1294,x:31562,y:32580,ptovrint:False,ptlb:Fresnel Val,ptin:_FresnelVal,varname:_FresnelVal,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Multiply,id:5303,x:32888,y:32009,varname:node_5303,prsc:2|A-6619-OUT,B-7287-OUT,C-2053-RGB;n:type:ShaderForge.SFN_ValueProperty,id:7287,x:32627,y:32116,ptovrint:False,ptlb:Emission,ptin:_Emission,varname:_Emission,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;proporder:6074-797-3004-1442-2119-2568-4998-8324-1294-7287;pass:END;sub:END;*/

Shader "Shader Forge/SciFiShield" {
    Properties {
        _MainTex ("MainTex", 2D) = "white" {}
        _TintColor ("Color", Color) = (0.9433962,0,0,1)
        _NoiseSpeed ("Noise Speed", Float ) = 2
        _Noise ("Noise", 2D) = "white" {}
        _VertexOffset ("Vertex Offset", Float ) = 0.2
        [MaterialToggle] _UseofFresnel ("Use of Fresnel", Float ) = 0
        _Opacity ("Opacity", Range(0, 1)) = 1
        _FresnelsColor ("Fresnels Color", Color) = (0.122597,0.4518364,0.8962264,1)
        _FresnelVal ("Fresnel Val", Float ) = 1
        _Emission ("Emission", Float ) = 2
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _Noise; uniform float4 _Noise_ST;
            UNITY_INSTANCING_BUFFER_START( Props )
                UNITY_DEFINE_INSTANCED_PROP( float4, _TintColor)
                UNITY_DEFINE_INSTANCED_PROP( float, _NoiseSpeed)
                UNITY_DEFINE_INSTANCED_PROP( float, _VertexOffset)
                UNITY_DEFINE_INSTANCED_PROP( fixed, _UseofFresnel)
                UNITY_DEFINE_INSTANCED_PROP( float, _Opacity)
                UNITY_DEFINE_INSTANCED_PROP( float4, _FresnelsColor)
                UNITY_DEFINE_INSTANCED_PROP( float, _FresnelVal)
                UNITY_DEFINE_INSTANCED_PROP( float, _Emission)
            UNITY_INSTANCING_BUFFER_END( Props )
            struct VertexInput {
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                UNITY_VERTEX_INPUT_INSTANCE_ID
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                UNITY_SETUP_INSTANCE_ID( v );
                UNITY_TRANSFER_INSTANCE_ID( v, o );
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float _NoiseSpeed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _NoiseSpeed );
                float4 node_3121 = _Time;
                float node_4380_ang = _NoiseSpeed_var;
                float node_4380_spd = 1.0;
                float node_4380_cos = cos(node_4380_spd*node_4380_ang);
                float node_4380_sin = sin(node_4380_spd*node_4380_ang);
                float2 node_4380_piv = float2(0.5,0.5);
                float2 node_4380 = (mul((mul( unity_WorldToObject, float4(v.normal,0) ).xyz.rgb.rg*2.0+-1.0)-node_4380_piv,float2x2( node_4380_cos, -node_4380_sin, node_4380_sin, node_4380_cos))+node_4380_piv);
                float2 node_2269 = (node_4380+(_NoiseSpeed_var*node_3121.g)*float2(0.5,0.25));
                float4 _Noise_var = tex2Dlod(_Noise,float4(TRANSFORM_TEX(node_2269, _Noise),0.0,0));
                float _VertexOffset_var = UNITY_ACCESS_INSTANCED_PROP( Props, _VertexOffset );
                v.vertex.xyz += (_Noise_var.a*_VertexOffset_var*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                UNITY_SETUP_INSTANCE_ID( i );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
////// Emissive:
                float4 _TintColor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _TintColor );
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float _NoiseSpeed_var = UNITY_ACCESS_INSTANCED_PROP( Props, _NoiseSpeed );
                float4 node_3121 = _Time;
                float node_4380_ang = _NoiseSpeed_var;
                float node_4380_spd = 1.0;
                float node_4380_cos = cos(node_4380_spd*node_4380_ang);
                float node_4380_sin = sin(node_4380_spd*node_4380_ang);
                float2 node_4380_piv = float2(0.5,0.5);
                float2 node_4380 = (mul((mul( unity_WorldToObject, float4(i.normalDir,0) ).xyz.rgb.rg*2.0+-1.0)-node_4380_piv,float2x2( node_4380_cos, -node_4380_sin, node_4380_sin, node_4380_cos))+node_4380_piv);
                float2 node_2269 = (node_4380+(_NoiseSpeed_var*node_3121.g)*float2(0.5,0.25));
                float4 _Noise_var = tex2D(_Noise,TRANSFORM_TEX(node_2269, _Noise));
                float4 _FresnelsColor_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FresnelsColor );
                float _FresnelVal_var = UNITY_ACCESS_INSTANCED_PROP( Props, _FresnelVal );
                float node_1676 = pow(1.0-max(0,dot(normalDirection, viewDirection)),_FresnelVal_var);
                float _Emission_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Emission );
                float3 emissive = (((_TintColor_var.rgb*_MainTex_var.r*_Noise_var.rgb)+(_FresnelsColor_var.rgb*node_1676))*_Emission_var*i.vertexColor.rgb);
                float3 finalColor = emissive;
                float _UseofFresnel_var = lerp( 0.0, node_1676, UNITY_ACCESS_INSTANCED_PROP( Props, _UseofFresnel ) );
                float _Opacity_var = UNITY_ACCESS_INSTANCED_PROP( Props, _Opacity );
                fixed4 finalRGBA = fixed4(finalColor,(saturate((_UseofFresnel_var+(_TintColor_var.a*_Noise_var.a*_MainTex_var.r)))*_Opacity_var*i.vertexColor.a*_FresnelsColor_var.a));
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    CustomEditor "ShaderForgeMaterialInspector"
}
