shader_type canvas_item;

uniform float amplitude = 0.1; // 扰动的振幅
uniform float speed = 1.0; // 扰动的速度

void fragment() {
    // 获取当前像素的UV坐标
    vec2 uv = SCREEN_UV;

    // 使用时间和UV坐标生成扰动效果的偏移量
    float offset = sin(TIME * speed + uv.x * 10.0) * amplitude;

    // 根据偏移量对UV坐标进行扰动
    uv += vec2(offset, offset);

    // 根据扰动后的UV坐标获取纹理颜色
    vec4 color = texture(TEXTURE, uv);

    // 输出最终的颜色
    COLOR = color;
}