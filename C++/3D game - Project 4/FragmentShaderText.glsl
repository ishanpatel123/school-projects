#version 330

in vec2 fragTexCoord;

out vec4 color;

uniform sampler2D tex;

void main()
{
	vec4 texFragColor = texture(tex, fragTexCoord);
	texFragColor.a = 0.2;
	color = texFragColor;
}