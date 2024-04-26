shader_type canvas_item;

// 自定义属性
uniform vec4 start_color : source_color = vec4(1.0, 0.0, 0.0, 1.0);
uniform vec4 end_color : source_color = vec4(0.0, 0.0, 1.0, 1.0);
uniform vec2 gradient_direction = vec2(0.0, 1.0);
uniform float start_position : hint_range(0.0, 1.0) = 0.0;
uniform float end_position : hint_range(0.0, 1.0) = 1.0;

void fragment() {
    // 计算渐变方向
    vec2 uv = SCREEN_UV;
    vec2 gradient_dir = normalize(gradient_direction);

    // 计算渐变位置
    float position = clamp((dot(uv, gradient_dir) - start_position) / (end_position - start_position), 0.0, 1.0);

    // 计算渐变颜色
    vec4 gradient_color = mix(start_color, end_color, position);
	gradient_color.a = 1.0 - step(position, 0.0);

    COLOR = gradient_color;
}