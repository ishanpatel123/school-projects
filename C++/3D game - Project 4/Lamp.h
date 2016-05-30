#pragma once
#ifndef LAMP
#define LAMP

#include "OGL3DCompositeObject.h"

#include <string>
using std::string;

class Texture;
class OGLTexturedFlatSurface;
class Cuboid;
class Lamp :
	public OGL3DCompositeObject
{

protected:
	Cuboid *shade;
	Cuboid *tube;
	Cuboid *base;

public:
	Lamp(const string& name);
	virtual ~Lamp();
	void setShaderProgram(GLuint shaderProgram);
	void update(float elapsedSeconds);
	void render();

};

#endif
