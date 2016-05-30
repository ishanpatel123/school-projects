#pragma once
#ifndef TREE
#define TREE

#include "OGL3DCompositeObject.h"

#include <string>
	using std::string;

class Texture;
class OGLTexturedFlatSurface;
class Cuboid;
class Tree :
	public OGL3DCompositeObject
{

protected:
	Cuboid *leaves1;
	Cuboid *leaves2;
	Cuboid *leaves3;
	Cuboid *trunk;
	Cuboid *treePot;

public:
	Tree(const string& name);
	virtual ~Tree();
	void setShaderProgram(GLuint shaderProgram);
	void update(float elapsedSeconds);
	void render();

};

#endif
