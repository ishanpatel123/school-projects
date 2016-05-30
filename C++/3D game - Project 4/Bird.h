#pragma once
#ifndef BIRD
#define BIRD

#include "OGL3DCompositeObject.h"

#include <string>
using std::string;

class Cuboid;
class Axis;
class Tire;

class Bird :
	public OGL3DCompositeObject
{
public:
	enum State { MOVING_FORWARD, ROTATE_180, MOVING_BACKWARD };

protected:
	enum ElbowState { SWING_UP, SWING_DOWN };
protected:
	Cuboid *body;
	Cuboid *eyes;
	Cuboid *nose;
	Cuboid *legs;
	Cuboid *tail;
	Cuboid *head;
	Cuboid *wings;
	State state;
	float maxDistance;
	float distanceMoved;
	float rotate180;
	float angleY, angleZ, speedZ;

public:
	Bird(const string& name);

	virtual ~Bird();

	void setShaderProgram(GLuint shaderProgram);


	void update(float elapsedSeconds);

	void render();

};

#endif

