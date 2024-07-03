shader_type canvas_item;

uniform sampler2D SCREEN_TEXTURE : hint_screen_texture, filter_nearest;

void fragment() {
	vec4 px = texture(SCREEN_TEXTURE, SCREEN_UV);
	px = px.bgra;
	COLOR = vec4(px.rgb,1.0);
}