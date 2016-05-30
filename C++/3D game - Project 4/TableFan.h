#pragma once
#ifndef TABLE_FAN
#define TABLE_FAN

#include "OGL3DCompositeObject.h"

#include <string>
using std::string;

class Texture;
class OGLTexturedFlatSurface;
class Cuboid;
class TableFan :
	public OGL3DCompositeObject
{

protected:
	enum FanState { left, right };
protected:
	Cuboid *base;
	Cuboid *leg1;
	Cuboid *tower;
	Cuboid *towerTop;
	Cuboid *nacelle;
	Cuboid *fan1;
	Cuboid *fan2;
	Cuboid *fan3;
	Cuboid *fan4;
	float rotateDegrees;
private:
	float nacelleDegrees;
	FanState state;

public:
	TableFan(const string& name);
	virtual ~TableFan();
	void setShaderProgram(GLuint shaderProgram);
	void update(float elapsedSeconds);
	void render();

};
#endif