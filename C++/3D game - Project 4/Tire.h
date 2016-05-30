#pragma once
#ifndef TIRE
#define TIRE

#include "OGL3DCompositeObject.h"

#include <string>
using std::string;

class Cuboid;
class Axis;
class Sword;

class Tire :
	public OGL3DCompositeObject
{
protected:
	Cuboid *tire1;

private:
	Axis *axis;
	float rotateDegrees;

public:
	Tire(const string& name);

	virtual ~Tire();

	void setShaderProgram(GLuint shaderProgram);
	void update(float elapsedSeconds);

	void render();

};

#endif

