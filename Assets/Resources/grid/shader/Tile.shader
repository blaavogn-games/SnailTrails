Shader "Custom/Tile" {
	Properties {
		_Layer ("Layer",Float) = 1
	}
	SubShader {
		Tags { "RenderType"="Opaque" "Queue" = "Geometry" }
		Pass {
			Stencil {
				Ref [_Layer]
				Comp Never
				Fail Replace
			}
		}

	} 
	FallBack "Diffuse"
}
