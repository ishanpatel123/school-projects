#pragma once
#ifndef JUMP_BEHAVIOR
#define JUMP_BEHAVIOR

#include "IBehavior.h"

class JumpBehavior :
	public IBehavior
{
public:
	enum State { MOVING_UP, MOVING_DOWN };

protected:
	State state;
	float maxDistance;
	float distanceMoved;
	float upDown;

public:
	JumpBehavior(float maxDistance = 10.0f);
	virtual ~JumpBehavior();

	void update(GameObject *object, float elapsedSeconds);
};

#endif