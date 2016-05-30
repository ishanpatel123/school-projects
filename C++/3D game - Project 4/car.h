#pragma once
#ifndef CAR
#define CAR

#include "OGL3DCompositeObject.h"

#include <string>
using std::string;

class Cuboid;
class Axis;
class Tire;

class car :
	public OGL3DCompositeObject
{
protected:
	enum ElbowState { SWING_UP, SWING_DOWN };
protected:
	Cuboid *body;
	Cuboid *tire1;
	Cuboid *tire2;
	Cuboid *tire3;
	Cuboid *tire4;
	Cuboid *wings;
	Tire *tiree, *tiree2, *tiree3, *tiree4;

private:
	Axis *axis;
	float elbowDegrees;
	ElbowState state;
	float rotateDegrees;

public:
	car(const string& name);
	
	virtual ~car();

	void setShaderProgram(GLuint shaderProgram);


	void update(float elapsedSeconds);

	void render();

	void addTire(Tire* tiree);
	void addTire2(Tire* tiree);
	void addTire3(Tire* tiree);
	void addTire4(Tire* tiree);

};

#endif

