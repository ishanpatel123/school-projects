#pragma once
#ifndef SOFA
#define SOFA

#include "OGL3DCompositeObject.h"

#include <string>
using std::string;

class Texture;
class OGLTexturedFlatSurface;
class Cuboid;
class Sofa :
	public OGL3DCompositeObject
{

protected:
	Cuboid *back;
	Cuboid *seat;
	Cuboid *armTopLeft;
	Cuboid *armTopRight;
	
public:
	Sofa(const string& name);
	virtual ~Sofa();
	void setShaderProgram(GLuint shaderProgram);
	void update(float elapsedSeconds);
	void render();

};

#endif
