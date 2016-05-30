#pragma once
#ifndef GHOST2
#define GHOST2

#include "OGL3DCompositeObject.h"

#include <string>
using std::string;

class Cuboid;
class OGL2DTexture;
class GhostObject;

class Ghost2 :
	public OGL3DCompositeObject
{
protected:
	enum ElbowState { SWING_UP, SWING_DOWN };
protected:
	GhostObject *body;
	GhostObject *eyes;
	GhostObject *pupil;
	GhostObject *body2;
	GhostObject *body3;
	GhostObject *body4;
	GhostObject *body5;
	GhostObject *body6;
	OGL2DTexture* texture;
private:
	Axis *axis;
	float elbowDegrees;
	ElbowState state;

public:
	Ghost2(const string& name, OGL2DTexture* texture);

	virtual ~Ghost2();

	void setShaderProgram(GLuint shaderProgram);

	void update(float elapsedSeconds);

	void render();

};

#endif

