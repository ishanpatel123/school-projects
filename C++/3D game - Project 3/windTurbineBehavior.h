#pragma once
#ifndef ROTATION_FAN
#define ROTATION_FAN

#include "IBehavior.h"

class windTurbineBehavior :
	public IBehavior
{
public:
	enum State { START, STOP, SLOW_DOWN };

protected:
	State state;
	float maxDistance;
	float distanceMoved;
	float rotate360, delta, delta1;
public:
	windTurbineBehavior(float maxDistance = 10.0f);
	virtual ~windTurbineBehavior();

	void update(GameObject *object, float elapsedSeconds);
};

#endif
